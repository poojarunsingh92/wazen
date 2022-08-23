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
    public class AdditionalCoverageRepository : BaseRepository<CustomerPolicyAdditionalCoverage>, IAdditionalCoverageRepository
    {
        ApplicationDbContext _db;
        public AdditionalCoverageRepository(ApplicationDbContext dbContext, ILogger<CustomerPolicyAdditionalCoverage> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

        public async Task<CustomerPolicyAdditionalCoverage> GetAdditionalCoverageByPolicyID(Guid PolicyID)
        {
            var additionalCoverage = _dbContext.CustomerPolicyAdditionalCoverages.FirstOrDefault(x=>x.CustomerPolicyId==PolicyID);
            return additionalCoverage;
        }
    }

}
