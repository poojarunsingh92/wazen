using WazenAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Contracts.Persistence
{
    public interface IComplaintRepository : IAsyncRepository<Complaint>
    {
        Task<Complaint> GetComplaintByCustomerIDAsync(Guid CustomerID);
        Task<IEnumerable<Complaint>> GetComplaintByCustomerIDListAsync(Guid CustomerID);
    }
}
