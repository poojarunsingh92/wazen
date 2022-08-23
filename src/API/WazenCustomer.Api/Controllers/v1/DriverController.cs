using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.Drivers.Commands.AddUpdateDriverDetail;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DriverController(IMediator mediator, ILogger<DriverController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddANDUpdateDriver", Name = "AddANDUpdateDriver")]
        public async Task<ActionResult> AddANDUpdateDriver([FromBody] CreateDriverDetailCommand createDriverDetailCommand)
        {
            var dtos = await _mediator.Send(createDriverDetailCommand);
            return Ok(dtos);
        }
    }
}