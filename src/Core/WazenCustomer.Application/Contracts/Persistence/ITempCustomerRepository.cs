using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface ITempCustomerRepository : IAsyncRepository<TempCustomer>
    {
        Task<TempCustomer> GetQuoteByNINAndDOB(string NIN, DateTime DateOfBirth);
        Task<TempCustomer> GetQuoteByVerifyCode(Guid CustomerId, string VerifyCode);
        Task<TempCustomer> GetTempCustomerByNIN(string NIN);
        Task<TempCustomer> GetTempCustomerByNINAndMobile(string NIN, string Mobile); //Added
        Task<TempCustomer> GetTempCustomerByEmailVerifyCode(string Email, string VerifyCode);
    }
}