using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.ViolationTypes.Queries.GetViolationTypeDetailByID;

namespace WazenPolicy.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ViolationTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public ViolationTypeController(IMediator mediator, ILogger<ViolationTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //GetByID
        [HttpGet("GetViolationTypeByID", Name = "GetViolationTypeByID")]
        public async Task<ActionResult> GetViolationTypeByID(int ID)
        {
            _logger.LogInformation("GetViolationTypeByID Initiated");
            var getViolationTypeDetailByIDQuery = new GetViolationTypeDetailByIDQuery() { ID = ID };
            var response = await _mediator.Send(getViolationTypeDetailByIDQuery);
            _logger.LogInformation("GetViolationTypeByID  Completed");
            return Ok(response);
        }
    }
}
