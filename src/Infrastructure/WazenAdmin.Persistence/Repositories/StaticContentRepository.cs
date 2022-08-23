using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class StaticContentRepository : BaseRepository<StaticContent>, IStaticContentRepository
    {
        private readonly ILogger _logger;
        public StaticContentRepository(ApplicationDbContext dbContext, ILogger<StaticContent> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
