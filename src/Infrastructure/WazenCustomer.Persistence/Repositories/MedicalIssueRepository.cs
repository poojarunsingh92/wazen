using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class MedicalIssueRepository : BaseRepository<MedicalIssue>, IMedicalIssueRepository
    {
        ApplicationDbContext _db;
        public MedicalIssueRepository(ApplicationDbContext dbContext, ILogger<MedicalIssue> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}
