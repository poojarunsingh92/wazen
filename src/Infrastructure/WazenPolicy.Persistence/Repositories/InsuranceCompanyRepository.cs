using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class InsuranceCompanyRepository : BaseRepository<InsuranceCompany>, IInsuranceCompanyRepository
    {
        private readonly ILogger _logger;
        public InsuranceCompanyRepository(ApplicationDbContext dbContext, ILogger<InsuranceCompany> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
