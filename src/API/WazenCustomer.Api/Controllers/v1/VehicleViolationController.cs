using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.VehicleViolations.Commands.AddVehicleViolation;
using WazenCustomer.Application.Features.VehicleViolations.Commands.DeleteVehicleViolation;
using WazenCustomer.Application.Features.VehicleViolations.Commands.UpdateVehicleViolation;
using WazenCustomer.Application.Features.VehicleViolations.Queries.GetAllVehicleViolations;
using WazenCustomer.Application.Features.VehicleViolations.Queries.GetVehicleViolationById;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VehicleViolationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public VehicleViolationController(IMediator mediator, ILogger<VehicleViolationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CreateVehicleViolation", Name = "CreateVehicleViolation")]
        public async Task<ActionResult> CreateVehicleViolation([FromBody] CreateVehicleViolationCommand createVehicleViolationCommand)
        {
            var id = await _mediator.Send(createVehicleViolationCommand);
            return Ok(id);
        }

        [HttpDelete("DeleteVehicleViolationByID/{Id}", Name = "DeleteVehicleViolationByID")]
        public async Task<ActionResult> DeleteVehicleViolationByID(Guid Id)
        {
            var deleteVehicleViolation = new DeleteVehicleViolationCommand() { Id = Id };
            var response = await _mediator.Send(deleteVehicleViolation);
            return Ok(response);
        }

        [HttpPut("UpdateViolation", Name = "UpdateViolation")]
        public async Task<ActionResult> UpdateViolation([FromBody] UpdateVehicleViolationCommand updateVehicleViolationCommand)
        {
            var response = await _mediator.Send(updateVehicleViolationCommand);
            return Ok(response);
        }

        [HttpGet("GetAllVehicleViolation", Name = "GetAllVehicleViolation")]
        public async Task<ActionResult> GetAllVehicleViolation()
        {
            var dtos = await _mediator.Send(new GetAllVehicleViolationListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetVehicleViolationByID", Name = "GetVehicleViolationByID")]
        public async Task<ActionResult> GetVehicleViolationByID(Guid Id)
        {
            var getVehicleViolationQuery = new GetVehicleViolationByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getVehicleViolationQuery));
        }
    }
}