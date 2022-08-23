using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class MaritalStatusRepository : BaseRepository<MaritalStatus>, IMaritalStatusRepository
    {
        ApplicationDbContext _db;
        public MaritalStatusRepository(ApplicationDbContext dbContext, ILogger<MaritalStatus> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }

}
