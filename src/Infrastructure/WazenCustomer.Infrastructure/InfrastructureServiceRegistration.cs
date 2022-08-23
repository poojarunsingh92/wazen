using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Models;
using WazenCustomer.Application.Models.Mail;
using WazenCustomer.Infrastructure.AzureService;
using WazenCustomer.Infrastructure.Mail;

namespace WazenCustomer.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();
            services.Configure<AzureServiceBusConnectionString>(configuration.GetSection("AzureServiceBusConnectionString"));
            services.AddTransient<IQueueService, QueueService>(); 
            return services;
        }
    }
}