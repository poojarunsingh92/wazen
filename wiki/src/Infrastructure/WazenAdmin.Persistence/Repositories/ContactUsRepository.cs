using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
   public class ContactUsRepository : BaseRepository<ContactUs>, IContactUsRepository
    {
        private readonly ILogger _logger;
        public ContactUsRepository(ApplicationDbContext dbContext, ILogger<ContactUs> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
