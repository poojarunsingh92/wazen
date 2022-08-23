using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Domain.Entities;
using WazenTransactions.Persistence;

namespace WazenTransactions.Api.Services
{
    public class InsuranceCompanyConsumerService : BackgroundService
    {
        const string connectionString = "Endpoint=sb://wazen123.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KwBHQqcSPWTQeDPX2Gi6fw6MoK2tYy1uJBRnAWDvR2w=";
        static ISubscriptionClient subscriptionClient;
        static string topicName = "Customer";
        static string subscriptionName = "SubTransactionCustomer";
        private readonly IServiceProvider _serviceProvider;

        public InsuranceCompanyConsumerService(IServiceProvider serviceProvider)
        {
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
            InsuranceCompany insuranceCompany = JsonSerializer.Deserialize<InsuranceCompany>(jsonString);
            Console.WriteLine($"Customer Received: ");
            Console.WriteLine(insuranceCompany);
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var isExist = dbContext.InsuranceCompanies.Find(insuranceCompany.Id);
                    if (isExist != null)
                    {
                        //Update
                        var responseUpdate = dbContext.Update(insuranceCompany);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        //Add
                        var responseAdd = dbContext.Add(insuranceCompany);
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
