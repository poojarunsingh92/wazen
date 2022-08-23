using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.AdditionalCoverage.Commands.CreateAdditionalCoverge;
using WazenCustomer.Application.Features.AdditionalCoverage.Commands.UpdateAdditionalCoverage;
using WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAdditionalCoverageByPolicyID;
using WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAllAdditionalCoverage;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AdditionalCoverageController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public AdditionalCoverageController(IMediator mediator, ILogger<AdditionalCoverageController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost(Name = "AddCustomerPolicyAdditionalCoverage")]
        public async Task<ActionResult> Create([FromBody] CreateAdditionalCoverageCommand createAdditionalCoverageCommand)
        {
            _logger.LogInformation("AddCustomerPolicyAdditionalCoverage Initiated");
            var customerPolicyDto = await _mediator.Send(createAdditionalCoverageCommand);
            _logger.LogInformation("AddCustomerPolicyAdditionalCoverage Completed");
            return Ok(customerPolicyDto);
        }

        [HttpGet("allCustomerPolicy", Name = "allCustomerPolicy")]
        public async Task<ActionResult> GetAllCustomerPolicy()
        {
            _logger.LogInformation("GetAllCustomerPolicy Initiated");
            var dtos = await _mediator.Send(new GetAllAdditionalCoverageListQuery());
            _logger.LogInformation("GetAllCustomerPolicy Initiated");
            return Ok(dtos);
        }

        [HttpGet("GetAdditionalCoverageByPolicyIDQuery", Name = "GetAdditionalCoverageByPolicyIDQuery")]
        public async Task<ActionResult> GetAdditionalCoveragebyPolicyIDQuery(Guid CustomerPolicyId)
        {
            _logger.LogInformation("GetAdditionalCoveragebyPolicyIDQuery Initiated");
            var getAdditionalCoverageByPolicyIDQuery = new GetAdditionalCoverageByPolicyIDQuery() { CustomerPolicyId = CustomerPolicyId };
            var dtos = await _mediator.Send(getAdditionalCoverageByPolicyIDQuery);
            _logger.LogInformation("GetAdditionalCoveragebyPolicyIDQuery Completed");
            return Ok(dtos);
        }

        //UpdateAdditionalCoverageByPolicyID
        [HttpPut("UpdateAdditionalCoverageByPolicyID", Name = "UpdateAdditionalCoverageByPolicyID")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAdditionalCoverageByPolicyID([FromBody] UpdateAdditionalCoverageCommand updateAdditionalCoverageCommand)
        {
            _logger.LogInformation("UpdateAdditionalCoverageByPolicyID Initiated");
            var response = await _mediator.Send(updateAdditionalCoverageCommand);
            _logger.LogInformation("UpdateAdditionalCoverageByPolicyID Completed");
            return Ok(response);
        }
    }
}