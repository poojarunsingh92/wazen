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
    public class VehicleAxlesWeightRepository : BaseRepository<ICVehicleAxlesWeight>, IVehicleAxlesWeightRepository
    {
        private readonly ILogger _logger;
        public VehicleAxlesWeightRepository(ApplicationDbContext dbContext, ILogger<ICVehicleAxlesWeight> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICVehicleAxlesWeight>> GetVehicleAxlesWeight()
        {
            var vehicleAxlesWeights= await _dbContext.ICVehicleAxlesWeights.ToListAsync();
            return vehicleAxlesWeights;
        }
    }
}
