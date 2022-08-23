using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Contracts.Infrastructure
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T serviceBusMessage, string topicName);        

    }
}