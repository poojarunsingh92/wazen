using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Features.Notifications.Queries.GetNotificationList;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Notifications.Queries.GetNotificationList
{
    public class NotificationListQueryHandler : IRequestHandler<NotificationListQuery, Response<IEnumerable<NotificationListVm>>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public NotificationListQueryHandler(IMapper mapper, INotificationRepository notificationRepository, ILogger<NotificationListQueryHandler> logger)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<NotificationListVm>>> Handle(NotificationListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allNotification = (await _notificationRepository.ListAllAsync()).OrderBy(x => x.ID);
            var notification = _mapper.Map<IEnumerable<NotificationListVm>>(allNotification);
            _logger.LogInformation("Handle Completed");
            if (notification == null)
            {
                var resposeObject = new Response<IEnumerable<NotificationListVm>>("No record is not available");
                return resposeObject;
            }
            return new Response<IEnumerable<NotificationListVm>>(notification, "success");
        }
    }
}
