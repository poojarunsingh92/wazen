using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Contracts.Persistence
{
    public interface IInsuranceCompanyRepository : IAsyncRepository<InsuranceCompany>
    {
    }
}
