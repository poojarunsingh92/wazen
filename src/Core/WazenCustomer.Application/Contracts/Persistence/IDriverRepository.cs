using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetDriverVehicleViolationDetailsByVehicleId;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface IDriverRepository : IAsyncRepository<Driver>
    {
        public Task<Driver> GetDriverByVehicleID(Guid VehicleID);
        List<GetDriverVehicleViolationDetailsByVehicleIdVm> GetDriverListByVehicleId(Guid VehicleId);
        //List<GetDriverVehicleViolationByVehicleIdVm> GetDriverListByVehicleId(Guid VehicleId);        
    }
}