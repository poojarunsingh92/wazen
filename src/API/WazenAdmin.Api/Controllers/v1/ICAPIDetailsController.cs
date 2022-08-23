using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsList;
using WazenAdmin.Application.Features.ICAPIDetails.Commands.CreateICAPIDetails;
using WazenAdmin.Application.Features.ICAPIDetails.Commands.UpdateICAPIDeatils;
using WazenAdmin.Application.Features.ICAPIDetails.Commands.DeleteICAPIDetails;
using WazenAdmin.Application.Features.ICAPIDetails.Queries;
using WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsByICID;
using WazenAdmin.Application.Features.ICAPIDetails.Commands.DeleteICAPIDetailsByICID;
using WazenAdmin.Application.Features.ICAPIDetails.Commands.UpdateICAPIDetailsByICID;
using WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsListByICID;
using WazenAdmin.Application.Responses;
using System.Collections.Generic;

namespace WazenAdmin.Api.Controllers
{

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ICAPIDetailsController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ICAPIDetailsController(IMediator mediator, ILogger<ICAPIDetailsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /*GetAllICAPIDetails*/
        //[Authorize]
        [HttpGet("all", Name = "GetAllICAPIDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllICAPIDetails()
        {
            _logger.LogInformation("GetAllICAPIDetails Initiated");
            var dtos = await _mediator.Send(new GetICAPIDetailsListQuery());
            _logger.LogInformation("GetAllICAPIDetails Completed");
            return Ok(dtos);
        }

        /*GetAllICAPIDetailsByICID*/
        //[Authorize]
        [HttpGet("GetAllICAPIDetailsByICID/{ICID}", Name = "GetAllICAPIDetailsByICID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllICAPIDetailsByICID(Guid ICID)
        {
            _logger.LogInformation("GetAllICAPIDetails Initiated");
            var getICAPIDetailsListByICIDQuery = new GetICAPIDetailsListByICIDQuery() { ICID = ICID };
            var dtos = await _mediator.Send(getICAPIDetailsListByICIDQuery);
            if(dtos.Data==null)
            {
                //var responseEmpty = new Response<List<Object>>();

                //responseEmpty.Data = new Response<List<object>>("success").Data;
                //responseEmpty.Succeeded = dtos.Succeeded;
                //responseEmpty.Message = dtos.Message;

                var responseEmpty = new Response<List<Object>>();

                responseEmpty.Data = new Response<List<Object>>(new List<object>(), dtos.Message).Data;
                responseEmpty.Succeeded = dtos.Succeeded;
                responseEmpty.Message = dtos.Message;
                return Ok(responseEmpty);
            }
            _logger.LogInformation("GetAllICAPIDetails Completed");
            return Ok(dtos);
        }

        /*AddICAPIDetails*/
        [HttpPost(Name = "AddICAPIDetails")]
        public async Task<ActionResult> Create([FromBody] CreateICAPIDetailsCommand createICAPIDetailsCommand)
        {
            _logger.LogInformation("AddICAPIDetails Initiated");
            var response = await _mediator.Send(createICAPIDetailsCommand);
            _logger.LogInformation("AddICAPIDetails Completed");
            return Ok(response);
        }

        /*UpdateICAPIDetails*/
        [HttpPut(Name = "UpdateICAPIDetails")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateICAPIDetailsCommand updateICAPIDetailsCommand)
        {
            _logger.LogInformation("UpdateICAPIDetails Initiated");
            var response = await _mediator.Send(updateICAPIDetailsCommand);
            _logger.LogInformation("UpdateICAPIDetails Completed");
            return Ok(response);
        }

        /*UpdateICAPIDetailsByICID*/
        [HttpPut("UpdateByICID", Name = "UpdateICAPIDetailsByICID")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateByICID([FromBody] UpdateICAPIDetailsByICIDCommand updateICAPIDetailsByICIDCommand)
        {
            _logger.LogInformation("UpdateICAPIDetails Initiated");
            var response = await _mediator.Send(updateICAPIDetailsByICIDCommand);
            _logger.LogInformation("UpdateICAPIDetails Completed");
            return Ok(response);
        }

        /*DeleteICAPIDetailsByID*/
        [HttpDelete("{ID}", Name = "DeleteICAPIDetails")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var deleteICAPIDetailsCommand = new DeleteICAPIDetailsCommand() { ID = ID };
            _logger.LogInformation("DeleteICAPIDetails Initiated");
            var del = await _mediator.Send(deleteICAPIDetailsCommand);
            _logger.LogInformation("DeleteICAPIDetails Completed");
            return Ok(del);
        }

        /*DeleteICAPIDetailsByICID*/
        [HttpDelete("DeleteByICID/{ICID}", Name = "DeleteICAPIDetailsByICID")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteByICID(Guid ICID)
        {
            var deleteICAPIDetailsByICIDCommand = new DeleteICAPIDetailsByICIDCommand() { ICID = ICID };
            _logger.LogInformation("DeleteICAPIDetailsByICID Initiated");
            var del = await _mediator.Send(deleteICAPIDetailsByICIDCommand);
            _logger.LogInformation("DeleteICAPIDetailsByICID Completed");
            return Ok(del);
        }

        /*GetICAPIDetailsByID*/
        [HttpGet("{ID}", Name = "GetICAPIDetailsById")]
        public async Task<ActionResult> GetICAPIDetailsById(Guid ID)
        {
            _logger.LogInformation("GetICAPIDetailsById Initiated");
            var getICAPIDetailsQuery = new GetICAPIDetailsQuery() { ID = ID };
            _logger.LogInformation("GetICAPIDetailsById Completed");
            return Ok(await _mediator.Send(getICAPIDetailsQuery));
        }

        /*GetICAPIDetailsByICID*/
        [HttpGet("ICAPIDetailsByICID/{ICID}", Name = "GetICAPIDetailsByICID")]
        public async Task<ActionResult> GetICAPIDetailsByICID(Guid ICID)
        {
            _logger.LogInformation("GetICAPIDetailsByICID Initiated");
            var getICAPIDetailsByICIDQuery = new GetICAPIDetailsByICIDQuery() { ICID = ICID };
            _logger.LogInformation("GetICAPIDetailsByICID Completed");
            return Ok(await _mediator.Send(getICAPIDetailsByICIDQuery));
        }
    }
}
