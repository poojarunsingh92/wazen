using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Contracts.Persistence
{
    public interface IPolicyTypeRepository : IAsyncRepository<PolicyType>
    {
        Task<PolicyType> GetPolicyTypeByDescription(string Description);
    }
}
