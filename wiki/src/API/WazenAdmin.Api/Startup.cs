using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using WazenAdmin.Api.Extensions;
using WazenAdmin.Api.Middleware;
using WazenAdmin.Api.Services;
using WazenAdmin.Api.SwaggerHelper;
using WazenAdmin.Api.Utility;
using WazenAdmin.Application;
using WazenAdmin.Application.Contracts;
using WazenAdmin.Identity;
using WazenAdmin.Infrastructure;
using WazenAdmin.Persistence;

namespace WazenAdmin.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string Urls = Configuration.GetSection("URLWhiteListings").GetSection("URLs").Value;
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(Urls);
                                  });
            });
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddPersistenceServices(Configuration);
            services.AddIdentityServices(Configuration);
            services.AddSwaggerExtension();
            services.AddSwaggerVersionedApiExplorer();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            //Service Bus Services Registration to receieve the data from from several entities in the background
            services.AddHostedService<CustomerConsumerService>();
            services.AddHostedService<VehicleConsumerService>();
            services.AddHostedService<DriverConsumerService>();
            services.AddHostedService<TempCustomerConsumerService>();
            services.AddHostedService<TempVehicleConsumerService>();
            services.AddHostedService<TempDriverConsumerService>();
            services.AddHostedService<TransactionConsumerService>();
            services.AddHostedService<CustomerPolicyConsumerService>();
            services.AddHostedService<PolicyRequestConsumerService>();
            services.AddHostedService<TempVehicleViolationConsumerService>();
            services.AddHostedService<VehicleViolationConsumerService>();

            services.AddControllers();
            services.AddDataProtection();
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddHealthcheckExtensionService(Configuration);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
            // specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(
            options =>
            {
                // build a swagger endpoint for each discovered API version  
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            app.UseCustomExceptionHandler();

            app.UseCors("Open");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                //adding endpoint of health check for the health check ui in UI format
                endpoints.MapHealthChecks("/healthz", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                //map healthcheck ui endpoing - default is /healthchecks-ui/
                endpoints.MapHealthChecksUI();

            });
        }

    }

}
