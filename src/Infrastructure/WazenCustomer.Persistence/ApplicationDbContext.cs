using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts;
using WazenCustomer.Domain.Common;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Persistence
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

        public DbSet<CancellationRequest> CancellationRequests { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOTP> CustomerOTPs { get; set; }
        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public DbSet<CustomerPolicyAdditionalCoverage> CustomerPolicyAdditionalCoverages { get; set; }
        public DbSet<CustomerVehicle> CustomerVehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<MedicalIssue> MedicalIssues { get; set; }
        public DbSet<NationalIdType> NationalIdTypes { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
        public DbSet<Salutation> Salutations { get; set; }
        public DbSet<TempCustomer> TempCustomers { get; set; }
        public DbSet<TempDriver> TempDrivers { get; set; }
        public DbSet<TempVehicle> TempVehicles { get; set; }
        public DbSet<TempVehicleImage> TempVehicleImages { get; set; }
        public DbSet<TempVehicleViolation> TempVehicleViolations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<VehiclePurpose> VehiclePurposes { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<VehicleViolation> VehicleViolations { get; set; }

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
            catch (Exception ex)
            {
                throw;
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
