using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Contracts.Persistence
{
    public interface ICustomerPolicyRepository : IAsyncRepository<CustomerPolicy>
    {
        Task<CustomerPolicy> GetCustomerPolicyByVehicleID(Guid VehicleID);
        Task<IEnumerable<CustomerPolicy>> GetCustomerPolicyListByCustomerID(Guid CustomerID);
    }
}
