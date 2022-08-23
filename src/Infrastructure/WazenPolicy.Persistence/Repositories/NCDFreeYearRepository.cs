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
    public class NCDFreeYearRepository : BaseRepository<ICNCDFreeYear>, INCDFreeYearRepository
    {
        private readonly ILogger _logger;
        public NCDFreeYearRepository(ApplicationDbContext dbContext, ILogger<ICNCDFreeYear> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICNCDFreeYear>> GetNCDFreeYear()
        {
            var ncdFreeYears = await _dbContext.ICNCDFreeYears.ToListAsync();
            return ncdFreeYears;
        }
    }
}
