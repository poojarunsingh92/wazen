using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote;
using WazenPolicy.Application.Features.Malath.Commands.MalathPolicy;
using WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote;

namespace WazenPolicy.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MalathController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public MalathController(IMediator mediator, ILogger<MalathController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("MalathPolicy", Name = "MalathPolicy")]
        public async Task<ActionResult> GetMalathPolicy(/*[FromBody] MalathPolicyCommand request*/)
        {
            _logger.LogInformation("GetMalathPolicy Initiated");
            MalathPolicyCommand request = new MalathPolicyCommand();
            var response = await _mediator.Send(request);
            _logger.LogInformation("GetMalathPolicy Completed");
            return Ok(response);
        }

        [HttpPost("MalathTPLQuote", Name = "MalathTPLQuote")]
        public async Task<ActionResult> WalaaTPLQuote(/*[FromBody] MalathTPLQuoteCommand request*/)
        {
            _logger.LogInformation("WalaaTPLQuote Initiated");
            MalathTPLQuoteCommand request = new MalathTPLQuoteCommand();
            var response = await _mediator.Send(request);
            _logger.LogInformation("WalaaTPLQuote Completed");
            return Ok(response);
        }

        [HttpPost("MalathComprehensiveQuote", Name = "MalathComprehensiveQuote")]
        public async Task<ActionResult> MalathComprehensiveQuote(/*[FromBody] MalathComprehensiveQuoteCommand request*/)
        {
            _logger.LogInformation("MalathComprehensiveQuote Initiated");
            MalathComprehensiveQuoteCommand request = new MalathComprehensiveQuoteCommand();
            var response = await _mediator.Send(request);
            _logger.LogInformation("MalathComprehensiveQuote Initiated");
            return Ok(response);
        }
    }
}
