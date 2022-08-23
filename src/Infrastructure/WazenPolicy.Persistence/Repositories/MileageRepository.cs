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
    public class MileageRepository : BaseRepository<ICMileages>, IMileageRepository
    {
        private readonly ILogger _logger;
        public MileageRepository(ApplicationDbContext dbContext, ILogger<ICMileages> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICMileages>> GetMileage()
        {
            var mileages = await _dbContext.ICMileages.ToListAsync();
            return mileages;
        }
    }
}
