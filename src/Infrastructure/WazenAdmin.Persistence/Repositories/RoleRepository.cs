using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly ILogger _logger;
        public RoleRepository(ApplicationDbContext dbContext, ILogger<Role> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
