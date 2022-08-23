using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
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
