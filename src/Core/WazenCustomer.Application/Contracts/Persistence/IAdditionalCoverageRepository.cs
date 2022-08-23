using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
   public interface IAdditionalCoverageRepository : IAsyncRepository<CustomerPolicyAdditionalCoverage>
    {
        Task<CustomerPolicyAdditionalCoverage> GetAdditionalCoverageByPolicyID(Guid PolicyID);
    }
}