using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Contracts.Persistence
{
    public interface ITempVehicleViolationRepository : IAsyncRepository<VehicleViolation>
    {
        public Task<VehicleViolation> GetTempVehicleViolationDetailByVehicleID(Guid VehicleID);
        public Task<List<VehicleViolation>> GetTempVehicleViolationListByVehicleID(Guid VehicleID);
    }
}