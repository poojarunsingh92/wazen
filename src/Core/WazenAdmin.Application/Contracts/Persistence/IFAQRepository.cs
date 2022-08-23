using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Contracts.Persistence
{
    public interface IFAQRepository : IAsyncRepository<FAQ>
    {
        Task<List<FAQ>> GetFaqByModule(string module);
    }
}
