using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.ACIG.Command.ACIGTPLQuote;
using WazenPolicy.Application.Features.ACIG.Command.ACIGCMPQuote;

namespace WazenPolicy.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ACIGController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public ACIGController(IMediator mediator, ILogger<ACIGController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("UpdatedOn19thAugust22_01_40PM", Name = "UpdatedOn19thAugust22_01_40PM")]
        public async Task<ActionResult> UpdatedOn19thAugust22_01_40PM()
        {
            _logger.LogInformation("UpdatedOn19thAugust22_01_40PM Initiated");            
            _logger.LogInformation("UpdatedOn19thAugust22_01_40PM Completed");
            return Ok();
        }

        [HttpPost("ACIGTPLQuote", Name = "ACIGTPLQuote")]
        public async Task<ActionResult> ACIGTPLQuote(/*[FromBody] ACIGQuoteCommand request*/)
        {
            _logger.LogInformation("ACIGTPLQuote Initiated");
            ACIGTPLQuoteCommand request = new ACIGTPLQuoteCommand();
            var response = await _mediator.Send(request);
            _logger.LogInformation("ACIGTPLQuote Completed");
            return Ok(response);
        }

        [HttpPost("ACIGCMPQuote", Name = "ACIGCMPQuote")]
        public async Task<ActionResult> ACIGCMPQuote(/*[FromBody] ACIGQuoteCommand request*/)
        {
            _logger.LogInformation("ACIGCMPQuote Initiated");
            ACIGCMPQuoteCommand request = new ACIGCMPQuoteCommand();
            var response = await _mediator.Send(request);
            _logger.LogInformation("ACIGCMPQuote Completed");
            return Ok(response);
        }
    }
}
