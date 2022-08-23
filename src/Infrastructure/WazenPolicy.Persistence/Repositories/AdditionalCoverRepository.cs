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
    public class AdditionalCoverRepository : BaseRepository<ICAdditionalCoverr>, IAdditionalCoverRepository
    {
        private readonly ILogger _logger;
        public AdditionalCoverRepository(ApplicationDbContext dbContext, ILogger<ICAdditionalCoverr> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICAdditionalCoverr>> GetAdditionalCover()
        {
            var additionalCovers = await _dbContext.ICAdditionalCovers.ToListAsync();
            return additionalCovers;
        }
    }
}
