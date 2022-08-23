using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Contracts.Persistence
{
    public interface INationalityRepository : IAsyncRepository<ICNationality>
    {
        Task<List<ICNationality>> GetNationality();
    }
}
