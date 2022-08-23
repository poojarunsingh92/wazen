using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Contracts.Persistence
{
    public interface ICustomerPolicyRepository : IAsyncRepository<CustomerPolicy>
    {
        Task<CustomerPolicy> GetExistingCustomerPolicyAsync(Guid CustomerVehicleID);
        Task<CustomerPolicy> GetByCustomerVehicleIDPolicyNameAsync(Guid CustomerVehicleID, string PolicyName);
        Task<CustomerPolicy> GetCustomerPolicyByCustomerVehicleID(Guid CustomerVehicleID);
    }
}
