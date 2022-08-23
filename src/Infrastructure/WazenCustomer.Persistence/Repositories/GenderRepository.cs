using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        ApplicationDbContext _db;
        public GenderRepository(ApplicationDbContext dbContext, ILogger<Gender> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}


