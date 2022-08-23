using WazenAdmin.Application.Features.HomePageBanners.Commands.DeleteHomePageBanner;
using WazenAdmin.Application.Features.HomePageBanners.Commands.UpdateHomePageBanner;
using WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannerDetail;
using WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannersList;
using WazenAdmin.Features.HomePageBanners.Commands.CreateHomePageBanner;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WazenAdmin.Api.Controllers.v1
{
    //[Authorize(Roles = "System Admin")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HomePageBannerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomePageBannerController(IMediator mediator, ILogger<HomePageBannerController> logger, IWebHostEnvironment hostEnvironment)
        {
            _mediator = mediator;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllHomePageBanners")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllHomePageBanners()
        {
            _logger.LogInformation("GetAllHomePageBanners Initiated");
            var dtos = await _mediator.Send(new GetHomePageBannersListQuery());
            _logger.LogInformation("GetAllHomePageBanners Completed");
            return Ok(dtos);
        }

        [HttpPost(Name = "AddHomePageBanner")]
        public async Task<ActionResult> Create([FromBody] CreateHomePageBannerCommand createHomePageBannerCommand)
        {
            _logger.LogInformation("AddHomePageBanner Initiated");
            var response = await _mediator.Send(createHomePageBannerCommand);
            _logger.LogInformation("AddHomePageBanner Completed");
            return Ok(response);
        }

        [HttpPut(Name = "UpdateHomePageBanner")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateHomePageBannerCommand updateHomePageBannerCommand)
        {
            _logger.LogInformation("UpdateHomePageBanner Initiated");
            var response = await _mediator.Send(updateHomePageBannerCommand);
            _logger.LogInformation("UpdateHomePageBanner Completed");
            return Ok(response);
        }

        [HttpDelete("{ID}", Name = "DeleteHomePageBanner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var deleteHomePageBannerCommand = new DeleteHomePageBannerCommand() { ID = ID };
            _logger.LogInformation("DeleteHomePageBanner Initiated");
            var del = await _mediator.Send(deleteHomePageBannerCommand);
            _logger.LogInformation("DeleteHomePageBanner Completed");
            return Ok(del);
        }

        [HttpGet("{ID}", Name = "GetHomePageBannerById")]
        public async Task<ActionResult> GetHomePageBannerById(Guid ID)
        {
            _logger.LogInformation("GetHomePageBannerById Initiated");
            var getHomePageBannerDetailQuery = new GetHomePageBannerDetailQuery() { ID = ID };
            _logger.LogInformation("GetHomePageBannerById Initiated");
            return Ok(await _mediator.Send(getHomePageBannerDetailQuery));
        }


        [HttpPost("UploadHomePageBannerFile", Name = "UploadHomePageBannerFile"), DisableRequestSizeLimit]
        public IActionResult UploadHomePageBannerFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                var directoryName = Directory.GetCurrentDirectory();
                var folderName = "WazenUploads";
                var pathToSave = Path.Combine(directoryName, folderName);

                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);

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
