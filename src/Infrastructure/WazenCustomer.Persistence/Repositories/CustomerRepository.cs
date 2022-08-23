using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using System.Linq;
namespace WazenCustomer.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext dbContext, ILogger<Customer> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

        public  bool CheckCustomerExistWithMobileNumber(string mobile)
        {
            var data =  _dbContext.Customers.Where(x => x.Mobile == mobile).FirstOrDefault(x => x.Mobile == mobile);
            if (data!=null)
            {
                return true;
            }
            return false;
        }

        public async Task<Customer> GetCustomerByNINAndDOB(string NIN, DateTime DateOfBirth)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.NIN == NIN && x.DateOfBirth == DateOfBirth);
            return customer;
        }

        public async Task<Customer> GetCustomerByNIN(string NIN)
        {
            var customerQuote = _dbContext.Customers.FirstOrDefault(x => x.NIN == NIN);
            return customerQuote;
        }
       

        public async Task<Customer> GetCustomerByUserId(Guid UserId)
        {
            var customerQuote = _dbContext.Customers.FirstOrDefault(x => x.userId == UserId);
            return customerQuote;
        }
        public async Task<Customer> GetCustomerByNINAndMobile(string NIN, string Mobile)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.NIN == NIN && x.Mobile == Mobile);
            return customer;
        }

        public async Task<Customer> GetCustomerByCustomerID(Guid CustomerID)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.ID==CustomerID);
            return customer;
        }

        public async Task<Customer> GetQuoteByVerifyCode(Guid CustomerId, string VerifyCode)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.ID == CustomerId && x.VerifyCode == VerifyCode);
            return customer;
        }

        public async Task<Customer> GetCustomerByEmail(string Email)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == Email);
            return customer;
        }

        public async Task<Customer> GetCustomerByEmailVerifyCode(string Email, string VerifyCode)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == Email && x.VerifyCode==VerifyCode);
            return customer;
        }
    }
}
