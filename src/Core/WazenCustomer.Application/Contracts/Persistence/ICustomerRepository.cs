using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        bool CheckCustomerExistWithMobileNumber(string mobile);
        Task<Customer> GetCustomerByNINAndDOB(string NIN, DateTime DateOfBirth);
        Task<Customer> GetCustomerByNIN(string NIN);
        Task<Customer> GetCustomerByUserId(Guid UserId);
        Task<Customer> GetCustomerByNINAndMobile(string NIN, string Mobile); //Added
        Task<Customer> GetCustomerByCustomerID(Guid CustomerID);
        Task<Customer> GetQuoteByVerifyCode(Guid CustomerId, string VerifyCode);
        Task<Customer> GetCustomerByEmail(string Email);
        Task<Customer> GetCustomerByEmailVerifyCode(string Email, string VerifyCode);
    }
}