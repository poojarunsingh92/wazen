using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Infrastructure.EncryptDecrypt;
using WazenTransactions.Persistence.Repositories;

namespace WazenTransactions.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IAdditionalCoverageRepository, AdditionalCoverageRepository>();
            services.AddScoped<ICustomerPolicyRepository, CustomerPolicyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerVehicleRepository, CustomerVehicleRepository>();
            services.AddScoped<IInsuranceCompanyRepository, InsuranceCompanyRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IPolicyTypeRepository, PolicyTypeRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IPolicyRequestRepository, PolicyRequestRepository>();
            services.AddScoped<ICancellationRequestRepository, CancellationRequestRepository>();
            return services;
        }
    }
}
