using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.CancellationRequests.Queries.GetCancellationRequestList;
using WazenTransactions.Application.Features.CancellationRequests.Commands.CreateCancellationRequest;
using WazenTransactions.Application.Features.CancellationRequests.Commands.DeleteCancellationRequest;
using WazenTransactions.Application.Features.CancellationRequests.Commands.UpdateCancellationRequest;
using WazenTransactions.Application.Features.CancellationRequests.Queries.GetCancellationRequestDetail;
using WazenTransactions.Application.Features.CancellationRequests.Queries.GetCancellationRequestList;

namespace WazenCustomer.Api.Controllers.v1
{

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CancellationRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CancellationRequestController(IMediator mediator, ILogger<CancellationRequestController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //GetAll/GetList
        [HttpGet("all", Name = "GetAllCancellationRequests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllCustomerPolicies()
        {
            _logger.LogInformation("GetAllCancellationRequest Initiated");
            var customerPoliciesDto = await _mediator.Send(new GetCancellationRequestListQuery());
            _logger.LogInformation("GetAllCancellationRequest Completed");
            return Ok(customerPoliciesDto);
        }

        //GetByID
        [HttpGet(Name = "GetCancellationRequestByID")]
        public async Task<ActionResult> GetCancellationRequestByID(Guid ID)
        {
            _logger.LogInformation("GetCancellationRequestByID Initiated");
            var getPolicyDetailQuery = new GetCancellationRequestDetailQuery() { ID = ID };
            var response = await _mediator.Send(getPolicyDetailQuery);
            _logger.LogInformation("GetCancellationRequestByID Completed");
            return Ok(response);
        }

        //Add/CreateCancellationRequest
        [HttpPost(Name = "AddCancellationRequest")]
        public async Task<ActionResult> Create([FromBody] CreateCancellationRequestCommand createCancellationRequestCommand)
        {
            _logger.LogInformation("AddCancellationRequest Initiated");
            var response = await _mediator.Send(createCancellationRequestCommand);
            _logger.LogInformation("AddCancellationRequest Completed");
            return Ok(response);
        }

        //UpdateCancellationRequest
        [HttpPut("UpdateCancellationRequest", Name = "UpdateCancellationRequest")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCancellationRequest([FromBody] UpdateCancellationRequestCommand updateCancellationRequestCommand)
        {
            _logger.LogInformation("UpdateCancellationRequest Initiated");
            var response = await _mediator.Send(updateCancellationRequestCommand);
            _logger.LogInformation("UpdateCancellationRequest Completed");
            return Ok(response);
        }

        //DeleteCancellationRequestByID
        [HttpDelete("{ID}", Name = "DeleteCancellationRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var deleteCancellationRequestCommand = new DeleteCancellationRequestCommand() { ID = ID };
            _logger.LogInformation("DeleteCancellationRequest Initiated");
            var response = await _mediator.Send(deleteCancellationRequestCommand);
            _logger.LogInformation("DeleteCancellationRequest Completed");
            return Ok(response);
        }
    }
}
