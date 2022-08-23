using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
   public class CustomerVehicleRepository : BaseRepository<CustomerVehicle>, ICustomerVehicleRepository
    {

        ApplicationDbContext _db;
        public CustomerVehicleRepository(ApplicationDbContext dbContext, ILogger<CustomerVehicle> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<CustomerVehicle>> GetCustomerVehicleListByCustomerID(Guid CustomerID)
        {
            var customerVehicles = await _dbContext.CustomerVehicles.Where(x => x.CustomerID == CustomerID).ToListAsync();

            return customerVehicles;
        }
    }

}
