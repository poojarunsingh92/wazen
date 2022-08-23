using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseFromRedis;
using WazenPolicy.Application.Helper;

namespace WazenPolicy.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<CustomerPolicyProducer>();
            services.AddScoped(typeof(RedisDataConnection<>));
            return services;
        }
    }
}
