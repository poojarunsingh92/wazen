using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class VehiclePurposeRepository : BaseRepository<VehiclePurpose>, IVehiclePurposeRepository
    {
        ApplicationDbContext _db;
        public VehiclePurposeRepository(ApplicationDbContext dbContext, ILogger<VehiclePurpose> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }
    }
}
