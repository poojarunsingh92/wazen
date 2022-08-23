using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WazenCustomer.Application.Features.TempCustomers.Commands.CreateTempCustomer;
using WazenCustomer.Application.Helper;

namespace WazenCustomer.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ProducerService>();
            return services;
        }
    }
}
