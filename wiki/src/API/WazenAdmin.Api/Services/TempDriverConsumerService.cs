using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Models;
using WazenAdmin.Domain.Entities;
using WazenAdmin.Persistence;

namespace WazenAdmin.Api.Services
{
    public class TempDriverConsumerService : BackgroundService
    {
        public AzureServiceBusConnectionString _azureService { get; }
        string connectionString = String.Empty;
        static ISubscriptionClient subscriptionClient;
        static string topicName = "TempDriver";
        static string subscriptionName = "SubAdminTempDriver";
        private readonly IServiceProvider _serviceProvider;

        public TempDriverConsumerService(IOptions<AzureServiceBusConnectionString> azureService, IServiceProvider serviceProvider)
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
            TempDriver tempDriver = JsonSerializer.Deserialize<TempDriver>(jsonString);
            Console.WriteLine($"Temp Driver Received: ");
            Console.WriteLine(tempDriver);
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var isExist = dbContext.TempDrivers.Find(tempDriver.ID);
                    if (isExist != null)
                    {
                        //Update
                        var responseUpdate = dbContext.Update(tempDriver);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        //Add
                        tempDriver.TempVehicle = null;
                        var responseAdd = dbContext.Add(tempDriver);
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
