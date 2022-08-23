using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Persistence.Repositories
{
    public class TempVehicleViolationRepository : BaseRepository<TempVehicleViolation>, ITempVehicleViolationRepository
    {

        ApplicationDbContext _db;
        public TempVehicleViolationRepository(ApplicationDbContext dbContext, ILogger<TempVehicleViolation> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<TempVehicleViolation>> GetTempVehicleViolationsByVehicleID(Guid VehicleID)
        {
            var vehicleViolations = await _dbContext.TempVehicleViolations.Where(x => x.VehicleID == VehicleID).ToListAsync();
            return vehicleViolations;
        }
    }
}
