using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Contracts.Persistence
{
    public interface ITempVehicleRepository : IAsyncRepository<TempVehicle>
    {
        Task<IEnumerable<TempVehicle>> GetTempVehicleListByTempCustomerID(Guid TempCustomerID);
    }
}
