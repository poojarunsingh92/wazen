using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class AboutUsRepository : BaseRepository<AboutUs>, IAboutUsRepository
    {
        private readonly ILogger _logger;
        public AboutUsRepository(ApplicationDbContext dbContext, ILogger<AboutUs> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
