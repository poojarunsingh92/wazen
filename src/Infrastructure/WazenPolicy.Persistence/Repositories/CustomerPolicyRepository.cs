using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Domain.Entities;
using WazenPolicy.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WazenPolicy.Persistence.Repositories
{
    public class CustomerPolicyRepository : BaseRepository<CustomerPolicy>, ICustomerPolicyRepository
    {

        private readonly ILogger _logger;
        public CustomerPolicyRepository(ApplicationDbContext dbContext, ILogger<CustomerPolicy> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<CustomerPolicy> GetByCustomerVehicleIDPolicyNameAsync(Guid CustomerVehicleID, string PolicyName)
        {
            var customerPolicy = _dbContext.CustomerPolicies.FirstOrDefault(x => x.CustomerVehicleID == CustomerVehicleID && x.PolicyName== PolicyName);
            return customerPolicy;
        }

        public async Task<CustomerPolicy> GetExistingCustomerPolicyAsync(Guid CustomerVehicleID)
        {
            var customerPolicy = _dbContext.CustomerPolicies.FirstOrDefault(x => x.CustomerVehicleID == CustomerVehicleID);
            return customerPolicy;
        }

        public async Task<CustomerPolicy> GetCustomerPolicyByCustomerVehicleID(Guid CustomerVehicleID)
        {
            var customerVehicle = _dbContext.CustomerPolicies.FirstOrDefault(x => x.CustomerVehicleID == CustomerVehicleID);

            return customerVehicle;
        }

    }
}
