using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
   public class NationalIdTypeRepository : BaseRepository<NationalIdType>, INationalIdTypeRepository
    {
        ApplicationDbContext _db;
        public NationalIdTypeRepository(ApplicationDbContext dbContext, ILogger<NationalIdType> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }

}
