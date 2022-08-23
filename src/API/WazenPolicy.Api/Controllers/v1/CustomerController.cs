using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.Customers.Queries.GetCustomerDetailByID;

namespace WazenPolicy.Api.Controllers.v1
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

        //GetByID
        [HttpGet("GetCustomerByID", Name = "GetCustomerByID")]
        public async Task<ActionResult> GetCustomerByID(Guid ID)
        {
            _logger.LogInformation("GetCustomerByID Initiated");
            var getCustomerDetailQuery = new GetCustomerDetailByIDQuery() { ID = ID };
            var response = await _mediator.Send(getCustomerDetailQuery);
            _logger.LogInformation("GetCustomerByID  Completed");
            return Ok(response);
        }
    }
}
