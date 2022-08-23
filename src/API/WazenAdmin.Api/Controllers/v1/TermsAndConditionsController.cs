using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.TermsAndConditions.Commands.CreateTermsAndConditions;
using WazenAdmin.Application.Features.TermsAndConditions.Commands.DeleteTermsAndConditions;
using WazenAdmin.Application.Features.TermsAndConditions.Commands.UpdateTermsAndConditions;
using WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsDetail;
using WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsList;

namespace Wazen.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TermsAndConditionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public TermsAndConditionsController(IMediator mediator, ILogger<TermsAndConditionsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //GetAll
        [HttpGet("all", Name = "GetAllTermsAndConditions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllTermsAndConditions()
        {
            _logger.LogInformation("GetAllTermsAndConditions Initiated");
            var dtos = await _mediator.Send(new GetTermsAndConditionsListQuery());
            _logger.LogInformation("GetAllTermsAndConditions Completed");
            return Ok(dtos);
        }

        //GetById
        [HttpGet("GetTermsAndConditionByID/{ID}", Name = "GetTermsAndConditionByID")]
        public async Task<ActionResult> GetTermsAndConditionByID(Guid ID)
        {
            var getTandCDetailQuery = new GetTermsAndConditionsDetailQuery() { ID = ID };
            return Ok(await _mediator.Send(getTandCDetailQuery));
        }

        //Add
        [HttpPost(Name = "AddTermsAndCondition")]
        public async Task<ActionResult> Create([FromBody] CreateTermsAndConditionsCommand createTandCCommand)
        {
            var response = await _mediator.Send(createTandCCommand);
            return Ok(response);
        }

        //Update
        [HttpPut(Name = "UpdateTermsAndCondition")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateTermsAndConditionsCommand updateTandCCommand)
        {
            _logger.LogInformation("UpdateTermsAndCondition Initiated");

            var response = await _mediator.Send(updateTandCCommand);
            _logger.LogInformation("UpdateTermsAndCondition Completed");
            return Ok(response);
        }

        //Delete
        [HttpDelete("{ID}", Name = "DeleteTermsAndCondition")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            _logger.LogInformation("DeleteTermsAndCondition Initiated");
            var deleteCommand = new DeleteTermsAndConditionsCommand() { ID = ID };
            await _mediator.Send(deleteCommand);
            _logger.LogInformation("DeleteTermsAndCondition Completed");

            return NoContent();
        }
    }
}
