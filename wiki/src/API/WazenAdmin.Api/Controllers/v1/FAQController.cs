using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.FAQ.Queries.GetFAQList;
using WazenAdmin.Application.Features.FAQ.Queries.GetFAQDetail;
using WazenAdmin.Application.Features.FAQ.Commands.CreateFAQ;
using WazenAdmin.Application.Features.FAQ.Commands.UpdateFAQ;
using WazenAdmin.Application.Features.FAQ.Commands.DeleteFAQ;
using System;
using WazenAdmin.Application.Features.FAQ.Queries.GetFAQListByModule;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public FAQController(IMediator mediator, ILogger<FAQController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //GetAll
        [HttpGet("all", Name = "GetAllFAQs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllFAQs()
        {
            _logger.LogInformation("GetAllGetAllFAQs Initiated");
            var dtos = await _mediator.Send(new GetFAQListQuery());
            _logger.LogInformation("GetAllGetAllFAQs Completed");
            return Ok(dtos);
        }

        //GetById
        [HttpGet("GetFAQByID/{ID}", Name = "GetFAQByID")]
        public async Task<ActionResult> GetFAQById(Guid ID)
        {
            var getFAQDetailQuery = new GetFAQDetailQuery() { ID = ID };
            return Ok(await _mediator.Send(getFAQDetailQuery));
        }

        //Add
        [HttpPost(Name = "AddFAQ")]
        public async Task<ActionResult> Create([FromBody] CreateFAQCommand createFAQCommand)
        {
            var response = await _mediator.Send(createFAQCommand);
            return Ok(response);
        }

        //Update
        [HttpPut(Name = "UpdateFAQ")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateFAQCommand updateFAQCommand)
        {
            _logger.LogInformation("UpdateMFAQ Initiated");

            var response = await _mediator.Send(updateFAQCommand);
            _logger.LogInformation("UpdateFAQ Completed");
            return Ok(response);
        }

        //Delete
        [HttpDelete("{ID}", Name = "DeleteFAQ")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            _logger.LogInformation("deleteFAQ Initiated");
            var deleteEducationCommand = new DeleteFAQCommand() { ID = ID };
            await _mediator.Send(deleteEducationCommand);
            _logger.LogInformation("deleteFAQ Completed");

            return NoContent();
        }

        [HttpGet("GetAllFAQsByModule", Name = "GetAllFAQsByModule")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllFAQsByModule()
        {
            _logger.LogInformation("GetAllFAQsByModule Initiated");
            var dtos = await _mediator.Send(new GetFAQListByModuleQuery());
            _logger.LogInformation("GetAllFAQsByModule Completed");
            return Ok(dtos);
        }
    }
}
