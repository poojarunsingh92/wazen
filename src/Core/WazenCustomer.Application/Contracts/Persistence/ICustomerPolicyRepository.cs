using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface ICustomerPolicyRepository : IAsyncRepository<CustomerPolicy>
    {
        Task<CustomerPolicy> GetCustomerPolicyByCustomerVehicleID(Guid CustomerVehicleID);

        Task<List<CustomerPolicy>> GetAdditionalCoverage(Guid Id);
        Task<CustomerPolicy> GetCustomerPolicyByVehicleID(Guid CustomerID);
        Task<CustomerPolicy> GetCustomerPolicyByVehicleIDTransactionID(Guid CustomerVehicleID, Guid TransactionID);
    }
}