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
    public class HealthConditionRepository : BaseRepository<ICHealthCondition>, IHealthConditionRepository
    {
        private readonly ILogger _logger;
        public HealthConditionRepository(ApplicationDbContext dbContext, ILogger<ICHealthCondition> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICHealthCondition>> GetHealthCondition()
        {
            var healthConditions = await _dbContext.ICHealthConditions.ToListAsync();
            return healthConditions;
        }
    }
}
