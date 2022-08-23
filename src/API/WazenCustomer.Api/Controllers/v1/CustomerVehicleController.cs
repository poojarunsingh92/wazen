using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.CustomerVehicles.Commands.CreateCustomerVehicle;
using WazenCustomer.Application.Features.CustomerVehicles.Commands.DeleteCustomerVehicle;
using WazenCustomer.Application.Features.CustomerVehicles.Commands.UpdateCustomerVehicle;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerVehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CustomerVehicleController(IMediator mediator, ILogger<CustomerVehicleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddCustomerVehicle")]
        public async Task<ActionResult> Create([FromBody] CreateCustomerVehicleCommand createCustomerVehicleCommand)
        {
            var customerVehicleDto = await _mediator.Send(createCustomerVehicleCommand);
            return Ok(customerVehicleDto);
        }

        [HttpDelete("DeleteCustomerVehicle/{Id}", Name = "DeleteCustomerVehicle")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomerPolicy(Guid Id)
        {
            var deleteCustomerVeicle = new DeleteCustomerVehicleCommand()
            { ID = Id };
            await _mediator.Send(deleteCustomerVeicle);
            return NoContent();
        }

        [HttpPut("UpdateCustomerVehicle", Name = "UpdateCustomerVehicle")]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerVehicleCommand updateCustomerVehicleCommand)
        {
            var response = await _mediator.Send(updateCustomerVehicleCommand);
            return Ok(response);
        }
    }
}