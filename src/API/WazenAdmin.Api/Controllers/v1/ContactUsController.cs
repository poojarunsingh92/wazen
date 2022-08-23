using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.ContactUs.Commands.CreateContactUs;
using WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsList;
using WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsDetail;
using WazenAdmin.Application.Features.ContactUs.Commands.DeleteContactUs;
using WazenAdmin.Application.Features.ContactUs.Commands.UpdateContactUs;

namespace Wazen.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public ContactUsController(IMediator mediator, ILogger<ContactUsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /*GetAllContactus*/
        [HttpGet("all", Name = "GetAllContactus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllFeatures()
        {
            _logger.LogInformation("GetAllContactus Initiated");
            var dtos = await _mediator.Send(new GetContactUsListQuery());
            _logger.LogInformation("GetAllContactus Completed");
            return Ok(dtos);
        }

        /*GetAllContactUsId*/
        [HttpGet("GetContactUsByID/{ID}", Name = "GetContactUsByID")]
        public async Task<ActionResult> GetContactUsByID(Guid ID)
        {
            var getContactUsDetailQuery = new GetContactUsDetailQuery() { Id = ID };
            return Ok(await _mediator.Send(getContactUsDetailQuery));
        }


        /*AddContactUs*/
        [HttpPost(Name = "AddContactUs")]
        public async Task<ActionResult> Create([FromBody] CreateContactUsCommand createContactUsCommand)
        {
            var response = await _mediator.Send(createContactUsCommand);
            return Ok(response);
        }

        /*UpdateContactUs*/
        [HttpPut(Name = "UpdateContactUs")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateContactUsCommand updateContactUsCommand)
        {
            _logger.LogInformation("UpdateContactUs Initiated");
            var response = await _mediator.Send(updateContactUsCommand);
            _logger.LogInformation("UpdateContactUs Completed");
            return Ok(response);
        }

        /*DeleteContactUs*/
        [HttpDelete("{ID}", Name = "DeleteContactUs")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            _logger.LogInformation("DeleteContactUs Initiated");
            var deleteContactUsCommand = new DeleteContactUsCommand() { Id = ID };
            var response = await _mediator.Send(deleteContactUsCommand);
            _logger.LogInformation("DeleteContactUs Completed");
            return Ok(response);
        }
    }
}
