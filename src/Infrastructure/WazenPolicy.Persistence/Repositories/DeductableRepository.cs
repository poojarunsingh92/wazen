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
    class DeductableRepository : BaseRepository<ICDeductable>, IDeductableRepository
    {
        private readonly ILogger _logger;
        public DeductableRepository(ApplicationDbContext dbContext, ILogger<ICDeductable> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICDeductable>> GetDeductable()
        {
            var additionalCovers = await _dbContext.ICDeductables.ToListAsync();
            return additionalCovers;
        }
    }
}
