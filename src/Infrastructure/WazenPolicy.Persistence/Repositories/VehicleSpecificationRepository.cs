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
    public class VehicleSpecificationRepository : BaseRepository<ICVehicleSpecificationn>, IVehicleSpecificationRepository
    {
        private readonly ILogger _logger;
        public VehicleSpecificationRepository(ApplicationDbContext dbContext, ILogger<ICVehicleSpecificationn> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICVehicleSpecificationn>> GetVehicleSpecification()
        {
            var vehicleSpecifications = await _dbContext.ICVehicleSpecifications.ToListAsync();
            return vehicleSpecifications;
        }
    }
}
