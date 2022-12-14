using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class VehicleViolationRepository : BaseRepository<VehicleViolation>, IVehicleViolationRepository
    {
        ApplicationDbContext _db;
        public VehicleViolationRepository(ApplicationDbContext dbContext, ILogger<VehicleViolation> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}