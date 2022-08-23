using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerID;
using WazenAdmin.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID;

namespace WazenAdmin.Api.Controllers.v1
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

        [HttpGet("GetVehicleListByCustomerID", Name = "GetVehicleListByCustomerID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetVehicleListByCustomerID(Guid CustomerID)
        {
            _logger.LogInformation("GetVehicleListByCustomerID Initiated");
            var getVehicleListByCustomerIDQuery = new GetVehicleListByCustomerIDQuery() { CustomerID = CustomerID };
            var dtos = await _mediator.Send(getVehicleListByCustomerIDQuery);
            _logger.LogInformation("GetVehicleListByCustomerID Completed");
            return Ok(dtos);
        }

        [HttpGet("GetVehicleBySequenceNumberAndCustomerID", Name = "GetVehicleBySequenceNumberAndCustomerID")]
        public async Task<ActionResult> GetVehicleBySequenceNumberAndCustomerID(Guid CustomerID, string SequenceNumber)
        {
            _logger.LogInformation("GetVehicleBySequenceNumberAndCustomerID Initiated");
            var getVehicleBySequenceNumberAndCustomerIDQuery = new GetVehicleBySequenceNumberAndCustomerIDQuery() { CustomerID=CustomerID, SequenceNumber=SequenceNumber };
            var response = await _mediator.Send(getVehicleBySequenceNumberAndCustomerIDQuery);
            _logger.LogInformation("GetVehicleBySequenceNumberAndCustomerID Completed");
            return Ok(response);
        }
    }
}
