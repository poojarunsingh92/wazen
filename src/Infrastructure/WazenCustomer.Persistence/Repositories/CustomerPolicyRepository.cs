using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class CustomerPolicyRepository : BaseRepository<CustomerPolicy>, ICustomerPolicyRepository
    {
        ApplicationDbContext _db;
        public CustomerPolicyRepository(ApplicationDbContext dbContext, ILogger<CustomerPolicy> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
        
        public async Task<List<CustomerPolicy>> GetAdditionalCoverage(Guid Id)
        {
            var additionalCoverageList = await _db.Set<CustomerPolicy>().Include(x => x.CustomerPolicyAdditionalCoverage).Where(x=>x.Id==Id).ToListAsync();
            return additionalCoverageList;
        }

        
        public async Task<CustomerPolicy> GetCustomerPolicyByCustomerVehicleID(Guid CustomerVehicleID)
        {
            var customerVehicle = await _dbContext.CustomerPolicies.Include(x=>x.CustomerPolicyAdditionalCoverage).FirstOrDefaultAsync(x => x.VehicleId == CustomerVehicleID);
            return customerVehicle;
        }

        public async Task<CustomerPolicy> GetCustomerPolicyByVehicleID(Guid VehicleID)
        {
            var customerPolicy = _dbContext.CustomerPolicies.FirstOrDefault(x => x.VehicleId == VehicleID);
            return customerPolicy;
        }

        public async Task<CustomerPolicy> GetCustomerPolicyByVehicleIDTransactionID(Guid CustomerVehicleID, Guid TransactionID)
        {
            var customerPolicy = _dbContext.CustomerPolicies.FirstOrDefault(x => x.VehicleId == CustomerVehicleID && x.TransactionId==TransactionID);
            return customerPolicy;
        }
    }
}
