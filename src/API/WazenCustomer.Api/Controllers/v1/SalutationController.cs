using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.Salutations.Queries.GetAllSalutations;
using WazenCustomer.Application.Features.Salutations.Queries.GetSalutationById;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SalutationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public SalutationController(IMediator mediator, ILogger<SalutationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allSalutation", Name = "allSalutation")]
        public async Task<ActionResult> GetAllSalutation()
        {
            var dtos = await _mediator.Send(new GetAllSalutationListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetSalutationQuery", Name = "GetSalutationQuery")]
        public async Task<ActionResult> GetSalutationQuery(int Id)
        {
            var getSalutationQuery = new GetSalutationByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getSalutationQuery));
        }
    }
}