using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.Vehicles.Queries.GetAllVehicles;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleById;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerID;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public VehicleController(IMediator mediator, ILogger<VehicleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allVehicles", Name = "allVehicles")]
        public async Task<ActionResult> GetAllVehicles()
        {
            var dtos = await _mediator.Send(new GetAllVehicleListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetVehicleListByCustomerID", Name = "GetVehicleListByCustomerID")]
        public async Task<ActionResult> GetVehicleListByCustomerID(Guid CustomerID)
        {
            _logger.LogInformation("GetVehicleListByCustomerID Initiated");
            var getVehicleListByCustomerID = new GetVehicleListByCustomerIDQuery() { CustomerID = CustomerID };
            var dtos = await _mediator.Send(getVehicleListByCustomerID);
            _logger.LogInformation("GetVehicleListByCustomerID Completed");
            return Ok(dtos);
        }

        [HttpGet("GetVehicleById", Name = "GetVehicleById")]
        public async Task<ActionResult> GetVehicleById(Guid Id)
        {
            var getVehicleById = new GetVehicleByIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getVehicleById));
        }

        [HttpGet("GetVehicleBySequenceNumberAndCustomerID", Name = "GetVehicleBySequenceNumberAndCustomerID")]
        public async Task<ActionResult> GetVehicleBySequenceNumberAndCustomerID(string SequenceNumber, Guid CustomerID)
        {
            _logger.LogInformation("GetVehicleBySequenceNumberAndCustomerID Initiated");
            var getVehicleBySequenceNumberAndCustomerIDQuery = new GetVehicleBySequenceNumberAndCustomerIDQuery() { SequenceNumber = SequenceNumber, CustomerID = CustomerID };
            var dtos = await _mediator.Send(getVehicleBySequenceNumberAndCustomerIDQuery);
            _logger.LogInformation("GetVehicleBySequenceNumberAndCustomerID Completed");
            return Ok(dtos);
        }
    }
}