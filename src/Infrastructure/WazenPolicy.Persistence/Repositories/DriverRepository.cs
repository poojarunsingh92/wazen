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
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {

        private readonly ILogger _logger;
        public DriverRepository(ApplicationDbContext dbContext, ILogger<Driver> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<Driver> GetDriverDetailByCustomerVehicleID(Guid CustomerVehicleID)
        {
            var driver = _dbContext.Drivers.FirstOrDefault(x => x.CustomerVehicleId == CustomerVehicleID);
            return driver;
        }
    }
}
