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
    public class RepairTypeRepository : BaseRepository<ICRepairType>, IRepairTypeRepository
    {
        private readonly ILogger _logger;
        public RepairTypeRepository(ApplicationDbContext dbContext, ILogger<ICRepairType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICRepairType>> GetRepairType()
        {
            var repairTypes = await _dbContext.ICRepairTypes.ToListAsync();
            return repairTypes;
        }
    }
}
