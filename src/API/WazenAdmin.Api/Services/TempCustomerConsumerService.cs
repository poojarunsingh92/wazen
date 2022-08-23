using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WazenAdmin.Domain.Entities;
using WazenAdmin.Persistence;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;
using System.Text;
using WazenAdmin.Application.Models;
using Microsoft.Extensions.Options;

namespace WazenAdmin.Api.Services
{
    public class TempCustomerConsumerService : BackgroundService 
    {
        public AzureServiceBusConnectionString _azureService { get; }
        string connectionString = String.Empty;
        static ISubscriptionClient subscriptionClient;
        static string topicName = "TempCustomer";
        static string subscriptionName = "SubAdminTempCustomer";
        private readonly IServiceProvider _serviceProvider;
        
        public TempCustomerConsumerService(IOptions<AzureServiceBusConnectionString> azureService,IServiceProvider serviceProvider)
        {
            _azureService = azureService.Value;
            _serviceProvider = serviceProvider;
        }       

        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();//deserializer code 
            Console.WriteLine($"Received: {body} from subscription: {subscriptionName}");
            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            connectionString = _azureService.AzureServiceBus;
            subscriptionClient = new SubscriptionClient(connectionString, topicName, subscriptionName);
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false,
            };
            subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
            return Task.CompletedTask;
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var jsonString = Encoding.UTF8.GetString(message.Body);
            TempCustomer tempCustomer = JsonSerializer.Deserialize<TempCustomer>(jsonString);
            Console.WriteLine($"Temp Customer Received: ");
            Console.WriteLine(tempCustomer);
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var isExist = dbContext.TempCustomers.Find(tempCustomer.ID);
                    if(isExist!=null)
                    {
                        //Update                        
                        var responseUpdate = dbContext.Update(isExist);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        //Add
                        var responseAdd = dbContext.Add(tempCustomer);
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }
      
        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Message handler exception: { arg.Exception }");
            return Task.CompletedTask;
        }       
    }
}
