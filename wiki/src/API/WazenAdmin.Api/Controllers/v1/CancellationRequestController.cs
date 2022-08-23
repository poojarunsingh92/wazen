using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.CancellationRequests.Queries.GetCancellationRequestByPolicyID;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CancellationRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public CancellationRequestController(IMediator mediator, ILogger<CancellationRequestController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetCancellationRequestByPolicyID/{PolicyID}", Name = "GetCancellationRequestByPolicyID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCancellationRequestByPolicyID(Guid PolicyID)
        {
            _logger.LogInformation("GetCancellationRequestByPolicyID Initiated");
            var getCustomerByNINAndDOB = new GetCancellationRequestByPolicyIDQuery() { PolicyID= PolicyID };
            var dtos = await _mediator.Send(getCustomerByNINAndDOB);
            _logger.LogInformation("GetCancellationRequestByPolicyID Completed");
            return Ok(dtos);
        }
    }
}
