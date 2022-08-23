using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Notifications.Queries.GetNotificationDetail
{
   public  class GetNotificationDetailQueryHandler : IRequestHandler<GetNotificationDetailQuery, Response<NotificationDetailVm>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetNotificationDetailQueryHandler(IMapper mapper, INotificationRepository notificationRepository, ILogger<GetNotificationDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;            
        }
        public async Task<Response<NotificationDetailVm>> Handle(GetNotificationDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _notificationRepository.GetByIdAsync(request.ID);
            if (user == null)
            {
                var resposeObject = new Response<NotificationDetailVm>(request.ID + " is not available");
                return resposeObject;
            }

            var userDetailDto = _mapper.Map<NotificationDetailVm>(user);

            var response = new Response<NotificationDetailVm>(userDetailDto, "success");
            return response;
        }
    }
}
