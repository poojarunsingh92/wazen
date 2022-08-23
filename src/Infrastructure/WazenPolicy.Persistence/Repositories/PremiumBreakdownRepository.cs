using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class PremiumBreakdownRepository : BaseRepository<ICPremiumBreakdownn>, IPremiumBreakdownRepository
    {
        private readonly ILogger _logger;
        public PremiumBreakdownRepository(ApplicationDbContext dbContext, ILogger<ICPremiumBreakdownn> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICPremiumBreakdownn>> GetPremiumBreakdown()
        {
            var premiumBreakdowns = await _dbContext.ICPremiumBreakdown.ToListAsync();
            return premiumBreakdowns;
        }
    }
}
