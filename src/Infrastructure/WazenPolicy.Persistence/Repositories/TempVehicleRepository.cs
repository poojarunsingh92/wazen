using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class TempVehicleRepository : BaseRepository<TempVehicle>, ITempVehicleRepository
    {

        private readonly ILogger _logger;
        public TempVehicleRepository(ApplicationDbContext dbContext, ILogger<TempVehicle> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
