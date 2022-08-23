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
    public class TempVehicleRepository : BaseRepository<TempVehicle>, ITempVehicleRepository
    {
        private readonly ILogger _logger;
        public TempVehicleRepository(ApplicationDbContext dbContext, ILogger<TempVehicle> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<TempVehicle>> GetTempVehicleListByTempCustomerID(Guid TempCustomerID)
        {
            var vehicles = await _dbContext.TempVehicles.Where(x => x.ID == TempCustomerID).ToListAsync();
            return vehicles;
        }
    }
}
