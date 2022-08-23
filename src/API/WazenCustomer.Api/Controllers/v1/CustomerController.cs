using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.Customers.Commands.CreateCustomer;
using WazenCustomer.Application.Features.Customers.Commands.DeleteCustomer;
using WazenCustomer.Application.Features.Customers.Commands.UpdateCustomer;
using WazenCustomer.Application.Features.Customers.Queries.GetAllCustomers;
using WazenCustomer.Application.Features.Customers.Queries.GetCustomerById;
using WazenCustomer.Application.Features.Customers.Queries.GetCustomerByNationalId;
using WazenCustomer.Application.Features.Customers.Queries.GetCustomerByUserId;
using WazenCustomer.Application.Features.Customers.Queries.SendOTPToCustomerEmail;
using WazenCustomer.Application.Features.TempCustomers.Queries.SendOTP;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            _logger.LogInformation("AddCustomer Initiated");
            var response = await _mediator.Send(createCustomerCommand);
            _logger.LogInformation("AddCustomer Completed");
            return Ok(response);
        }

        [HttpGet("allCustomer", Name = "allCustomer")]
        public async Task<ActionResult> GetAllCustomers()
        {
            _logger.LogInformation("GetAllCustomers Initiated");
            var response = await _mediator.Send(new GetAllCustomerListQuery());
            _logger.LogInformation("GetAllCustomers Completed");
            return Ok(response);
        }

        //CustomerDelete
        [HttpDelete("DeleteCustomer/{ID}", Name = "DeleteCustomer")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomer(Guid ID)
        {
            _logger.LogInformation("DeleteCustomer Initiated");
            var deleteCustomerPolicy = new DeleteCustomerCommand() { ID = ID };
            var response = await _mediator.Send(deleteCustomerPolicy);
            _logger.LogInformation("DeleteCustomer Completed");
            return Ok(response);
        }

        [HttpGet("GetCustomerById", Name = "GetCustomerById")]
        public async Task<ActionResult> GetCustomerById(Guid Id)
        {
            _logger.LogInformation("GetCustomerById Initiated");
            var getCustomerById = new GetCustomerByIdQuery()
            {
                Id = Id
            };
            var response = await _mediator.Send(getCustomerById);
            _logger.LogInformation("GetCustomerById Completed");
            return Ok(response);
        }

        //UpdateCustomer
        [HttpPut("UpdateCustomer", Name = "UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            _logger.LogInformation("UpdateCustomer Initiated");
            var response = await _mediator.Send(updateCustomerCommand);
            _logger.LogInformation("UpdateCustomer Completed");
            return Ok(response);
        }

        [HttpGet("GetCustomerByNIN", Name = "GetCustomerByNIN")]
        public async Task<ActionResult> GetCustomerByNIN(String NIN)
        {
            _logger.LogInformation("GetCustomerByNIN Initiated");
            var getCustomerByNINQuery = new GetCustomerByNationalIdQuery()
            {
                NIN = NIN
            };
            var response = await _mediator.Send(getCustomerByNINQuery);
            _logger.LogInformation("GetCustomerByNIN Completed");
            return Ok(response);
        }

        [HttpGet("GetCustomerByUserId", Name = "GetCustomerByUserId")]
        public async Task<ActionResult> GetCustomerByUserId(Guid UserId)
        {
            _logger.LogInformation("GetCustomerByUserId Initiated");
            var getCustomerByUserId = new GetCustomerByUserIdQuery()
            {
                UserId = UserId
            };
            var response = await _mediator.Send(getCustomerByUserId);
            _logger.LogInformation("GetCustomerByUserId Completed");
            return Ok(response);
        }

        [HttpGet("SendOTP", Name = "SendOTP")]
        public async Task<ActionResult> SendOTP(Guid CustomerID)
        {
            _logger.LogInformation("GetCustomerByUserId Initiated");
            var sendOTPQuery = new SendOTPQuery() { CustomerID = CustomerID };
            var response = await _mediator.Send(sendOTPQuery);
            _logger.LogInformation("GetCustomerByUserId Completed");
            return Ok(response);
        }

        [HttpGet("SendOTPTOCustomerEmail", Name = "SendOTPTOCustomerEmail")]
        public async Task<ActionResult> SendOTPTOCustomerEmail(string Email)
        {
            _logger.LogInformation("SendOTPTOCustomerEmail Initiated");
            var sendOTPToCustomerEmailQuery = new SendOTPToCustomerEmailQuery() { Email= Email };
            var response = await _mediator.Send(sendOTPToCustomerEmailQuery);
            _logger.LogInformation("SendOTPTOCustomerEmail Completed");
            return Ok(response);
        }
    }
}