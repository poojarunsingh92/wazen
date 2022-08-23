using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.TempVehicles.Commands.CreateTempVehicle;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetAllTempVehicles;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByCustomerId;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleBySequenceNumberAndCustomerId;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByVehicleId;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicy;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleRenewPolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleUpgradePolicyListByCustomerID;
using WazenCustomer.Application.Features.Vehicles.Queries.CreateVehicleDriverByTempCustomerId;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TempVehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public TempVehicleController(IMediator mediator, ILogger<TempVehicleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddTempVehicle")]
        public async Task<ActionResult> Create([FromBody] CreateTempVehicleCommand createTempVehicleCommand)
        {
            var vehicleDto = await _mediator.Send(createTempVehicleCommand);
            return Ok(vehicleDto);
        }

        [HttpGet("allTempVehicle", Name = "GetAllTempVehicle")]
        public async Task<ActionResult> GetAllTempVehicle()
        {
            var dtos = await _mediator.Send(new GetAllTempVehicleListQuery());
            return Ok(dtos);
        }

        [HttpGet("tempVehicleByVehicleId", Name = "GetTempVehicleByVehicleId")]
        public async Task<ActionResult> GetTempCustomerByCustomerId(Guid Id)
        {
            var getTempVehicleByVehicleIdQuery = new GetTempVehicleByVehicleIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getTempVehicleByVehicleIdQuery));
        }

        [HttpGet("tempVehicleByCustomerId", Name = "GetTempVehicleByCustomerId")]
        public async Task<ActionResult> GetTempVehicleByCustomerId(Guid CustomerId)
        {
            var getTempVehicleByVehicleIdQuery = new GetTempVehicleByCustomerIdQuery()
            {
                CustomerId = CustomerId
            };
            return Ok(await _mediator.Send(getTempVehicleByVehicleIdQuery));
        }

        [HttpGet("GetVehicleDriverViolationListByCustomerId", Name = "GetVehicleDriverViolationListByCustomerId")]
        public async Task<ActionResult> GetVehicleDriverViolationListByCustomerId(Guid CustomerId)
        {
            var getTempVehicleByVehicleIdQuery = new GetAllListCommand()
            {
                CustomerID = CustomerId
            };
            return Ok(await _mediator.Send(getTempVehicleByVehicleIdQuery));
        }

        [HttpGet("GetVehiclePolicyListByCustomerID", Name = "GetVehiclePolicyListByCustomerID")]
        public async Task<ActionResult> GetVehiclePolicyListByCustomerID(Guid CustomerID)
        {
            var getVehiclePolicyListByCustomerIDQuery = new GetVehiclePolicyListByCustomerIDQuery() { CustomerID=CustomerID};
            return Ok(await _mediator.Send(getVehiclePolicyListByCustomerIDQuery));
        }

        [HttpGet("GetVehicleRenewPolicyListByCustomerID", Name = "GetVehicleRenewPolicyListByCustomerID")]
        public async Task<ActionResult> GetVehicleRenewPolicyListByCustomerID(Guid CustomerID)
        {
            var getVehicleRenewPolicyListByCustomerIDQuery = new GetVehicleRenewPolicyListByCustomerIDQuery() { CustomerID = CustomerID };
            return Ok(await _mediator.Send(getVehicleRenewPolicyListByCustomerIDQuery));
        }

        [HttpGet("GetVehicleUpgradePolicyListByCustomerID", Name = "GetVehicleUpgradePolicyListByCustomerID")]
        public async Task<ActionResult> GetVehicleUpgradePolicyListByCustomerID(Guid CustomerID)
        {
            var getVehicleUpgradePolicyListByCustomerIDQuery = new GetVehicleUpgradePolicyListByCustomerIDQuery() { CustomerID = CustomerID };
            return Ok(await _mediator.Send(getVehicleUpgradePolicyListByCustomerIDQuery));
        }

        [HttpGet("tempVehicleBySequenceNumberAndCustomerId", Name = "tempVehicleBySequenceNumberAndCustomerId")]
        public async Task<ActionResult> tempVehicleBySequenceNumberAndCustomerId(string SequenceNumber, Guid CustomerId)
        {
            var getTempVehicleBySeqNumCustomIdQuery = new GetTempVehicleBySequenceNumberAndCustomerIdQuery()
            {
                SequenceNumber = SequenceNumber,
                CustomerID = CustomerId
            };
            return Ok(await _mediator.Send(getTempVehicleBySeqNumCustomIdQuery));
        }

        [HttpGet("CreateVehicleDriverByTempCustomerId", Name = "CreateVehicleDriverByTempCustomerId")]
        public async Task<ActionResult> CreateVehicleDriverByTempCustomerId(Guid TempCustomerId, Guid CustomerId)
        {
            var createVehicleDriverByCustomerId = new CreateVehicleDriverByCustomerIdQuery() { TempCustomerID = TempCustomerId, CustomerId=CustomerId };
            var response = await _mediator.Send(createVehicleDriverByCustomerId);
            return Ok(response);
        }

        [HttpGet("GetVehiclePolicy", Name = "GetVehiclePolicy")]
        public async Task<ActionResult> GetVehiclePolicy(Guid CustomerID, string SequenceNumber, string PolicyNumber, string InsuranceCompanyName)
        {
            var getVehiclePolicy = new GetVehiclePolicyQuery() { CustomerID = CustomerID, SequenceNumber = SequenceNumber, PolicyNumber = PolicyNumber, InsuranceCompanyName = InsuranceCompanyName };
            var response = await _mediator.Send(getVehiclePolicy);
            return Ok(response);
        }
    }
}