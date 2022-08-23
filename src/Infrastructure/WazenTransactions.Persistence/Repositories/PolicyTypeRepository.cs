using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
{
    public class PolicyTypeRepository : BaseRepository<PolicyType>, IPolicyTypeRepository
    {
        ApplicationDbContext _db;
        public PolicyTypeRepository(ApplicationDbContext dbContext, ILogger<PolicyType> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

        public async Task<PolicyType> GetPolicyTypeByDescription(string Description)
        {
            var policyType = _dbContext.PolicyTypes.FirstOrDefault(x => x.Description == Description);
            return policyType;
        }

    }
}
