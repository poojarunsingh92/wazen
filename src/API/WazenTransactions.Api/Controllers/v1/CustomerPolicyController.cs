using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.CustomerPolicies.Commands.CancelCustomerPolicy;
using WazenTransactions.Application.Features.CustomerPolicies.Commands.UpgradeCustomerPolicy;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyDetailByID;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerIDPolicyType;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetRenewCustomerPolicyListByCustomerID;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetVehiclePolicyListByCustomerID;

namespace WazenTransactions.Api.Controllers.v1
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

        //GetCustomerPolicyListByCustomerID
        [HttpGet("GetCustomerPolicyByCustomerId", Name = "GetCustomerPolicyByCustomerId")]
        public async Task<ActionResult> GetCustomerPolicyByCustomerId(Guid Id)
        {
            var getCustomerPolicyListByCustomerIDQuery = new GetCustomerPolicyListByCustomerIDQuery()
            {
                CustomerID = Id
            };
            return Ok(await _mediator.Send(getCustomerPolicyListByCustomerIDQuery));
        }

        //GetCustomerPolicyDetailByID
        [HttpGet("GetCustomerPolicyDetailByID", Name = "GetCustomerPolicyDetailByID")]
        public async Task<ActionResult> GetCustomerPolicyDetailByID(Guid ID)
        {
            var getCustomerPolicyDetailByIDQuery = new GetCustomerPolicyDetailByIDQuery()
            {
                ID = ID
            };
            return Ok(await _mediator.Send(getCustomerPolicyDetailByIDQuery));
        }

        //CustomerPolicyListByCustomerIdPolicyType
        [HttpGet("CustomerPolicyListByCustomerIdPolicyType", Name = "CustomerPolicyListByCustomerIdPolicyType")]
        public async Task<ActionResult> CustomerPolicyListByCustomerIdPolicyType(Guid CustomerID, int PolicyType)
        {
            var getCustomerPolicyListByCustomerIdPolicyTypeQuery = new GetCustomerPolicyListByCustomerIDPolicyTypeQuery(){ CustomerID = CustomerID, PolicyType=PolicyType};
            return Ok(await _mediator.Send(getCustomerPolicyListByCustomerIdPolicyTypeQuery));
        }

        //CancelPolicy
        [HttpPut("CancelCustomerPolicy", Name = "CancelCustomerPolicy")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelCustomerPolicy([FromBody] CancelCustomerPolicyCommand cancelCustomerPolicyCommand)
        {
            var response = await _mediator.Send(cancelCustomerPolicyCommand);
            return Ok(response);
        }

        //UpgradePolicy
        [HttpPut("UpgradeCustomerPolicy", Name = "UpgradeCustomerPolicy")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpgradeCustomerPolicy([FromBody] UpgradeCustomerPolicyCommand upgradeCustomerPolicyCommand)
        {
            var response = await _mediator.Send(upgradeCustomerPolicyCommand);
            return Ok(response);
        }

        //GetCustomerVehiclePolicyListByCustomerID
        [HttpGet("GetCustomerVehiclePolicyListByCustomerID", Name = "GetCustomerVehiclePolicyListByCustomerID")]
        public async Task<ActionResult> GetCustomerVehiclePolicyListByCustomerID(Guid CustomerID)
        {
            var getRenewCustomerPolicyListByCustomerIDQuery = new GetRenewCustomerPolicyListByCustomerIDQuery() { CustomerID = CustomerID};
            return Ok(await _mediator.Send(getRenewCustomerPolicyListByCustomerIDQuery));
        }

        //GetVehiclePolicyListByCustomerID
        [HttpGet("GetVehiclePolicyListByCustomerID", Name = "GetVehiclePolicyListByCustomerID")]
        public async Task<ActionResult> GetVehiclePolicyListByCustomerID(Guid CustomerID)
        {
            var getVehiclePolicyListByCustomerIDQuery = new GetVehiclePolicyListByCustomerIDQuery() { CustomerID = CustomerID };
            return Ok(await _mediator.Send(getVehiclePolicyListByCustomerIDQuery));
        }
    }
}