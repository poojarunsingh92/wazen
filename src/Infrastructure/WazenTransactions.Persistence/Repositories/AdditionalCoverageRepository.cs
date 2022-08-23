using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
{
    public class AdditionalCoverageRepository : BaseRepository<CustomerPolicyAdditionalCoverage>, IAdditionalCoverageRepository
    {
        ApplicationDbContext _db;
        public AdditionalCoverageRepository(ApplicationDbContext dbContext, ILogger<CustomerPolicyAdditionalCoverage> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}
