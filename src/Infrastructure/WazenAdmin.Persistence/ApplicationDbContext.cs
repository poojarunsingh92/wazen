using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts;
using WazenAdmin.Domain.Common;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence
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

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<HomePageBanner> HomePageBanners { get; set; }
        public DbSet<ICAPIDetail> ICAPIDetails { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PolicyRequest> PolicyRequests { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StaticContent> StaticContents { get; set; }
        public DbSet<TempCustomer> TempCustomers { get; set; }
        public DbSet<TempVehicle> TempVehicles { get; set; }
        public DbSet<TempVehicleViolation> TempVehicleViolations { get; set; }
        public DbSet<TempDriver> TempDrivers { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleViolation> VehicleViolations { get; set; }
        public DbSet<VehiclePurpose> VehiclePurposes { get; set; }
        public DbSet<CancellationRequest> CancellationRequests { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            
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
