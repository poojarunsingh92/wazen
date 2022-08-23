using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.ICQuoteResponses.Commands.CreateQuoteResponse;
using WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseByCustomerIDVehicleID;
using WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseFromRedis;

namespace WazenPolicy.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuoteResponseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public QuoteResponseController(IMediator mediator, ILogger<QuoteResponseController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddICQuoteResponse", Name = "AddICQuoteResponse")]
        public async Task<ActionResult> AddICQuoteResponse([FromBody] CreateQuoteResponseCommand createQuoteResponseCommand)
        {
            _logger.LogInformation("GetQuoteResponseCompreByCustomerId Initiated");
            var response = await _mediator.Send(createQuoteResponseCommand);
            _logger.LogInformation("GetQuoteResponseCompreByCustomerId Initiated");
            return Ok(response);
        }

        [HttpGet("GetQuoteResponseByCustomerIDVehicleID", Name = "GetQuoteResponseByCustomerIDVehicleID")]
        public async Task<ActionResult> GetQuoteResponseByCustomerIDVehicleID(Guid CustomerID, Guid VehicleID, string QuoteType)
        {
            _logger.LogInformation("GetQuoteResponseCompreByCustomerId Initiated");
            var getQuoteResponseByCustomerIDVehicleIDQuery = new GetQuoteResponseByCustomerIDVehicleIDQuery() { CustomerID = CustomerID, VehicleID = VehicleID, QuoteType= QuoteType };
            _logger.LogInformation("GetQuoteResponseCompreByCustomerId Initiated");
            return Ok(await _mediator.Send(getQuoteResponseByCustomerIDVehicleIDQuery));
        }

        [HttpGet("RedisGetQuoteResponseByCustomerIDVehicleID", Name = "RedisGetQuoteResponseByCustomerIDVehicleID")]
        public async Task<ActionResult> RedisGetQuoteResponseByCustomerIDVehicleID(Guid CustomerID, Guid VehicleID, string QuoteType)
        {
            _logger.LogInformation("RedisGetQuoteResponseCompreByCustomerId Initiated");
            var getQuoteResponseFromRedisQuery = new GetQuoteResponseFromRedisQuery() { CustomerID = CustomerID, VehicleID = VehicleID, QuoteType = QuoteType };
            _logger.LogInformation("RedisGetQuoteResponseCompreByCustomerId Initiated");
            return Ok(await _mediator.Send(getQuoteResponseFromRedisQuery));
        }
    }
}
