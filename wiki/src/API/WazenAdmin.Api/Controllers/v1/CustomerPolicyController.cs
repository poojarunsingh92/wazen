using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPoliciesByCustomerID;
using WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyByVehicleID;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerPolicyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public CustomerPolicyController(IMediator mediator, ILogger<CustomerPolicyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetCustomerPolicyListByCustomerID", Name = "GetCustomerPolicyListByCustomerID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCustomerPolicyListByCustomerID(Guid CustomerID)
        {
            _logger.LogInformation("GetCustomerPolicyListByCustomerID Initiated");
            var getCustomerPoliciesByCustomerIDQuery = new GetCustomerPoliciesByCustomerIDQuery() { CustomerID = CustomerID };
            var dtos = await _mediator.Send(getCustomerPoliciesByCustomerIDQuery);
            _logger.LogInformation("GetCustomerPolicyListByCustomerID Completed");
            return Ok(dtos);
        }

        [HttpGet("GetCustomerPolicyByVehicleID/{VehicleID}", Name = "GetCustomerPolicyByVehicleID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCustomerPolicyByVehicleID(Guid VehicleID)
        {
            _logger.LogInformation("GetCustomerPolicyVehicleID Initiated");
            var getCustomerPolicyByVehicleIDQuery = new GetCustomerPolicyByVehicleIDQuery() { VehicleID = VehicleID };
            var dtos = await _mediator.Send(getCustomerPolicyByVehicleIDQuery);
            _logger.LogInformation("GetCustomerPolicyVehicleID Completed");
            return Ok(dtos);
        }
    }
}
