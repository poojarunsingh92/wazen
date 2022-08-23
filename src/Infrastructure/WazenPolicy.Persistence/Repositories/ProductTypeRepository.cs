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
    public class ProductTypeRepository : BaseRepository<ICProductType>, IProductTypeRepository
    {
        private readonly ILogger _logger;
        public ProductTypeRepository(ApplicationDbContext dbContext, ILogger<ICProductType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICProductType>> GetProductType()
        {
            var productTypes = await _dbContext.ICProductTypes.ToListAsync();
            return productTypes;
        }
    }
}
