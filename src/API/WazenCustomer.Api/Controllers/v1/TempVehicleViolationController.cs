using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.TempVehicleViolations.Commands.AddTempVehicleViolations;
using WazenCustomer.Application.Features.TempVehicleViolations.Commands.DeleteTempVehicleViolation;
using WazenCustomer.Application.Features.TempVehicleViolations.Commands.UpdateTempVehicleViolation;
using WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetAllTempVehicleViolations;
using WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationById;
using WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationsByVehicleId;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TempVehicleViolationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public TempVehicleViolationController(IMediator mediator, ILogger<TempVehicleViolationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddTempVehicleViolation", Name = "AddTempVehicleViolation")]
        public async Task<ActionResult> AddTempVehicleViolation([FromBody] CreateTempVehicleViolationCommand createTempVehicleViolationCommand)
        {
            var id = await _mediator.Send(createTempVehicleViolationCommand);
            return Ok(id);
        }

        [HttpDelete("DeleteTempVehicleViolation/{Id}", Name = "DeleteTempVehicleViolation")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteTempVehicleViolation(Guid Id)
        {
            var deleteTempVehicleViolation = new DeleteTempVehicleViolationCommand() { Id = Id };
            var response = await _mediator.Send(deleteTempVehicleViolation);
            return Ok(response);
        }

        [HttpPut("UpdateTempVehicleViolation", Name = "UpdateTempVehicleViolation")]
        public async Task<ActionResult> Update([FromBody] UpdateTempVehicleViolationCommand updateTempVehicleViolationCommand)
        {
            var response = await _mediator.Send(updateTempVehicleViolationCommand);
            return Ok(response);
        }

        [HttpGet("allTempVehicleViolation", Name = "allTempVehicleViolation")]
        public async Task<ActionResult> GetAllTempVehicleViolation()
        {
            var dtos = await _mediator.Send(new GetAllTempVehicleViolationListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetTempVehicleViolation", Name = "GetTempVehicleViolation")]
        public async Task<ActionResult> GetTempVehicleViolation(Guid Id)
        {
            var getTempVehicleViolationQuery = new GetTempVehicleViolationByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getTempVehicleViolationQuery));
        }

        [HttpGet("GetTempVehicleViolationByVehicleId", Name = "GetTempVehicleViolationByVehicleId")]
        public async Task<ActionResult> GetTempVehicleViolationByVehicleId(Guid VehicleId)
        {
            var getTempVehicleViolationQueryByVehicleId = new GetTempVehicleViolationByVehicleIdQuery()
            {
               VehicleId= VehicleId
            };
            return Ok(await _mediator.Send(getTempVehicleViolationQueryByVehicleId));
        }
    }
}