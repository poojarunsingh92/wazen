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
    public class TempDriverRepository : BaseRepository<TempDriver>, ITempDriverRepository
    {

        private readonly ILogger _logger;
        public TempDriverRepository(ApplicationDbContext dbContext, ILogger<TempDriver> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
        public async Task<TempDriver> GetTempDriverDetailByCustomerVehicleID(Guid CustomerVehicleID)
        {
            var driver = _dbContext.TempDrivers.FirstOrDefault(x => x.CustomerVehicleId == CustomerVehicleID);
            return driver;
        }
    }
}
