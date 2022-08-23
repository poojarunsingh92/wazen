using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Infrastructure.EncryptDecrypt;
using WazenCustomer.Persistence.Repositories;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            //Service Registrattions
            services.AddScoped<IAdditionalCoverageRepository, AdditionalCoverageRepository>();
            services.AddScoped<ICancellationRequestRepository, CancellationRequestRepository>();
            services.AddScoped<ICustomerPolicyRepository, CustomerPolicyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerOTPRepository, CustomerOTPRepository>();
            services.AddScoped<ICustomerVehicleRepository, CustomerVehicleRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<IMedicalIssueRepository, MedicalIssueRepository>();
            services.AddScoped<INationalIdTypeRepository, NationalIdTypeRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<ISalutationRepository, SalutationRepository>();
            services.AddScoped<ITempCustomerRepository, TempCustomerRepository>();
            services.AddScoped<ITempDriverRepository, TempDriverRepository>();
            services.AddScoped<ITempVehicleRepository, TempVehicleRepository>();
            services.AddScoped<ITempVehicleImageRepository, TempVehicleImageRepository>();
            services.AddScoped<ITempVehicleViolationRepository, TempVehicleViolationRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IVehiclePurposeRepository, VehiclePurposeRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleImageRepository, VehicleImageRepository>();
            services.AddScoped<IVehicleViolationRepository, VehicleViolationRepository>();
            services.AddScoped<IViolationTypeRepository, ViolationTypeRepository>();
            services.AddScoped<ITempVehicleViolationRepository, TempVehicleViolationRepository>();
            return services;
        }
    }
}