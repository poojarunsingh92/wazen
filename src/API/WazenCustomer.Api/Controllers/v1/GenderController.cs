using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.Genders.Queries.GetAllGenders;
using WazenCustomer.Application.Features.Genders.Queries.GetGenderById;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public GenderController(IMediator mediator, ILogger<GenderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allGender", Name = "allGender")]
        public async Task<ActionResult> GetAllGender()
        {
            var dtos = await _mediator.Send(new GetAllGenderListQuery());
            return Ok(dtos);
        }


        [HttpGet("GetGenderById", Name = "GetGenderById")]
        public async Task<ActionResult> GetGenderById(int Id)
        {
            var getTempDriverByIdQuery = new GetGenderByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getTempDriverByIdQuery));
        }
    }
}