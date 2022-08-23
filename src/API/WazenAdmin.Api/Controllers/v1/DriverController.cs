using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.Drivers.Queries.GetDriverByVehicleID;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public DriverController(IMediator mediator, ILogger<DriverController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetDriverByVehicleID/{VehicleID}", Name = "GetDriverByVehicleID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetDriverByVehicleID(Guid VehicleID)
        {
            _logger.LogInformation("GetDriverByVehicleID Initiated");
            var getVehicleListByCustomerIDQuery = new GetDriverByVehicleIDQuery() { VehicleID = VehicleID };
            var dtos = await _mediator.Send(getVehicleListByCustomerIDQuery);
            _logger.LogInformation("GetDriverByVehicleID Completed");
            return Ok(dtos);
        }
    }
}
