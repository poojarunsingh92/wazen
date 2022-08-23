using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Contracts.Infrastructure
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T serviceBusMessage, string topicName);

    }
}
