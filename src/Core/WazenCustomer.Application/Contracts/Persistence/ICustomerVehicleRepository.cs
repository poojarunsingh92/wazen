using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface ICustomerVehicleRepository : IAsyncRepository<CustomerVehicle>
    {
        Task<IEnumerable<CustomerVehicle>> GetCustomerVehicleListByCustomerID(Guid CustomerID);    
    }
}