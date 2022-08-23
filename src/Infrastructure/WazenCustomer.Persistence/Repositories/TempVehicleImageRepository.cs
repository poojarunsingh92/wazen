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
    public class TempVehicleImageRepository : BaseRepository<TempVehicleImage>, ITempVehicleImageRepository
    {
        private readonly ILogger _logger;
        public TempVehicleImageRepository(ApplicationDbContext dbContext, ILogger<TempVehicleImage> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
