using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class EducationRepository : BaseRepository<Education>, IEducationRepository
    {
        ApplicationDbContext _db;
        public EducationRepository(ApplicationDbContext dbContext, ILogger<Education> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}
