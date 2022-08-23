using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class ViolationTypeRepository : BaseRepository<ViolationType>, IViolationTypeRepository
    {
        ApplicationDbContext _db;
        public ViolationTypeRepository(ApplicationDbContext dbContext, ILogger<ViolationType> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}
