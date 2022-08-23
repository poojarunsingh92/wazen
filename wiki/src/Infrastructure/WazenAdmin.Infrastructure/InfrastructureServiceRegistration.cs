using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenAdmin.Application.Contracts.Infrastructure;
using WazenAdmin.Application.Models;
using WazenAdmin.Application.Models.Mail;
using WazenAdmin.Infrastructure.AzureService;
using WazenAdmin.Infrastructure.Mail;

namespace WazenAdmin.Infrastructure
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
