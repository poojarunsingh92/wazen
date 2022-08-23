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
    public class MaritalStatusRepository : BaseRepository<ICMaritalStatus>, IMaritalStatusRepository
    {
        private readonly ILogger _logger;
        public MaritalStatusRepository(ApplicationDbContext dbContext, ILogger<ICMaritalStatus> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICMaritalStatus>> GetMaritalStatus()
        {
            var maritalStatus = await _dbContext.ICMaritalStatus.ToListAsync();
            return maritalStatus;
        }
    }
}
