using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class TempCustomerRepository : BaseRepository<TempCustomer>, ITempCustomerRepository
    {
        ApplicationDbContext _db;
        public TempCustomerRepository(ApplicationDbContext dbContext, ILogger<TempCustomer> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

        public async Task<TempCustomer> GetQuoteByNINAndDOB(string NIN, DateTime DateOfBirth)
        {
            var tempCustomer = _dbContext.TempCustomers.FirstOrDefault(x => x.NIN == NIN && x.DateOfBirth == DateOfBirth);
            return tempCustomer;
        }

        public async Task<TempCustomer> GetQuoteByVerifyCode(Guid CustomerId, string VerifyCode)
        {
            var customerQuote = _dbContext.TempCustomers.FirstOrDefault(x => x.ID == CustomerId && x.VerifyCode == VerifyCode);
            return customerQuote;
        }

        public async Task<TempCustomer> GetTempCustomerByNIN(string NIN)
        {
            var customerQuote = _dbContext.TempCustomers.FirstOrDefault(x => x.NIN == NIN);
            return customerQuote;
        }

        public async Task<TempCustomer> GetTempCustomerByNINAndMobile(string NIN, string Mobile)
        {
            var tempCustomer = _dbContext.TempCustomers.FirstOrDefault(x => x.NIN == NIN && x.Mobile == Mobile);
            return tempCustomer;
        }

        public async Task<TempCustomer> GetTempCustomerByEmailVerifyCode(string Email, string VerifyCode)
        {
            var tempCustomer = _dbContext.TempCustomers.FirstOrDefault(x => x.Email == Email && x.VerifyCode == VerifyCode);
            return tempCustomer;
        }
    }
}
