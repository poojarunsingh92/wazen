using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {

        private readonly ILogger _logger;
        public VehicleRepository(ApplicationDbContext dbContext, ILogger<Vehicle> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        
    }
}
