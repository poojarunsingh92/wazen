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
    public class EducationRepository : BaseRepository<ICEducation>, IEducationRepository
    {
        private readonly ILogger _logger;
        public EducationRepository(ApplicationDbContext dbContext, ILogger<ICEducation> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICEducation>> GetEducation()
        {
            var educations = await _dbContext.ICEducations.ToListAsync();
            return educations;
        }
    }
}
