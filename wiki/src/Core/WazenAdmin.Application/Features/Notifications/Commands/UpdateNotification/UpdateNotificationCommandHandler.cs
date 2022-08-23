using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Notification.Commands.UpdateNotification
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, Response<Guid>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public UpdateNotificationCommandHandler(IMapper mapper, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {

            var notificationToUpdate = await _notificationRepository.GetByIdAsync(request.ID);

            if (notificationToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateNotificationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, notificationToUpdate, typeof(UpdateNotificationCommand), typeof(WazenAdmin.Domain.Entities.Notification));

            await _notificationRepository.UpdateAsync(notificationToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
