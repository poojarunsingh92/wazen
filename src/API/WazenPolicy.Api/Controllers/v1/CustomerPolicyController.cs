using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.CreateCustomerPolicy;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.DeleteCustomerPolicy;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateCancelCustomerPolicy;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateCustomerPolicy;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateExistingCustomerPolicyCommand;
using WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerPolicyList;
using WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerPolicyListByCustomerID;
using WazenPolicy.Application.Features.CustomerPolicy.Queries.GetPolicyDetail;

namespace WazenPolicy.Api.Controllers.v1
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

        //GetAll/GetList
        [HttpGet("all", Name = "GetAllCustomerPolicies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllCustomerPolicies()
        {
            _logger.LogInformation("GetAllCustomerPolicy Initiated");
            var customerPoliciesDto = await _mediator.Send(new GetCustomerPolicyListQuery());
            _logger.LogInformation("GetCustomersPolicy Completed");
            return Ok(customerPoliciesDto);
        }

        //GetByID
        [HttpGet(Name = "GetPolicyByID")]
        public async Task<ActionResult> GetPolicyByID(Guid ID)
        {
            _logger.LogInformation("GetPolicyByID Initiated");
            var getPolicyDetailQuery = new GetCustomerPolicyDetailQuery() { ID = ID };
            var response = await _mediator.Send(getPolicyDetailQuery);
            _logger.LogInformation("GetPolicyByID Completed");
            return Ok(response);
        }

        //Add/CreateCustomerPolicy
        [HttpPost(Name = "AddCustomerPolicy")]
        public async Task<ActionResult> Create([FromBody] CreateCustomerPolicyCommand createCustomerPolicyCommand)
        {
            _logger.LogInformation("AddCustomerPolicy Initiated");
            var response = await _mediator.Send(createCustomerPolicyCommand);
            _logger.LogInformation("AddCustomerPolicy Completed");
            return Ok(response);
        }

        //UpdateCustomerPolicy
        [HttpPut("UpdateCustomerPolicy", Name = "UpdateCustomerPolicy")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCustomerPolicy([FromBody] UpdateCustomerPolicyCommand updateCustomerPolicyCommand)
        {
            _logger.LogInformation("UpdateCustomerPolicy Initiated");
            var response = await _mediator.Send(updateCustomerPolicyCommand);
            _logger.LogInformation("UpdateCustomerPolicy Completed");
            return Ok(response);
        }

        //UpdateExistingCustomerPolicy - This need to check as getting issue at Foreign Key
        [HttpPut("UpdateExistingCustomerPolicy", Name = "UpdateExistingCustomerPolicy")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateExistingCustomerPolicy([FromBody] UpdateExistingCustomerPolicyCommand updateExistingCustomerPolicyCommand)
        {
            _logger.LogInformation("UpdateExistingCustomerPolicyCommand Initiated");
            var response = await _mediator.Send(updateExistingCustomerPolicyCommand);
            _logger.LogInformation("UpdateExistingCustomerPolicyCommand Completed");
            return Ok(response);
        }

        //DeleteCustomerPolicyByID
        [HttpDelete("{ID}", Name = "DeleteCustomerPolicy")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var deleteCustomerPolicyCommand = new DeleteCustomerPolicyCommand() { ID = ID };
            _logger.LogInformation("DeleteCustomerPolicy Initiated");
            var response = await _mediator.Send(deleteCustomerPolicyCommand);
            _logger.LogInformation("DeleteCustomerPolicy Completed");
            return Ok(response);
        }

        //UpdateCancelCustomerPolicy
        [HttpPut("UpdateCancelCustomerPolicy", Name = "UpdateCancelCustomerPolicy")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCancelCustomerPolicy([FromBody] UpdateCancelCustomerPolicyCommand updateCustomerPolicyCommand)
        {
            _logger.LogInformation("UpdateCancelPolicy Initiated");
            var response = await _mediator.Send(updateCustomerPolicyCommand);
            _logger.LogInformation("UpdateCancelPolicy Completed");
            return Ok(response);
        }

        //GetCustomerPolicyByCustomerID
        [HttpGet("GetCustomerPolicyByCustomerID", Name = "GetCustomerPolicyByCustomerID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCustomerPolicyByCustomerID(Guid CustomerID)
        {
            _logger.LogInformation("GetCustomerPoliciesList Initiated");
            var getCustomerPolicyListByCustomerIDQuery = new GetCustomerPolicyListByCustomerIDQuery() { CustomerID = CustomerID };
            var response = await _mediator.Send(getCustomerPolicyListByCustomerIDQuery);
            _logger.LogInformation("GetCustomerPoliciesList Completed");
            return Ok(response);
        }
    }
}
