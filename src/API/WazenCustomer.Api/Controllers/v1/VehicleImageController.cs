using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.VehicleImages.Commands.CreateVehicleImage;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VehicleImageController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public VehicleImageController(IMediator mediator, ILogger<VehicleImageController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost(Name = "AddVehicleImage")]
        public async Task<ActionResult> Create([FromBody] CreateVehicleImageCommand createVehicleImageCommand)
        {
            _logger.LogInformation("AddVehicleImage Initiated");
            var response = await _mediator.Send(createVehicleImageCommand);
            _logger.LogInformation("AddVehicleImage Completed");
            return Ok(response);
        }

        [HttpPost("UploadVehicleImage", Name = "uploadVehicleImage"), DisableRequestSizeLimit]
        public IActionResult Upload()
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