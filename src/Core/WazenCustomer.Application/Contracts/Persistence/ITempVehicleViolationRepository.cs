using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface ITempVehicleViolationRepository : IAsyncRepository<TempVehicleViolation>
    {
        Task<IEnumerable<TempVehicleViolation>> GetTempVehicleViolationsByVehicleID(Guid VehicleID);
    }
}