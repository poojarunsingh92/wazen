using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetDriverVehicleViolationDetailsByVehicleId;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface ITempDriverRepository : IAsyncRepository<TempDriver>
    {
        List<GetDriverVehicleViolationDetailsByVehicleIdVm> GetDriverListByVehicleId(Guid VehicleId);
        Task<TempDriver> GetTempDriverByVehicleID(Guid VehicleId);     
        Task<TempDriver> GetTempDriverByVehicleId(Guid VehicleId);        
    }
}