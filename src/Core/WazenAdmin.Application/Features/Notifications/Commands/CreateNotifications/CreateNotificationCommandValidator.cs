using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Notifications.Commands.CreateNotifications
{
    public class CreateNotificationCommandValidator: AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationCommandValidator()
        {

        }
    }
}
