using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<Customer> GetCustomerByNIN(string NIN);
        Task<Customer> GetCustomerByNINAndDOB(string NIN, DateTime DateOfBirth);
    }
}
