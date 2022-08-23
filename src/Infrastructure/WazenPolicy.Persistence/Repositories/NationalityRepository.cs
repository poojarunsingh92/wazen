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
    public class NationalityRepository : BaseRepository<ICNationality>, INationalityRepository
    {
        private readonly ILogger _logger;
        public NationalityRepository(ApplicationDbContext dbContext, ILogger<ICNationality> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICNationality>> GetNationality()
        {
            var nationalities = await _dbContext.ICNationalities.ToListAsync();
            return nationalities;
        }
    }
}
