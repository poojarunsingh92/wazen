using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetRenewCustomerPolicyListByCustomerID;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Contracts.Persistence
{
    public interface ICustomerPolicyRepository : IAsyncRepository<CustomerPolicy>
    {
        Task<CustomerPolicy> GetCustomerPolicyByCustomerVehicleID(Guid CustomerVehicleID);
        Task<IEnumerable<CustomerPolicy>> GetCustomerPolicyListByCustomerIDPolicyType(Guid CustomerID, int PolicyType);
        Task<IEnumerable<RenewCustomerPolicyListByCustomerIDVm>> GetCustomerVehiclePolicyListByCustomerID(Guid CustomerID);
    }
}
