using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WazenPolicy.Domain.Entities;
using WazenPolicy.Persistence;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;
using System.Text;
using WazenPolicy.Application.Models;
using Microsoft.Extensions.Options;

namespace WazenPolicy.Api.Services
{
    public class CustomerAdminVehicleConsumerService : BackgroundService
    {
        public AzureServiceBusConnectionString _azureService { get; }
        string connectionString = String.Empty;
        static ISubscriptionClient subscriptionClient;
        static string topicName = "AdminVehicle";
        static string subscriptionName = "SubPolicyAdminVehicle";
        private readonly IServiceProvider _serviceProvider;

        public CustomerAdminVehicleConsumerService(IOptions<AzureServiceBusConnectionString> azureService, IServiceProvider serviceProvider)
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
            Vehicle vehicle = JsonSerializer.Deserialize<Vehicle>(jsonString);
            Console.WriteLine($"Vehicle Received: ");
            Console.WriteLine(vehicle);
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var isExist = dbContext.Vehicles.Find(vehicle.ID);
                    if (isExist != null)
                    {
                        //Update
                        var responseUpdate = dbContext.Update(isExist);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        //Add
                        vehicle.Customer = null;
                        var responseAdd = dbContext.Add(vehicle);
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
