using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Infrastructure.EncryptDecrypt;
using WazenPolicy.Persistence.Repositories;

namespace WazenPolicy.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITempCustomerRepository, TempCustomerRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ITempDriverRepository, TempDriverRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ITempVehicleRepository, TempVehicleRepository>();
            services.AddScoped<ICustomerVehicleRepository, CustomerVehicleRepository>();
            services.AddScoped<ICustomerPolicyRepository, CustomerPolicyRepository>();
            services.AddScoped<ICancellationRequestRepository, CancellationRequestRepository>();
            services.AddScoped<IInsuranceCompanyRepository, InsuranceCompanyRepository>();
            services.AddScoped<IQuoteResponseRepository, QuoteResponseRepository>();
            services.AddScoped<ITempVehicleViolationRepository, TempVehicleViolationRepository>();
            services.AddScoped<IVehicleViolationRepository, VehicleViolationRepository>();
            services.AddScoped<IViolationTypeRepository, ViolationTypeRepository>();
            //services.AddTransient<CustomerPolicyRepository>();

            //Registration of ICLookUp services
            services.AddScoped<IAdditionalCoverRepository, AdditionalCoverRepository>();
            services.AddScoped<IBankCodeRepository, BankCodeRepository>();
            services.AddScoped<ICardIdTypeRepository, CardIdTypeRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IDeductableRepository, DeductableRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();            
            services.AddScoped<IDriverTypeRepository, DriverTypeRepository>();
            services.AddScoped<IDrivingPercentageRepository, DrivingPercentageRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IHealthConditionRepository, HealthConditionRepository>();
            services.AddScoped<IImageTitleRepository, ImageTitleRepository>();
            services.AddScoped<ILicenseTypeRepository, LicenseTypeRepository>();
            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<IMedicalIssueRepository, MedicalIssueRepository>();
            services.AddScoped<IMileageRepository, MileageRepository>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<INCDFreeYearRepository, NCDFreeYearRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<IParkingLocationRepository, ParkingLocationRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPlateLetterRepository, PlateLetterRepository>();
            services.AddScoped<IPremiumBreakdownRepository, PremiumBreakdownRepository>();
            services.AddScoped<IPriceTypeRepository, PriceTypeRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IRelationshipRepository, RelationshipRepository>();
            services.AddScoped<IRepairTypeRepository, RepairTypeRepository>();
            services.AddScoped<ITransmissionTypeRepository, TransmissionTypeRepository>();
            services.AddScoped<IVehicleAxlesWeightRepository, VehicleAxlesWeightRepository>();
            services.AddScoped<IVehicleColorRepository, VehicleColorRepository>();
            services.AddScoped<IVehicleEngineSizeRepository, VehicleEngineSizeRepository>();
            services.AddScoped<IVehicleIdTypeRepository, VehicleIdTypeRepository>();
            services.AddScoped<IVehiclePlateTypeRepository, VehiclePlateTypeRepository>();
            services.AddScoped<IVehicleSpecificationRepository, VehicleSpecificationRepository>();
            services.AddScoped<IVehicleUsesRepository, VehicleUsesRepository>();
            services.AddScoped<IViolationRepository, ViolationRepository>();

            return services;
        }
    }
}
