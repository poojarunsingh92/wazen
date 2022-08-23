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
    public class CitiesRepository : BaseRepository<ICCities>, ICitiesRepository
    {
        private readonly ILogger _logger;
        public CitiesRepository(ApplicationDbContext dbContext, ILogger<ICCities> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICCities>> GetCities()
        {
            var cities = await _dbContext.ICCities.ToListAsync();
            return cities;
        }
    }
}
