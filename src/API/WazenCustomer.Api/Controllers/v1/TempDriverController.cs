using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.Educations.Queries.GetAllEducations;
using WazenCustomer.Application.Features.Educations.Queries.GetEducationById;
using WazenCustomer.Application.Features.MedicalIssues.Queries.GetAllMedicalIssues;
using WazenCustomer.Application.Features.TempDrivers.Commands.AddAndUpdateDriverDetail;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetAllTempDrivers;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetDriverVehicleViolationDetailsByVehicleId;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetTempDriverById;
using WazenCustomer.Application.Features.VehiclePurposes.Queries.GetAllVehiclePurposes;
using WazenCustomer.Application.Features.VehiclePurposes.Queries.GetVehiclePurposeById;
using WazenCustomer.Application.Features.VehicleViolations.Commands.AddVehicleViolation;
using WazenCustomer.Application.Features.VehicleViolations.Commands.DeleteVehicleViolation;
using WazenCustomer.Application.Features.VehicleViolations.Commands.UpdateVehicleViolation;
using WazenCustomer.Application.Features.ViolationTypes.Queries.GetAllViolationTypes;
using WazenCustomer.Application.Features.ViolationTypes.Queries.GetViolationTypeById;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TempDriverController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public TempDriverController(IMediator mediator, ILogger<TempVehicleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        

        [HttpGet("tempDriverById", Name = "GetTempDriverById")]
        public async Task<ActionResult> GetTempDriverById(Guid Id)
        {
            var getTempDriverByIdQuery = new GetTempDriverByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getTempDriverByIdQuery));
        }

        [HttpGet("allTempDriver", Name = "GetAllTempDriver")]
        public async Task<ActionResult> GetAllTempDriver()
        {
            var dtos = await _mediator.Send(new GetAllTempDriverListQuery());
            return Ok(dtos);
        }

        [HttpGet("allEducation", Name = "GetAllEducation")]
        public async Task<ActionResult> GetAllEducation()
        {
            var dtos = await _mediator.Send(new GetAllEducationListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetEducationByIdQuery", Name = "GetEducationByIdQuery")]
        public async Task<ActionResult> GetEducationByIdQuery(int Id)
        {
            var getEducationByIdQuery = new GetEducationByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getEducationByIdQuery));
        }

        [HttpGet("allViolationType", Name = "GetAllViolationType")]
        public async Task<ActionResult> GetAllViolationType()
        {
            var dtos = await _mediator.Send(new GetAllViolationTypeListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetViolationType", Name = "GetViolationType")]
        public async Task<ActionResult> GetViolationType(int Id)
        {
            var getOccupationQuery = new GetViolationTypeByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getOccupationQuery));
        }

        [HttpGet("allMedicalIssue", Name = "GetAllMedicalIssue")]
        public async Task<ActionResult> GetAllMedicalIssue()
        {
            var dtos = await _mediator.Send(new GetAllMedicalIssuesQuery());
            return Ok(dtos);
        }

        [HttpGet("allVehiclePurpose", Name = "GetAllVehiclePurpose")]
        public async Task<ActionResult> GetAllVehiclePurpose()
        {
            var dtos = await _mediator.Send(new GetAllVehiclePurposeListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetVehiclePurpose", Name = "GetVehiclePurpose")]
        public async Task<ActionResult> GetVehiclePurpose(int Id)
        {
            var getVehiclePurposeQuery = new GetVehiclePurposeByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getVehiclePurposeQuery));
        }

        [HttpPost("AddVehicleViolation", Name = "AddVehicleViolation")]
        public async Task<ActionResult> AddVehicleViolation([FromBody] CreateVehicleViolationCommand createVehicleViolationCommand)
        {
            var id = await _mediator.Send(createVehicleViolationCommand);
            return Ok(id);
        }

        [HttpPut("UpdateVehicleViolation", Name = "UpdateVehicleViolation")]
        public async Task<ActionResult> Update([FromBody] UpdateVehicleViolationCommand updatevehicleViolationCommand)
        {
            var response = await _mediator.Send(updatevehicleViolationCommand);
            return Ok(response);
        }

        [HttpDelete("DeleteVehicleViolation/{Id}", Name = "DeleteVehicleViolation")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteVehicleViolation(Guid Id)
        {
            var deleteVehicleViolation = new DeleteVehicleViolationCommand() { Id = Id };
            await _mediator.Send(deleteVehicleViolation);
            return NoContent();
        }

        [HttpPost]
        [Route("AddandUpdateDriver")]
        public async Task<ActionResult> AddandUpdateDriver([FromBody]CreateTempDriverDetailCommand data)
         {
            var dtos = await _mediator.Send(data);
            return Ok(dtos);
        }

        [HttpGet("DriverVehicleDetailByVehicleId", Name = "DriverVehicleDetailByVehicleId")]
        public async Task<ActionResult> DriverVehicleDetailByVehicleId(Guid VehicleId)
        {
            var getTempDriverByIdQuery = new GetDriverVehicleViolationDetailsByVehicleIdQuery()
            {
                VehicleId = VehicleId
            };
            return Ok(await _mediator.Send(getTempDriverByIdQuery));
        }
    }
}