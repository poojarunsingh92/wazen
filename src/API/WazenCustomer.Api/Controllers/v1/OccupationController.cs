using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.Occupations.Queries.GetAllOccupations;
using WazenCustomer.Application.Features.Occupations.Queries.GetOccupationById;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public OccupationController(IMediator mediator, ILogger<OccupationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allOccupation", Name = "allOccupation")]
        public async Task<ActionResult> GetAllOccupation()
        {
            var dtos = await _mediator.Send(new GetAllOccupationListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetOccupationQuery", Name = "GetOccupationQuery")]
        public async Task<ActionResult> GetOccupationQuery(int Id)
        {
            var getOccupationQuery = new GetOccupationByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getOccupationQuery));
        }

    }
}