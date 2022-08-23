using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Notification.Commands.DeleteNotification
{
    public class DeleteNotificationCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
