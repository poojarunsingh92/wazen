using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.Vehicles.Queries.GetVehicleDetailByID;

namespace WazenPolicy.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public VehicleController(IMediator mediator, ILogger<VehicleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //GetByID
        [HttpGet("GetVehicleByID", Name = "GetVehicleByID")]
        public async Task<ActionResult> GetVehicleByID(Guid ID)
        {
            _logger.LogInformation("GetVehicleByID Initiated");
            var getVehicleDetailQuery = new GetVehicleDetailByIDQuery() { ID = ID };
            var response = await _mediator.Send(getVehicleDetailQuery);
            _logger.LogInformation("GetCustomerByID  Completed");
            return Ok(response);
        }
    }
}
