using Microsoft.EntityFrameworkCore;
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
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly ILogger _logger;
        public VehicleRepository(ApplicationDbContext dbContext, ILogger<Vehicle> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Vehicle>> GetVehicleListByCustomerID(Guid CustomerID)
        {
            var vehicles = await _dbContext.Vehicles.Where(x => x.CustomerID == CustomerID).ToListAsync();
            return vehicles;
        }
    }
}
