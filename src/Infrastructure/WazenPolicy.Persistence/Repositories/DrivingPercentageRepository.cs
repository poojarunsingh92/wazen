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
    public class DrivingPercentageRepository : BaseRepository<ICDrivingPercentage>, IDrivingPercentageRepository
    {
        private readonly ILogger _logger;
        public DrivingPercentageRepository(ApplicationDbContext dbContext, ILogger<ICDrivingPercentage> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICDrivingPercentage>> GetDrivingPercentage()
        {
            var drivingPercentages = await _dbContext.ICDrivingPercentages.ToListAsync();
            return drivingPercentages;
        }
    }
}
