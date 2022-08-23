using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
   public class SalutationRepository : BaseRepository<Salutation>, ISalutationRepository
    {
        ApplicationDbContext _db;
        public SalutationRepository(ApplicationDbContext dbContext, ILogger<Salutation> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }

}
