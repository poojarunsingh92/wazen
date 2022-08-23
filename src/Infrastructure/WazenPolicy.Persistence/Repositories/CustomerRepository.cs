using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        private readonly ILogger _logger;
        public CustomerRepository(ApplicationDbContext dbContext, ILogger<Customer> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
