using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetVehiclePolicyListByCustomerID;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Contracts.Persistence
{
  public  interface IVehicleRepository : IAsyncRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetVehicleListByCustomerID(Guid CustomerID);
        List<VehicleInformations> GetVehiclePolicyCoverByCustomerID(Guid CustomerID);
    }
}
