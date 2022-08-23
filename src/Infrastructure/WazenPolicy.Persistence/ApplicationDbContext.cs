using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wazen.Domain.Entities;
using WazenPolicy.Application.Contracts;
using WazenPolicy.Domain.Common;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        //Entities Objects Starts
        public DbSet<Education> Educations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<MedicalIssue> MedicalIssues { get; set; }

        public DbSet<CancellationRequest> CancellationRequest { get; set; }
        public DbSet<Customer> Customers { get; set; }        
        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public DbSet<CustomerVehicle> CustomerVehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<NationalIdType> NationalIdTypes { get; set; }
        public DbSet<Salutation> Salutations { get; set; }
        public DbSet<TempCustomer> TempCustomers { get; set; }
        public DbSet<TempDriver> TempDrivers { get; set; }
        public DbSet<TempVehicle> TempVehicle { get; set; }
        public DbSet<TempVehicleViolation> TempVehicleViolations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePurpose> VehiclePurpose { get; set; }
        public DbSet<VehicleViolation> VehicleViolations { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }


        public DbSet<InsuranceCompanyQuoteResponse> InsuranceCompanyQuoteResponses { get; set; }


        //ICs LookUp Tables        
        public DbSet<ICAdditionalCoverr> ICAdditionalCovers { get; set; }
        public DbSet<ICBankCode> ICBankCodes { get; set; }
        public DbSet<ICCardIdType> ICCardIdTypes { get; set; }
        public DbSet<ICCities> ICCities { get; set; }
        public DbSet<ICCountries> ICCountries { get; set; }
        public DbSet<ICDeductable> ICDeductables { get; set; }
        public DbSet<ICDiscount> ICDiscounts { get; set; }
        public DbSet<ICDriverType> ICDriverTypes { get; set; }
        public DbSet<ICDrivingPercentage> ICDrivingPercentages { get; set; }
        public DbSet<ICEducation> ICEducations { get; set; }
        public DbSet<ICGender> ICGenders { get; set; }
        public DbSet<ICHealthCondition> ICHealthConditions { get; set; }
        public DbSet<ICImageTitle> ICImageTitles { get; set; }
        public DbSet<ICLicenseType> ICLicenseTypes { get; set; }
        public DbSet<ICMaritalStatus> ICMaritalStatus { get; set; }
        public DbSet<ICMileages> ICMileages { get; set; }
        public DbSet<ICNationality> ICNationalities { get; set; }
        public DbSet<ICNCDFreeYear> ICNCDFreeYears { get; set; }
        public DbSet<ICOccupation> ICOccupations { get; set; }
        public DbSet<ICParkingLocation> ICParkingLocations { get; set; }
        public DbSet<ICPaymentMethod> ICPaymentMethods { get; set; }
        public DbSet<ICPlateLetter> ICPlateLetters { get; set; }
        public DbSet<ICPremiumBreakdownn> ICPremiumBreakdown { get; set; }
        public DbSet<ICPriceType> ICPriceTypes { get; set; }
        public DbSet<ICProductType> ICProductTypes { get; set; }
        public DbSet<ICRelationship> ICRelationships { get; set; }
        public DbSet<ICRepairType> ICRepairTypes { get; set; }
        public DbSet<ICTransmissionType> ICTransmissionTypes { get; set; }
        public DbSet<ICVehicleAxlesWeight> ICVehicleAxlesWeights { get; set; }
        public DbSet<ICVehicleColor> ICVehicleColors { get; set; }
        public DbSet<ICVehicleEngineSize> ICVehicleEngineSizes { get; set; }
        public DbSet<ICVehicleIdType> ICVehicleIdTypes { get; set; }
        public DbSet<ICVehiclePlateType> ICVehiclePlateTypes { get; set; }
        public DbSet<ICVehicleSpecificationn> ICVehicleSpecifications { get; set; }
        public DbSet<ICVehicleUses> ICVehicleUses { get; set; }
        public DbSet<ICViolation> ICViolations { get; set; }
        //Entities Objects Ends


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}