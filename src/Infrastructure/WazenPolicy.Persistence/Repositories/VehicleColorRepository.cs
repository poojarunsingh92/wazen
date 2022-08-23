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
    public class VehicleColorRepository : BaseRepository<ICVehicleColor>, IVehicleColorRepository
    {
        private readonly ILogger _logger;
        public VehicleColorRepository(ApplicationDbContext dbContext, ILogger<ICVehicleColor> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICVehicleColor>> GetVehicleColor()
        {
            var vehicleColors = await _dbContext.ICVehicleColors.ToListAsync();
            return vehicleColors;
        }
    }
}
