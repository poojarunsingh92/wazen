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
    public class VehicleViolationRepository : BaseRepository<VehicleViolation>, IVehicleViolationRepository
    {

        private readonly ILogger _logger;
        public VehicleViolationRepository(ApplicationDbContext dbContext, ILogger<VehicleViolation> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<VehicleViolation> GetVehicleViolationDetailByVehicleID(Guid VehicleID)
        {
            var vehicleViolation = _dbContext.VehicleViolations.FirstOrDefault(x => x.VehicleID == VehicleID);
            return vehicleViolation;
        }

        public async Task<List<VehicleViolation>> GetVehicleViolationListByVehicleID(Guid VehicleID)
        {
            var vehicleViolations = await _dbContext.VehicleViolations.Where(x => x.VehicleID == VehicleID).ToListAsync();
            return vehicleViolations;
        }
    }
}