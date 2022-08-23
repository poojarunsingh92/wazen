using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    class CustomerPolicyRepository : BaseRepository<CustomerPolicy>, ICustomerPolicyRepository
    {
        private readonly ILogger _logger;
        public CustomerPolicyRepository(ApplicationDbContext dbContext, ILogger<CustomerPolicy> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<CustomerPolicy> GetCustomerPolicyByVehicleID(Guid VehicleID)
        {
            var customerPolicy = _dbContext.CustomerPolicies.FirstOrDefault(x => (x.VehicleId == VehicleID));

            return customerPolicy;
        }

        public async Task<IEnumerable<CustomerPolicy>> GetCustomerPolicyListByCustomerID(Guid CustomerID)
        {
            var customerPolicies = await _dbContext.CustomerPolicies.Where(x => x.CustomerId == CustomerID).ToListAsync();
            return customerPolicies;
        }
    }
}
