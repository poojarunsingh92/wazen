using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.Authentication.Commands.RegisterAccount;
using WazenAdmin.Application.Models.Authentication;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost("admin-register")]
        public async Task<ActionResult<AdminResponse>> AdminRegisterAsync(RegisterAccountCommand request)
        {
            _logger.LogInformation("Authentication Initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("GetAllAboutUs Completed");
            return Ok(dtos);
        }
    }
}
