using WazenAdmin.Application.Features.StaticContents.Commands.CreateStaticContent;
using WazenAdmin.Application.Features.StaticContents.Commands.DeleteStaticContent;
using WazenAdmin.Application.Features.StaticContents.Commands.UpdateStaticContent;
using WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentDetail;
using WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace WazenAdmin.Api.Controllers.v1
{
    //[Authorize(Roles="System Admin")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StaticContentController : ControllerBase
    {       
       
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public StaticContentController(IMediator mediator, ILogger<StaticContentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpGet("all", Name = "GetAllStaticContents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllStaticContents()
        {
            _logger.LogInformation("GetAllStaticContents Initiated");
            var dtos = await _mediator.Send(new GetStaticContentsListQuery());
            _logger.LogInformation("GetAllStaticContents Completed");
            return Ok(dtos);
        }

        [HttpPost(Name = "AddStaticContent")]
        public async Task<ActionResult> Create([FromBody] CreateStaticContentCommand createStaticContentCommand)
        {
            _logger.LogInformation("AddStaticContent Initiated");
            var response = await _mediator.Send(createStaticContentCommand);
            _logger.LogInformation("AddStaticContent Completed");
            return Ok(response);
        }

        [HttpPut(Name = "UpdateStaticContent")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateStaticContentCommand updateStaticContentCommand)
        {
            _logger.LogInformation("UpdateStaticContent Initiated");
            var response = await _mediator.Send(updateStaticContentCommand);
            _logger.LogInformation("UpdateStaticContent Completed");
            return Ok(response);
        }

        [HttpDelete("{ID}", Name = "DeleteStaticContent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var deleteStaticContentCommand = new DeleteStaticContentCommand() { ID = ID };
            _logger.LogInformation("DeleteStaticContent Initiated");
            var del =  await _mediator.Send(deleteStaticContentCommand);
            _logger.LogInformation("DeleteStaticContent Completed");
            return Ok(del);
        }

        [HttpGet("{ID}", Name = "GetStaticContentByID")]
        public async Task<ActionResult> GetStaticContentByID(Guid ID)
        {
            _logger.LogInformation("GetStaticContentById Initiated");
            var getStaticContentDetailQuery = new GetStaticContentDetailQuery() { ID = ID };
            _logger.LogInformation("GetStaticContentById Initiated");
            return Ok(await _mediator.Send(getStaticContentDetailQuery));
        }

        [HttpPost("UploadStaticContentFile", Name = "UploadStaticContentFile"), DisableRequestSizeLimit]
        public IActionResult UploadStaticContentFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                var directoryName = Directory.GetCurrentDirectory();
                var folderName = "WazenUploads";
                var pathToSave = Path.Combine(directoryName, folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { fullPath, fileName });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }        
    }
}
