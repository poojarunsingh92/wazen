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
    public class ViolationTypeRepository : BaseRepository<ViolationType>, IViolationTypeRepository
    {

        private readonly ILogger _logger;
        public ViolationTypeRepository(ApplicationDbContext dbContext, ILogger<ViolationType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
