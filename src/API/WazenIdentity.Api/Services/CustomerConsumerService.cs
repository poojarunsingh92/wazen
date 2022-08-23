using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using WazenIdentity.Domain.Entities;
using WazenIdentity.Persistence;

namespace WazenIdentity.Api.Services
{
    //public class CustomerConsumerService : BackgroundService
    //{
    //    private readonly string topic = "customer";
    //    private readonly string groupId = "test-consumer-group";
    //    private readonly string bootstrapServers = "180.149.247.134:9092";
    //    private readonly IMapper _mapper;
    //    private readonly ILogger _logger;
    //    private readonly IServiceProvider _serviceProvider;

    //    public CustomerConsumerService(IMapper mapper, ILogger<CustomerConsumerService> logger, IServiceProvider serviceProvider)
    //    {
    //        _mapper = mapper;
    //        _logger = logger;
    //        _serviceProvider = serviceProvider;
    //    }

        //protected override Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    Task.Run(async () =>
        //    {
        //        _logger.LogInformation("ExecuteAsync Initiated");
        //        var config = new ConsumerConfig
        //        {
        //            GroupId = groupId,
        //            BootstrapServers = bootstrapServers,
        //            AutoOffsetReset = AutoOffsetReset.Earliest
        //        };

        //        try
        //        {
        //            using (var consumerBuilder = new ConsumerBuilder
        //            <Ignore, string>(config).Build())
        //            {
        //                consumerBuilder.Subscribe(topic);
        //                var cancelToken = new CancellationTokenSource();

        //                try
        //                {
        //                    while (true)
        //                    {
        //                        var consumer = consumerBuilder.Consume(cancelToken.Token);
        //                        var resp = JsonSerializer.Deserialize<Customer>(consumer.Message.Value);
        //                        Console.WriteLine(consumer.Message.Value);
        //                        if (resp != null)
        //                        {
        //                            var customer = new Customer();
        //                            customer = _mapper.Map<Customer>(resp);
        //                            using (var scope = _serviceProvider.CreateScope())
        //                            {
        //                                try
        //                                {
        //                                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        //                                    var response = dbContext.Add(customer);
        //                                    dbContext.SaveChanges();
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    throw;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                catch (OperationCanceledException)
        //                {
        //                    consumerBuilder.Close();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine(ex.Message);
        //        }
        //        _logger.LogInformation("ExecuteAsync Completed");
        //    }, stoppingToken);
        //    return Task.CompletedTask;
        //}
    //}
}
