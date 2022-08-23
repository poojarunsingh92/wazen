using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Notifications.Commands.CreateNotifications
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Response<CreateNotificationDto>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(IMapper mapper, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }
        public async Task<Response<CreateNotificationDto>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var createNotificationCommandResponse = new Response<CreateNotificationDto>();

            var validator = new CreateNotificationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createNotificationCommandResponse.Succeeded = false;
                createNotificationCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createNotificationCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var notification = new WazenAdmin.Domain.Entities.Notification()
                {
                    NotficationTitle = request.NotficationTitle,
                    TypeofNotification = request.TypeofNotification,
                    Language = request.Language,
                    NotificationSentDate = request.NotificationSentDate,
                    EntityType = request.EntityType,
                    ContentoftheNotificationInEnglish = request.ContentoftheNotificationInEnglish,
                    ContentoftheNotificationInArabic = request.ContentoftheNotificationInArabic,
                    TypeOfProduct = request.TypeOfProduct,
                    Events = request.Events,
                    TriggerNotificationAt = request.TriggerNotificationAt,
                    RecurringTillDate = request.RecurringTillDate,
                    Status = request.Status
                };

                notification = await _notificationRepository.AddAsync(notification);
                createNotificationCommandResponse.Data = _mapper.Map<CreateNotificationDto>(notification);
                createNotificationCommandResponse.Succeeded = true;
                createNotificationCommandResponse.Message = "success";
            }

            return createNotificationCommandResponse;
        }
    }
}