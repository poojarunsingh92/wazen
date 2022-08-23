using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class FAQRepository : BaseRepository<FAQ>, IFAQRepository
    {
        private readonly ILogger _logger;
        public FAQRepository(ApplicationDbContext dbContext, ILogger<FAQ> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<FAQ>> GetFaqByModule(string module)
        {
            return _dbContext.FAQs.Where(f => f.Module == module).ToList<FAQ>();
        }

    }
}
