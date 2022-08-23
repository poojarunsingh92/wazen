using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Notifications.Queries.GetNotificationDetail
{
    public class GetNotificationDetailQuery: IRequest<Response<NotificationDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
