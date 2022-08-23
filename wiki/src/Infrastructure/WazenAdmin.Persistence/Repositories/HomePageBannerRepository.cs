using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class HomePageBannerRepository : BaseRepository<HomePageBanner>, IHomePageBannerRepository
    {
        private readonly ILogger _logger;
        public HomePageBannerRepository(ApplicationDbContext dbContext, ILogger<HomePageBanner> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
