using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Contracts.Persistence
{
    public interface IVehicleViolationRepository : IAsyncRepository<VehicleViolation>
    {
        public Task<VehicleViolation> GetVehicleViolationDetailByVehicleID(Guid VehicleID);
        public Task<List<VehicleViolation>> GetVehicleViolationListByVehicleID(Guid VehicleID);
    }
}
