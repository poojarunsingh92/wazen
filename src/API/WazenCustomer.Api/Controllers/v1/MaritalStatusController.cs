using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.MaritalStatuses.Queries.GetAllMaritalStatus;
using WazenCustomer.Application.Features.MaritalStatuses.Queries.GetMaritalStatusById;

namespace WazenCustomer.Api.Controllers.v1
{

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MaritalStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public MaritalStatusController(IMediator mediator, ILogger<MaritalStatusController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allMaritalStatus", Name = "allMaritalStatus")]
        public async Task<ActionResult> GetAllMaritalStatus()
        {
            var dtos = await _mediator.Send(new GetAllMaritalStatusListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetMaritalStatusTypeQuery", Name = "GetMaritalStatusTypeQuery")]
        public async Task<ActionResult> GetMaritalStatusTypeQuery(int Id)
        {
            var getMaritalStatusTypeQuery = new GetMaritalStatusByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getMaritalStatusTypeQuery));
        }
    }
}