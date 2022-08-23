using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WazenIdentity.Application.Contracts.Identity;
using WazenIdentity.Application.Models.Authentication;

namespace WazenIdentity.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet("UpdatedOn18thAugust22_04_00PM", Name = "UpdatedOn18thAugust22_04_00PM")]
        public async Task<ActionResult> UpdatedOn18thAugust22_04_00PM()
        {
            return Ok();
        }

        [HttpPost("admin-authenticate")]
        public async Task<ActionResult<AuthenticationAdminResponse>> AdminAuthenticateAsync(AdminAuthenticationRequest request)
        {
            return Ok(await _authenticationService.AdminAuthenticateAsync(request));
        }


        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            return Ok(await _authenticationService.RefreshTokenAsync(request));
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync(RevokeTokenRequest request)
        {
            var response = await _authenticationService.RevokeToken(request);
            if (response.Message == "Token is required")
                return BadRequest(response);
            else if (response.Message == "Token did not match any users")
                return NotFound(response);
            else
                return Ok(response);
        }
        
        //Reset Password when Forgot Password
        [HttpPut("UpdateResetPassword")]
        public async Task<ActionResult> UpdateChangePassword(UpdateResetPasswordRequest changePasswordDto)
        {
            return Ok(await _authenticationService.ChangePassword(changePasswordDto));
        }

        //UpdatePassword
        [HttpPut("UpdatePassword", Name = "UpdatePassword")]
        public async Task<ActionResult> UpdatePassword(UpdatePasswordRequest updatePasswordRequest)
        {
            return Ok(await _authenticationService.UpdatePassword(updatePasswordRequest)); ;
        }

        //UpdateEmail
        [HttpPut("UpdateEmail", Name = "UpdateEmail")]
        public async Task<ActionResult> UpdateEmail(UpdateEmailRequest updateEmailRequest)
        {
            return Ok(await _authenticationService.UpdateProfile(updateEmailRequest)); ;
        }
    }
}
