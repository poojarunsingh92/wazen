using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class TermsAndConditionsRepository : BaseRepository<TermsAndConditions>, ITermsAndConditionsRepository
    {
        private readonly ILogger _logger;
        public TermsAndConditionsRepository(ApplicationDbContext dbContext, ILogger<TermsAndConditions> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
