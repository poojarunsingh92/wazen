using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.Notification.Commands.DeleteNotification;
using WazenAdmin.Application.Features.Notification.Commands.UpdateNotification;
using WazenAdmin.Application.Features.Notifications.Commands.CreateNotifications;
using WazenAdmin.Application.Features.Notifications.Queries.GetNotificationDetail;
using WazenAdmin.Application.Features.Notifications.Queries.GetNotificationList;

namespace WazenAdmin.Api.Controllers.v1
{
    //[Authorize(Roles = "IC ADMIN")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public NotificationController(IMediator mediator, ILogger<NotificationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("all", Name = "GetAllNotifications")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllNotifications()
        {
            _logger.LogInformation("GetAllNotifications Initiated");
            var dtos = await _mediator.Send(new NotificationListQuery());
            _logger.LogInformation("GetAllNotifications Completed");
            return Ok(dtos);
        }

        [HttpPost(Name = "AddNotification")]
        public async Task<ActionResult> Create([FromBody] CreateNotificationCommand createNotificationCommand)
        {
            _logger.LogInformation("AddNotification Initiated");
            var response = await _mediator.Send(createNotificationCommand);
            //var response1 = await _mediator.Send(createCustomerVehicleCommand);
            _logger.LogInformation("AddNotification Completed");
            return Ok(response);

        }

        [HttpGet("{ID}", Name = "GetNotificationByID")]
        public async Task<ActionResult> GetNotificationById(Guid ID)
        {
            var getNotifictionDetailQuery = new GetNotificationDetailQuery() { ID = ID };
            return Ok(await _mediator.Send(getNotifictionDetailQuery));
        }


        [HttpDelete("{ID}", Name = "DeleteNotification")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var deleteNotificationCommand = new DeleteNotificationCommand() { ID = ID };
            _logger.LogInformation("DeleteCustomer Initiated");
            var response = await _mediator.Send(deleteNotificationCommand);
            _logger.LogInformation("DeleteCustomer Completed");
            return Ok(response);
        }

        [HttpPut(Name = "UpdateNotification")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateNotificationCommand updateCustomerCommand)
        {
            _logger.LogInformation("UpdateNotification Initiated");
            var response = await _mediator.Send(updateCustomerCommand);
            _logger.LogInformation("UpdateNotification Completed");
            return Ok(response);
        }
    }
}
