using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class TempCustomerRepository : BaseRepository<TempCustomer>, ITempCustomerRepository
    {

        private readonly ILogger _logger;
        public TempCustomerRepository(ApplicationDbContext dbContext, ILogger<TempCustomer> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
