using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext dbContext, ILogger<Customer> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

    }
}
