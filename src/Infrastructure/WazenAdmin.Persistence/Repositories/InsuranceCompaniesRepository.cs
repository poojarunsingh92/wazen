using Microsoft.Extensions.Logging;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{ 
    public class InsuranceCompaniesRepository : BaseRepository<InsuranceCompany>,IInsuranceCompaniesRepository
    {
        private readonly ILogger _logger;
        public InsuranceCompaniesRepository(ApplicationDbContext dbContext, ILogger<InsuranceCompany> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
