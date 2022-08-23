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
    public class PlateLetterRepository : BaseRepository<ICPlateLetter>, IPlateLetterRepository
    {
        private readonly ILogger _logger;
        public PlateLetterRepository(ApplicationDbContext dbContext, ILogger<ICPlateLetter> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICPlateLetter>> GetPlateLetter()
        {
            var plateLetters = await _dbContext.ICPlateLetters.ToListAsync();
            return plateLetters;
        }
    }
}
