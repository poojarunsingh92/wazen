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
    public class CancellationRequestRepository : BaseRepository<CancellationRequest>, ICancellationRequestRepository
    {
        private readonly ILogger _logger;
        public CancellationRequestRepository(ApplicationDbContext dbContext, ILogger<CancellationRequest> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<CancellationRequest> GetCancellationRequestByPolicyID(Guid PolicyID)
        {
            var cancellationRequest = _dbContext.CancellationRequests.FirstOrDefault(x => x.PolicyID == PolicyID);
            return cancellationRequest;
        }
    }
}
