using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Persistence.Repositories;

namespace WazenAdmin.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IComplaintRepository, ComplaintRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IFAQRepository, FAQRepository>();
            services.AddScoped<IHomePageBannerRepository, HomePageBannerRepository>();
            services.AddScoped<IICAPIDetailRepository, ICAPIDetailRepository>();
            services.AddScoped<IInsuranceCompaniesRepository, InsuranceCompaniesRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStaticContentRepository, StaticContentRepository>();
            services.AddScoped<ITermsAndConditionsRepository, TermsAndConditionsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ICustomerPolicyRepository, CustomerPolicyRepository>();
            services.AddScoped<IPolicyRequestRepository, PolicyRequestRepository>();
            services.AddScoped<ICancellationRequestRepository, CancellationRequestRepository>();
            services.AddScoped<ITempCustomerRepository, TempCustomerRepository>();
            services.AddScoped<ITempVehicleRepository, TempVehicleRepository>();
            return services;
        }
    }
}
