using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
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
