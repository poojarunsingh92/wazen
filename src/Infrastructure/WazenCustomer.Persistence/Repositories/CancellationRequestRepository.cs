using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Persistence.Repositories
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
