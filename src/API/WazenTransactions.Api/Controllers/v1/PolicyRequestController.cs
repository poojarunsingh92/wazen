using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.PoliciesRequest.Commands.CreatePolicyRequest;
using WazenTransactions.Application.Features.PoliciesRequest.Commands.DeletePolicyRequest;
using WazenTransactions.Application.Features.PoliciesRequest.Commands.UpdatePolicyRequest;

namespace WazenTransactions.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PolicyRequestController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public PolicyRequestController(IMediator mediator, ILogger<PolicyRequestController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddPolicyRequest")]
        public async Task<ActionResult> Create([FromBody] CreatePolicyRequestCommand createPolicyRequestCommand)
        {
            var response = await _mediator.Send(createPolicyRequestCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdatePolicyRequest")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdatePolicyRequestCommand updatePolicyRequestCommand)
        {
            _logger.LogInformation("UpdatePolicyRequest Initiated");

            var response = await _mediator.Send(updatePolicyRequestCommand);
            _logger.LogInformation("UpdatePolicyRequest Completed");
            return Ok(response);
        }

        [HttpDelete("{ID}", Name = "DeletePolicyRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            _logger.LogInformation("deletePolicyRequest Initiated");
            var deletePolicyRequestCommand = new DeletePolicyRequestCommand() { ID = ID };
            await _mediator.Send(deletePolicyRequestCommand);
            _logger.LogInformation("deletePolicyRequest Completed");

            return NoContent();
        }

    }
}
