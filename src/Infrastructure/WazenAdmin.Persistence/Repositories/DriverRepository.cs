using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        private readonly ILogger _logger;
        public DriverRepository(ApplicationDbContext dbContext, ILogger<Driver> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<Driver> GetDriverByVehicleID(Guid VehicleID)
        {
            var driver = _dbContext.Drivers.FirstOrDefault(x => x.CustomerVehicleId == VehicleID);
            return driver;
        }
    }
}
