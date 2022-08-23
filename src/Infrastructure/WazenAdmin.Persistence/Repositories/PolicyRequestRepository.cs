using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
   public class PolicyRequestRepository : BaseRepository<PolicyRequest>, IPolicyRequestRepository
    {
        private readonly ILogger _logger;
        public PolicyRequestRepository(ApplicationDbContext dbContext, ILogger<PolicyRequest> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
