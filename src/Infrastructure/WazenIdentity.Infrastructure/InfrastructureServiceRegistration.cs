using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenIdentity.Application.Contracts.Infrastructure;
using WazenIdentity.Application.Models.Mail;
using WazenIdentity.Infrastructure.Mail;

namespace WazenIdentity.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
