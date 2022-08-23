using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.Payment.Commands.CreatePayment;

namespace WazenTransactions.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DirectPayController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DirectPayController(IMediator mediator, ILogger<DirectPayController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "DirectPay")]
        public async Task<ActionResult> Create([FromBody] CreatePaymentCommand createPaymentCommand)
        {
            var id = await _mediator.Send(createPaymentCommand);
            return Ok(id);
        }

        [HttpGet("UpdatedOn22thAugust22_11_00PM", Name = "UpdatedOn22thAugust22_11_00PM")]
        public async Task<ActionResult> UpdatedOn22thAugust22_11_00PM()
        {
            return Ok();
        }
    }
}
