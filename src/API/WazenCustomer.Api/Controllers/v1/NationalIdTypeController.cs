using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.NationalIdTypes.Queries.GetAllNationalIdTypes;
using WazenCustomer.Application.Features.NationalIdTypes.Queries.GetNationalIdTypeById;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class NationalIdTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public NationalIdTypeController(IMediator mediator, ILogger<NationalIdTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allNationalIdType", Name = "allNationalIdType")]
        public async Task<ActionResult> GetAllNationalIdType()
        {
            var dtos = await _mediator.Send(new GetAllNationalIdTypesListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetNationalIdTypeQuery", Name = "GetNationalIdTypeQuery")]
        public async Task<ActionResult> GetNationalIdTypeQuery(int Id)
        {
            var getNationalIdTypeQuery = new GetNationalIdTypeByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getNationalIdTypeQuery));
        }

    }
}