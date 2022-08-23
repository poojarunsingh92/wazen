using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Notification.Commands.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand>
    {
        private readonly INotificationRepository _notificationRepository;

        public DeleteNotificationCommandHandler(INotificationRepository notificationRepository, IDataProtectionProvider provider)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {

            var notificationToDelete = await _notificationRepository.GetByIdAsync(request.ID);

            if (notificationToDelete == null)
            {
                throw new NotFoundException(nameof(WazenAdmin.Domain.Entities.Notification), request.ID);
            }

            await _notificationRepository.DeleteAsync(notificationToDelete);
            return Unit.Value;
        }
    }
}
