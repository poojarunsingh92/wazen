using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
{
  public class CancellationRequestRepository : BaseRepository<CancellationRequest>, ICancellationRequestRepository
    {
        ApplicationDbContext _db;
        public CancellationRequestRepository(ApplicationDbContext dbContext, ILogger<CancellationRequest> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}
