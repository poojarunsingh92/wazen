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
    public class OccupationRepository : BaseRepository<ICOccupation>, IOccupationRepository
    {
        private readonly ILogger _logger;
        public OccupationRepository(ApplicationDbContext dbContext, ILogger<ICOccupation> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICOccupation>> GetOccupation()
        {
            var occupations = await _dbContext.ICOccupations.ToListAsync();
            return occupations;
        }
    }
}
