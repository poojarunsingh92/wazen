using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Infrastructure;
using WazenTransactions.Application.Models;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Infrastructure.AzureService
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration _config;
        public AzureServiceBusConnectionString _azureService { get; }

        public QueueService(IConfiguration config, IOptions<AzureServiceBusConnectionString> azureService)
        {
            _config = config;
            _azureService = azureService.Value;
        }

        public async Task SendMessageAsync<T>(T serviceBusMessage, string topicName)
        {
            var topicClient = new TopicClient(_azureService.AzureServiceBus, topicName);
            string messageBody = JsonSerializer.Serialize(serviceBusMessage);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            topicClient.SendAsync(message);
        }
    }
}


















/*
 try
            {
                var topicClient = new TopicClient(_azureService.AzureServiceBus, topicName);
                string messageBody = JsonSerializer.Serialize(serviceBusMessage); 
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                topicClient.SendAsync(message);
            }
            catch(Exception ex)
            {

            }
 */