using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.Customers.Commands.CreateCustomer;
using WazenAdmin.Application.Features.Customers.Commands.DeleteCustomer;
using WazenAdmin.Application.Features.Customers.Commands.UpdateCustomer;
using WazenAdmin.Application.Features.Customers.Queries.GetAllCustomerList;
using WazenAdmin.Application.Features.Customers.Queries.GetCustomerByID;
using WazenAdmin.Application.Features.Customers.Queries.GetCustomerByNINAndDOB;
using WazenAdmin.Application.Features.Customers.Queries.GetCustomerList;

namespace WazenAdmin.Api.Controllers.v1
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

        /*AddCustomer*/
        [HttpPost("AddCustomer", Name = "AddCustomer")]
        public async Task<ActionResult> AddCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            _logger.LogInformation("AddCustomer Initiated");
            var response = await _mediator.Send(createCustomerCommand);
            _logger.LogInformation("AddCustomer Initiated");
            return Ok(response);
        }

        [HttpGet("GetCustomerByID", Name = "GetCustomerByID")]
        public async Task<ActionResult> GetCustomerByID(Guid ID)
        {
            _logger.LogInformation("GetCustomerByID Initiated");
            var getCustomerByID = new GetCustomerByIDQuery(){ ID=ID };
            var response = await _mediator.Send(getCustomerByID);
            _logger.LogInformation("GetCustomerByID Completed");
            return Ok(response);
        }

        [HttpGet("all", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCustomers()
        {
            _logger.LogInformation("GetAllCustomers Initiated");
            var dtos = await _mediator.Send(new GetCustomerListQuery());
            _logger.LogInformation("GetAllCustomers Completed");
            return Ok(dtos);
        }

        [HttpGet("getall", Name = "GetAllCustomersList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCustomersList()
        {
            _logger.LogInformation("GetAllCustomersList Initiated");
            var dtos = await _mediator.Send(new GetAllCustomerListQuery());
            _logger.LogInformation("GetAllCustomersList Completed");
            return Ok(dtos);
        }

        [HttpGet("GetCustomerByNINAndDOB", Name = "GetCustomerByNINAndDOB")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCustomerByNINAndDOB(string NIN, DateTime DateOfBith)
        {
            _logger.LogInformation("GetCustomerByNINAndDOB Initiated");
            var getCustomerByNINAndDOB = new GetCustomerByNINAndDOBQuery() { NIN = NIN, DateOfBirth = DateOfBith};
            var dtos = await _mediator.Send(getCustomerByNINAndDOB);
            _logger.LogInformation("GetCustomerByNINAndDOB Completed");
            return Ok(dtos);
        }

        //UpdateCustomer
        [HttpPut("UpdateCustomer", Name = "UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            _logger.LogInformation("UpdateCustomer Initiated");
            var dtos = await _mediator.Send(updateCustomerCommand);
            _logger.LogInformation("UpdateCustomer Initiated");
            return Ok(dtos);
        }

        //CustomerDelete
        [HttpDelete("DeleteCustomer/{ID}", Name = "DeleteCustomer")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomer(Guid ID)
        {
            _logger.LogInformation("DeleteCustomer Initiated");
            var deleteCustomerCommand = new DeleteCustomerCommand() { ID = ID };
            var response = await _mediator.Send(deleteCustomerCommand);
            _logger.LogInformation("DeleteCustomer Initiated");
            return Ok(response);
        }
    }
}