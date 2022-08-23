using AutoMapper;
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
    public class TempVehicleViolationRepository : BaseRepository<VehicleViolation>, ITempVehicleViolationRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TempVehicleViolationRepository(ApplicationDbContext dbContext, IMapper mapper, ILogger<VehicleViolation> logger) : base(dbContext, logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<VehicleViolation> GetTempVehicleViolationDetailByVehicleID(Guid VehicleID)
        {
            var vehicleViolation = _dbContext.TempVehicleViolations.FirstOrDefault(x => x.VehicleID == VehicleID);
            var vehicleViolations = _mapper.Map<VehicleViolation>(vehicleViolation);
            return vehicleViolations;
        }

        public async Task<List<VehicleViolation>> GetTempVehicleViolationListByVehicleID(Guid VehicleID)
        {
            var vehicleViolations = await _dbContext.TempVehicleViolations.Where(x => x.VehicleID == VehicleID).ToListAsync();
            var vehicleViolationList = _mapper.Map<List<VehicleViolation>>(vehicleViolations);
            return vehicleViolationList;
        }
    }
}