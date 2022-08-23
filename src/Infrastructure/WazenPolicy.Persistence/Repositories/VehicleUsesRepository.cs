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
    class VehicleUsesRepository : BaseRepository<ICVehicleUses>, IVehicleUsesRepository
    {
        private readonly ILogger _logger;
        public VehicleUsesRepository(ApplicationDbContext dbContext, ILogger<ICVehicleUses> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICVehicleUses>> GetVehicleUses()
        {
            var vehicleeUses = await _dbContext.ICVehicleUses.ToListAsync();
            return vehicleeUses;
        }
    }
}
