using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationDetailByVehicleID;
using WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationListByVehicleID;

namespace WazenPolicy.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VehicleViolationController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public VehicleViolationController(IMediator mediator, ILogger<VehicleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //GetByID
        [HttpGet("GetVehicleViolationByVehicleID", Name = "GetVehicleViolationByVehicleID")]
        public async Task<ActionResult> GetVehicleViolationByVehicleID(Guid VehicleID)
        {
            _logger.LogInformation("GetVehicleViolationByVehicleID Initiated");
            var getTempVehicleViolationDetailByVehicleIDQuery = new GetTempVehicleViolationDetailByVehicleIDQuery() { VehicleID = VehicleID };
            var response = await _mediator.Send(getTempVehicleViolationDetailByVehicleIDQuery);
            _logger.LogInformation("GetVehicleViolationByVehicleID  Completed");
            return Ok(response);
        }

        [HttpGet("GetVehicleViolationListByVehicleID", Name = "GetVehicleViolationListByVehicleID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetVehicleViolationListByVehicleID(Guid VehicleID)
        {
            _logger.LogInformation("GetVehicleViolationListByVehicleID Initiated");
            var getTempVehicleViolationListByVehicleIDQuery = new GetTempVehicleViolationListByVehicleIDQuery() { VehicleID=VehicleID };
            var dtos = await _mediator.Send(getTempVehicleViolationListByVehicleIDQuery);
            _logger.LogInformation("GetVehicleViolationListByVehicleID Completed");
            return Ok(dtos);
        }
    }
}
