using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote;
using WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote;
using WazenPolicy.Application.Features.Walaa.Commands.WalaaPolicy;

namespace WazenPolicy.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class WalaaQuotePolicyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public WalaaQuotePolicyController(IMediator mediator, ILogger<WalaaQuotePolicyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("WalaaPolicy", Name = "WalaaPolicy")]
        public async Task<ActionResult> GetWalaaPolicy(/*[FromBody] WalaaPolicyCommand request*/)
        {
            _logger.LogInformation("WalaaPolicy Initiated");
            WalaaPolicyCommand request = new WalaaPolicyCommand();
            var response = await _mediator.Send(request);
            _logger.LogInformation("WalaaPolicy Completed");
            return Ok(response);
        }

        [HttpPost("WalaaTPLQuote", Name = "WalaaTPLQuote")]
        public async Task<ActionResult> WalaaTPLQuote(/*[FromBody] WalaaTPLQuoteCommand request*/)
        {
            _logger.LogInformation("WalaaTPLQuote Initiated");
            WalaaTPLQuoteCommand request = new WalaaTPLQuoteCommand();
            var response = await _mediator.Send(request);
            _logger.LogInformation("WalaaTPLQuote Completed");
            return Ok(response);
        }

        [HttpPost("WalaaComprehensiveQuote", Name = "WalaaComprehensiveQuote")]
        public async Task<ActionResult> WalaaComprehensiveQuote(/*[FromBody] WalaaComprehensiveQuoteCommand request*/)
        {
            _logger.LogInformation("WalaaComprehensiveQuote Initiated");
            WalaaComprehensiveQuoteCommand request = new WalaaComprehensiveQuoteCommand();
            var response = await _mediator.Send(request);
            _logger.LogInformation("WalaaComprehensiveQuote Completed");
            return Ok(response);
        }
    }
}
