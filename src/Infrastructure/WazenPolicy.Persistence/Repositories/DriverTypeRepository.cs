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
    public class DriverTypeRepository : BaseRepository<ICDriverType>, IDriverTypeRepository
    {
        private readonly ILogger _logger;
        public DriverTypeRepository(ApplicationDbContext dbContext, ILogger<ICDriverType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICDriverType>> GetDriverType()

        {
            var driverTypes = await _dbContext.ICDriverTypes.ToListAsync();
            return driverTypes;
        }
    }
}
