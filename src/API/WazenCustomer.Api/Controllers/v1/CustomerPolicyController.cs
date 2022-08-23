using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.CustomerPolicies.Commands.CreateCustomerPolicy;
using WazenCustomer.Application.Features.CustomerPolicies.Commands.DeleteCustomerPolicy;
using WazenCustomer.Application.Features.CustomerPolicies.Commands.UpdateCustomerPolicy;
using WazenCustomer.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID;

namespace WazenCustomer.Api.Controllers.v1
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

        [HttpPost(Name = "AddCustomerPolicy")]
        public async Task<ActionResult> Create([FromBody] CreateCustomerPolicyCommand createCustomerPolicyCommand)
        {
            var customerPolicyDto = await _mediator.Send(createCustomerPolicyCommand);
            return Ok(customerPolicyDto);
        }

        [HttpDelete("DeleteCustomerPolicy/{Id}", Name = "DeleteCustomerPolicy")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomerPolicy(Guid Id)
        {
            var deleteCustomerPolicy = new DeleteCustomerPolicyCommand()
            { ID = Id };
            await _mediator.Send(deleteCustomerPolicy);
            return NoContent();
        }

        [HttpPut("UpdateCustomerPolicy", Name = "UpdateCustomerPolicy")]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerPolicyCommand updateCustomerPolicyCommand)
        {
            var response = await _mediator.Send(updateCustomerPolicyCommand);
            return Ok(response);
        }

        [HttpGet("GetCustomerPolicyByCustomerId", Name = "GetCustomerPolicyByCustomerId")]
        public async Task<ActionResult> GetCustomerPolicyByCustomerId(Guid Id)
        {
            var getCustomerPolicyListByCustomerIDQuery = new GetCustomerPolicyListByCustomerIDQuery()
            {
                CustomerID = Id
            };
            return Ok(await _mediator.Send(getCustomerPolicyListByCustomerIDQuery));
        }
    }
}