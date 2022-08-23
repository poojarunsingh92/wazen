using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.CustomersOTP.Commands.CreateCustomersOTP;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerOTPController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CustomerOTPController(IMediator mediator, ILogger<CustomerOTPController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CreateCustomersOTP", Name = "CreateCustomersOTP")]
        public async Task<ActionResult> CreateCustomesrOTP([FromBody] CreateCustomersOTPCommand createCustomersOTPCommand)
        {
            var customerDto = await _mediator.Send(createCustomersOTPCommand);
            return Ok(customerDto);
        }
    }
}