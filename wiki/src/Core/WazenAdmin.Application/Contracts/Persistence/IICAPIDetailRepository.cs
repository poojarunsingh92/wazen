using WazenAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Application.Responses;
using WazenAdmin.Application.Contracts.Persistence;

namespace WazenAdmin.Application.Contracts.Persistence
{
    public interface IICAPIDetailRepository : IAsyncRepository<ICAPIDetail>
    {
        Task<ICAPIDetail> GetICAPIDetailsByICIDAsync(Guid ICID);
        Task<IEnumerable<ICAPIDetail>> ListAllByICIDAsync(Guid ICID);


        //Task<IEnumerable<ICAPIDetailsListByICIDVm>> ListAllByICIDAsync(Guid ICID);
        //IEnumerable<IReadOnlyList<T>> ListAllAsyncByICID(Guid icid);
    }
}
