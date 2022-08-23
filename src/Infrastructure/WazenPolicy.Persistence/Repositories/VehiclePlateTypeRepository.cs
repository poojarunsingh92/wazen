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
    public class VehiclePlateTypeRepository : BaseRepository<ICVehiclePlateType>, IVehiclePlateTypeRepository
    {
        private readonly ILogger _logger;
        public VehiclePlateTypeRepository(ApplicationDbContext dbContext, ILogger<ICVehiclePlateType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICVehiclePlateType>> GetVehiclePlateType()
        {
            var vehiclePlateTypes = await _dbContext.ICVehiclePlateTypes.ToListAsync();
            return vehiclePlateTypes;
        }
    }
}
