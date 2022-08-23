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
    public class GenderRepository : BaseRepository<ICGender>, IGenderRepository
    {
        private readonly ILogger _logger;
        public GenderRepository(ApplicationDbContext dbContext, ILogger<ICGender> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICGender>> GetGender()
        {
            var Genders = await _dbContext.ICGenders.ToListAsync();
            return Genders;
        }
    }
}
