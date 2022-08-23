using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WazenTransactions.Persistence.Repositories
{
   public class CustomerVehicleRepository : BaseRepository<Vehicle>, ICustomerVehicleRepository
    {
        ApplicationDbContext _db;
        public CustomerVehicleRepository(ApplicationDbContext dbContext, ILogger<Vehicle> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
        protected override IQueryable<Vehicle> GetQueryable()
        {
            return _db.Set<Vehicle>()
                    .Include(x => x.Customer);
        }
    }
}
    
