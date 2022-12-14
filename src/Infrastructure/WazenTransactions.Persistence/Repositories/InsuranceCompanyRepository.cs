using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
{
  public  class InsuranceCompanyRepository :
          BaseRepository<InsuranceCompany>, IInsuranceCompanyRepository
    {
        ApplicationDbContext _db;
    public InsuranceCompanyRepository(ApplicationDbContext dbContext, ILogger<InsuranceCompany> logger) : base(dbContext, logger)
    {
        _db = dbContext;
    }


}

   
}
