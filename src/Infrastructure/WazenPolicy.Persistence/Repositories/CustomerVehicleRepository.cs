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
    public class CustomerVehicleRepository : BaseRepository<CustomerVehicle>, ICustomerVehicleRepository
    {

        private readonly ILogger _logger;
        public CustomerVehicleRepository(ApplicationDbContext dbContext, ILogger<CustomerVehicle> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<CustomerVehicle>> GetCustomerVehicleListByCustomerID(Guid CustomerID)
        {
            var customerVehicles = await _dbContext.CustomerVehicles.Where(x => x.CustomerID == CustomerID).ToListAsync();

            return customerVehicles;
        }
    }
}
