using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.AddtionalCoverages.Commands.AddAdditionalCoverage;
using WazenTransactions.Application.Features.AddtionalCoverages.Commands.DeleteAdditionalCoverage;

namespace WazenTransactions.Api.Controllers.v1
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

        [HttpPost("AddAdditionalCoverage", Name = "AddAdditionalCoverage")]
        public async Task<ActionResult> AddAdditionalCoverage([FromBody] AddAdditionalCoverageCommand addAdditionalCoverageCommand)
        {
            var customerDto = await _mediator.Send(addAdditionalCoverageCommand);
            return Ok(customerDto);
        }


        [HttpDelete("DeleteAdditionalCoverage/{ID}", Name = "DeleteAdditionalCoverage")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAdditionalCoverage(Guid ID)
        {
            var deleteadditionalCoverage = new DeleteAdditionalCoverageCommand() { ID = ID };
            var response = await _mediator.Send(deleteadditionalCoverage);
            return Ok(response);
        }
    }
}
