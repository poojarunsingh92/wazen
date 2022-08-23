using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByCustomerId;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
   public interface IVehicleRepository : IAsyncRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetVehicleListByCustomerID(Guid CustomerID);
        List<VehicleByCustomerIdVm> GetVehiclesByCustomerID(Guid CustomerID);
        Task<Vehicle> GetVehicleBySequenceNumberAndCustomerID(string SequenceNumber, Guid CustomerID);
        IEnumerable<GetAllListVM> GetVehicleDriverVehicleViolationListByCustomerId(Guid Customerid);
    }
}
