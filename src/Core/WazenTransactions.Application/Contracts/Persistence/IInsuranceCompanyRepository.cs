using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Contracts.Persistence
{
  public  interface IInsuranceCompanyRepository : IAsyncRepository<InsuranceCompany>
    {
    }
}
