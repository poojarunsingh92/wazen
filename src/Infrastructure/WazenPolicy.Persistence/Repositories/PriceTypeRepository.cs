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
    public class PriceTypeRepository : BaseRepository<ICPriceType>, IPriceTypeRepository
    {
        private readonly ILogger _logger;
        public PriceTypeRepository(ApplicationDbContext dbContext, ILogger<ICPriceType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICPriceType>> GetPriceType()
        {
            var priceTypes = await _dbContext.ICPriceTypes.ToListAsync();
            return priceTypes;
        }
    }
}
