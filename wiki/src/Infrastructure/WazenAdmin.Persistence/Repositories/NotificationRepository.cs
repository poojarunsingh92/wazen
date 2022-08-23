using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        private readonly ILogger _logger;
        public NotificationRepository(ApplicationDbContext dbContext, ILogger<Notification> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
