using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.AboutUs.Commands.CreateAboutUs;
using WazenAdmin.Application.Features.AboutUs.Commands.DeleteAboutUs;
using WazenAdmin.Application.Features.AboutUs.Commands.UpdateAboutUs;
using WazenAdmin.Application.Features.AboutUs.Queries.GetAboutUsDetail;
using WazenAdmin.Application.Features.AboutUs.Queries.GetAboutUsList;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public AboutUsController(IMediator mediator, ILogger<AboutUsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //GetById
        [HttpGet("UpdatedOn19thAugust22_03_45PM", Name = "UpdatedOn19thAugust22_03_45PM")]
        public async Task<ActionResult> UpdatedOn19thAugust22_03_45PM()
        {
            return Ok();
        }

        //GetAll
        [HttpGet("all", Name = "GetAllAboutUs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllAboutUs()
        {
            _logger.LogInformation("GetAllAboutUs Initiated");
            var dtos = await _mediator.Send(new GetAboutUsListQuery());
            _logger.LogInformation("GetAllAboutUs Completed");
            return Ok(dtos);
        }

        //GetById
        [HttpGet("GetAboutUsByID/{ID}", Name = "GetAboutUsByID")]
        public async Task<ActionResult> GetAboutUsById(Guid ID)
        {
            var getAboutUsDetailQuery = new GetAboutUsDetailQuery() { ID = ID };
            return Ok(await _mediator.Send(getAboutUsDetailQuery));
        }

        //Add
        [HttpPost(Name = "AddAboutUs")]
        public async Task<ActionResult> Create([FromBody] CreateAboutUsCommand createAboutUsCommand)
        {
            var response = await _mediator.Send(createAboutUsCommand);
            return Ok(response);
        }

        //Update
        [HttpPut(Name = "UpdateAboutUs")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateAboutUsCommand updateAboutUsCommand)
        {
            _logger.LogInformation("UpdateAboutUs Initiated");

            var response = await _mediator.Send(updateAboutUsCommand);
            _logger.LogInformation("UpdateAboutUs Completed");
            return Ok(response);
        }

        //Delete
        [HttpDelete("{Id}", Name = "DeleteAboutUs")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            _logger.LogInformation("DeleteAboutUs Initiated");
            var deleteCommand = new DeleteAboutUsCommand() { ID = ID };
            await _mediator.Send(deleteCommand);
            _logger.LogInformation("DeleteAboutUs Completed");

            return NoContent();
        }
    }
}
