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
    public class VehicleEngineSizeRepository : BaseRepository<ICVehicleEngineSize>, IVehicleEngineSizeRepository
    {
        private readonly ILogger _logger;
        public VehicleEngineSizeRepository(ApplicationDbContext dbContext, ILogger<ICVehicleEngineSize> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICVehicleEngineSize>> GetVehicleEngineSize()
        {
            var vehicleEngineSizes = await _dbContext.ICVehicleEngineSizes.ToListAsync();
            return vehicleEngineSizes;
        }
    }
}
