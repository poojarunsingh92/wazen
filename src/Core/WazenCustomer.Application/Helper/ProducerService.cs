using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WazenCustomer.Application.Helper
{
 
    public class ProducerService
    {
        private readonly string bootstrapServers = "180.149.247.134:9092";
            

        public async Task<bool> SendOrderRequest
        (string topic, string message)
        {

            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder
                    <Null, string>(config).Build())
                {
                    var result = producer.ProduceAsync
                        (topic, new Message<Null, string>
                        {
                            Value = message
                        });

                    result.ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            Console.WriteLine("task faulted", task.Exception.Data);
                        }
                        else
                        {
                            Console.WriteLine($"Wrote to offset: {task.Result.Offset}");
                        }
                    });
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return await Task.FromResult(false);
        }
    }
}

