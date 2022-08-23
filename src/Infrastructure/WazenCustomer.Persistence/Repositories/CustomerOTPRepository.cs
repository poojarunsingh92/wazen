using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Persistence.Repositories
{
    public class CustomerOTPRepository : BaseRepository<CustomerOTP>, ICustomerOTPRepository
    {
        ApplicationDbContext _db;
        public CustomerOTPRepository(ApplicationDbContext dbContext, ILogger<CustomerOTP> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}
