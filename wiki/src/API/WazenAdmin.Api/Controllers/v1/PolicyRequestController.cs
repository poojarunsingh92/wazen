using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.PolicyRequests.Queries.GetPolicyRequestList;

namespace WazenAdmin.Api.Controllers.v1
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

        [HttpGet("all", Name = "GetAllPolicyRequests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllPolicyRequests()
        {
            _logger.LogInformation("GetAllGetAllPolicyRequests Initiated");
            var dtos = await _mediator.Send(new GetPolicyRequestListQuery());
            _logger.LogInformation("GetAllGetAllPolicyRequests Completed");
            return Ok(dtos);
        }
    }
}
