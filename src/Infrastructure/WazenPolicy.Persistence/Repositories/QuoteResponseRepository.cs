using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Wazen.Domain.Entities;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class QuoteResponseRepository : BaseRepository<InsuranceCompanyQuoteResponse>, IQuoteResponseRepository
    {

        private readonly ILogger _logger;
        public QuoteResponseRepository(ApplicationDbContext dbContext, ILogger<InsuranceCompanyQuoteResponse> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
