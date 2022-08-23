using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.Drivers.Queries.GetDriverDetailByCustomerVehicleID;

namespace WazenPolicy.Api.Controllers.v1
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

        [HttpGet("GetDriverByCustomerVehicleID", Name = "GetDriverByCustomerVehicleID")]
        public async Task<ActionResult> GetDriverByCustomerVehicleID(Guid CustomerVehicleID)
        {
            _logger.LogInformation("GetPolicyByID Initiated");
            var getDriverDetailByCustomerVehicleIDQuery = new GetDriverDetailByCustomerVehicleIDQuery() { CustomerVehicleId = CustomerVehicleID };
            var response = await _mediator.Send(getDriverDetailByCustomerVehicleIDQuery);
            _logger.LogInformation("GetPolicyByID Completed");
            return Ok(response);
        }
    }
}
