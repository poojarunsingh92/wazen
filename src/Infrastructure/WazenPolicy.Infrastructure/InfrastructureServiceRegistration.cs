using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenPolicy.Application.Contracts.Infrastructure;
using WazenPolicy.Application.Models;
using WazenPolicy.Application.Models.Mail;
using WazenPolicy.Infrastructure.Mail;

namespace WazenPolicy.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();
            services.Configure<AzureServiceBusConnectionString>(configuration.GetSection("AzureServiceBusConnectionString"));
            return services;
        }
    }
}
