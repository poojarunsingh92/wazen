using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.Complaints.Commands.CreateComplaint;
using WazenAdmin.Application.Features.Complaints.Commands.DeleteComplaint;
using WazenAdmin.Application.Features.Complaints.Commands.DeleteComplaintByCustomerID;
using WazenAdmin.Application.Features.Complaints.Commands.UpdateComplaint;
using WazenAdmin.Application.Features.Complaints.Commands.UpdateComplaintByCustomerID;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintDetail;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintDetailByCustomerID;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintList;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintListByCustomerID;

namespace WazenAdmin.Api.Controllers.v1
{
    
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public ComplaintController(IMediator mediator, ILogger<ComplaintController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /*GetAllComplaints*/
        //[Authorize(Roles = "System Admin")]
        [HttpGet("all", Name = "GetAllComplaints")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllComplaints()
        {
            _logger.LogInformation("GetAllComplaints Initiated");
            var dtos = await _mediator.Send(new GetComplaintListQuery());
            _logger.LogInformation("GetAllComplaints Completed");
            return Ok(dtos);
        }

        /*GetAllComplaints*/
        [HttpGet("GetAllComplaintsByCustomerID/{CustomerID}", Name = "GetAllComplaintsByCustomerID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllComplaintsByCustomerID(Guid CustomerID)
        {
            _logger.LogInformation("GetAllComplaintsByCustomerID Initiated");
            var getComplaintByCustomerIDListQuery = new GetComplaintByCustomerIDListQuery() { CustomerID = CustomerID };
            var dtos = await _mediator.Send(getComplaintByCustomerIDListQuery);
            _logger.LogInformation("GetAllComplaintsByCustomerID Completed");
            return Ok(dtos);
        }

        /*GetComplaintByID*/
        [HttpGet("GetComplaintByID/{ID}", Name = "GetComplaintByID")]
        public async Task<ActionResult> GetComplaintByID(int ID)
        {
            var getComplaintDetailQuery = new GetComplaintDetailQuery() { ID = ID };
            return Ok(await _mediator.Send(getComplaintDetailQuery));
        }

        /*GetComplaintByCustomerID*/
        [HttpGet("GetComplaintByCustomerID/{CustomerID}", Name = "GetComplaintByCustomerID")]
        public async Task<ActionResult> GetComplaintByCustomerID(Guid CustomerID)
        {
            var getComplaintByCustomerIDDetailQuery = new GetComplaintByCustomerIDDetailQuery() { CustomerID = CustomerID };
            return Ok(await _mediator.Send(getComplaintByCustomerIDDetailQuery));
        }

        /*AddComplaint*/
        [HttpPost(Name = "AddComplaint")]
        public async Task<ActionResult> Create([FromBody] CreateComplaintCommand createComplaintCommand)
        {
            var response = await _mediator.Send(createComplaintCommand);
            return Ok(response);
        }

        /*UpdateComplaint*/
        [HttpPut(Name = "UpdateComplaint")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateComplaintCommand updateComplaintCommand)
        {
            _logger.LogInformation("UpdateComplaint Initiated");

            var response = await _mediator.Send(updateComplaintCommand);
            _logger.LogInformation("UpdateComplaint Completed");
            return Ok(response);
        }

        /*UpdateComplaintByCustomerID*/
        [HttpPut("UpdateComplaintByCustomerID", Name = "UpdateComplaintByCustomerID")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateComplaintByCustomerID([FromBody] UpdateComplaintByCustomerIDCommand updateComplaintByCustomerIDCommand)
        {
            _logger.LogInformation("UpdateComplaintByCustomerID Initiated");
            var response = await _mediator.Send(updateComplaintByCustomerIDCommand);
            _logger.LogInformation("UpdateComplaintByCustomerID Completed");
            return Ok(response);
        }

        /*DeleteComplaint*/
        [HttpDelete("{ID}", Name = "DeleteComplaint")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int ID)
        {
            _logger.LogInformation("deleteComplaint Initiated");
            var deleteComplaintCommand = new DeleteComplaintCommand() { ID = ID };
            var response = await _mediator.Send(deleteComplaintCommand);
            _logger.LogInformation("deleteComplaint Completed");

            return Ok(response);
        }

        /*DeleteComplaintByCustomerID*/
        [HttpDelete("DeleteComplaintByCustomerID/{CustomerID}", Name = "DeleteComplaintByCustomerID")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteComplaintByCustomerID(Guid CustomerID)
        {
            _logger.LogInformation("deleteComplaintByCustomerID Initiated");
            var deleteComplaintCommand = new DeleteComplaintByCustomerIDCommand() { CustomerID = CustomerID };
            var response = await _mediator.Send(deleteComplaintCommand);
            _logger.LogInformation("deleteComplaintByCustomerID Completed");

            return Ok(response);
        }
    }
}
