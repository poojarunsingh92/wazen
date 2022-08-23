using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Notifications.Queries.GetNotificationList
{
   public class NotificationListQuery : IRequest<Response<IEnumerable<NotificationListVm>>>
    {
        public Guid ID { get; set; }
       
    }
}
