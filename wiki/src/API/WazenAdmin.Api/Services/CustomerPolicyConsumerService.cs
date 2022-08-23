using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;
using System.Text;
using WazenAdmin.Persistence;
using WazenAdmin.Domain.Entities;
using WazenAdmin.Application.Models;
using Microsoft.Extensions.Options;

namespace WazenAdmin.Api.Services
{
    public class CustomerPolicyConsumerService : BackgroundService
    {
        public AzureServiceBusConnectionString _azureService { get; }
        string connectionString = String.Empty;
        static ISubscriptionClient subscriptionClient;
        static string topicName = "CustomerPolicy";
        static string subscriptionName = "SubAdminCustomerPolicy";
        private readonly IServiceProvider _serviceProvider;

        public CustomerPolicyConsumerService(IOptions<AzureServiceBusConnectionString> azureService, IServiceProvider serviceProvider)
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
            CustomerPolicy customerPolicy = JsonSerializer.Deserialize<CustomerPolicy>(jsonString);
            Console.WriteLine($"CustomerPolicy Received: ");
            Console.WriteLine(customerPolicy);
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var isExist = dbContext.CustomerPolicies.Find(customerPolicy.Id);
                    if (isExist != null)
                    {
                        //Update
                        var responseUpdate = dbContext.Update(customerPolicy);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        //Add
                        customerPolicy.Customer = null;
                        customerPolicy.Vehicle = null;
                        customerPolicy.PolicyType = null;
                        customerPolicy.Transaction = null;
                        var responseAdd = dbContext.Add(customerPolicy);
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
