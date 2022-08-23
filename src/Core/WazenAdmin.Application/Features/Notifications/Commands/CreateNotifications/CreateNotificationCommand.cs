using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Notifications.Commands.CreateNotifications
{
   public class CreateNotificationCommand: IRequest<Response<CreateNotificationDto>>
    {
       // public Guid ID { get; set; }
        public string NotficationTitle { get; set; }
        public string TypeofNotification { get; set; }
        public string Language { get; set; }
        public DateTime NotificationSentDate { get; set; }
        public string EntityType { get; set; }
        public string ContentoftheNotificationInEnglish { get; set; }
        public string ContentoftheNotificationInArabic { get; set; }
        public string TypeOfProduct { get; set; }
        public string Events { get; set; }
        public DateTime TriggerNotificationAt { get; set; }
        public DateTime RecurringTillDate { get; set; }
        public Boolean Status { get; set; }
    }
}
