using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
  public  class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ILogger _logger;
        public CustomerRepository(ApplicationDbContext dbContext, ILogger<Customer> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<Customer> GetCustomerByNIN(string NIN)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.NIN == NIN);
            return customer;
        }

        public async Task<Customer> GetCustomerByNINAndDOB(string NIN, DateTime DateOfBirth)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.NIN == NIN && x.DateOfBirth==DateOfBirth);
            return customer;
        }
    }
}
