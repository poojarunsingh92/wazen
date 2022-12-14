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
    public class ViolationRepository : BaseRepository<ICViolation>, IViolationRepository
    {
        private readonly ILogger _logger;
        public ViolationRepository(ApplicationDbContext dbContext, ILogger<ICViolation> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICViolation>> GetViolation()
        {
            var violations = await _dbContext.ICViolations.ToListAsync();
            return violations;
        }
    }
}
