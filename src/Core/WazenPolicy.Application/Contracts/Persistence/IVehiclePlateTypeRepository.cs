using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Contracts.Persistence
{
    public interface IVehiclePlateTypeRepository : IAsyncRepository<ICVehiclePlateType>
    {
        Task<List<ICVehiclePlateType>> GetVehiclePlateType();
    }
}
