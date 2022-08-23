using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
   public class OccupationRepository : BaseRepository<Occupation>, IOccupationRepository
    {
        ApplicationDbContext _db;
        public OccupationRepository(ApplicationDbContext dbContext, ILogger<Occupation> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }

}
