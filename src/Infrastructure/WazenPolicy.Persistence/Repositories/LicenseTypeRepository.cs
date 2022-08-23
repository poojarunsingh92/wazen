﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Persistence.Repositories
{
    public class LicenseTypeRepository : BaseRepository<ICLicenseType>, ILicenseTypeRepository
    {
        private readonly ILogger _logger;
        public LicenseTypeRepository(ApplicationDbContext dbContext, ILogger<ICLicenseType> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<ICLicenseType>> GetLicenseType()
        {
            var licenseTypes = await _dbContext.ICLicenseTypes.ToListAsync();
            return licenseTypes;
        }
    }
}
