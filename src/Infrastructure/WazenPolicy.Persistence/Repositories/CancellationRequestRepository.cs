using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class CancellationRequestRepository : BaseRepository<CancellationRequest>, ICancellationRequestRepository
    {

        private readonly ILogger _logger;
        public CancellationRequestRepository(ApplicationDbContext dbContext, ILogger<CancellationRequest> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
