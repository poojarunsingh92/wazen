using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenTransactions.Application.Contracts.Infrastructure;
using WazenTransactions.Application.Models;
using WazenTransactions.Application.Models.Mail;
using WazenTransactions.Infrastructure.AzureService;
using WazenTransactions.Infrastructure.Mail;

namespace WazenTransactions.Infrastructure
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
