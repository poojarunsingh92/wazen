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
    public class ParkingLocationRepository : BaseRepository<ICParkingLocation>, IParkingLocationRepository
    {
        private readonly ILogger _logger;
        public ParkingLocationRepository(ApplicationDbContext dbContext, ILogger<ICParkingLocation> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICParkingLocation>> GetParkingLocation()
        {
            var parkingLocations = await _dbContext.ICParkingLocations.ToListAsync();
            return parkingLocations;
        }
    }
}
