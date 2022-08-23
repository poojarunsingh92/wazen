using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.Users.Commands.CreateUser;
using WazenAdmin.Application.Features.Users.Commands.DeleteUser;
using WazenAdmin.Application.Features.Users.Commands.UpdateUser;
using WazenAdmin.Application.Features.Users.Queries.GetUserByUserId;
using WazenAdmin.Application.Features.Users.Queries.GetUserDetail;
using WazenAdmin.Application.Features.Users.Queries.GetUsersList;
using WazenAdmin.Application.Features.Users.Queries.SendOTP;
using WazenAdmin.Application.Features.Users.Queries.VerifyOTP;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /*[HttpGet("ForgotPassword/{email}", Name = "ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            var getUserEmailQuery = new GetUserEmailQuery() { Email = email };
            return Ok(await _mediator.Send(getUserEmailQuery));
        }*/



        //[Authorize]
        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllUsers()
        {
            _logger.LogInformation("GetAllUsers Initiated");
            var dtos = await _mediator.Send(new GetUsersListQuery());
            _logger.LogInformation("GetAllUsers Completed");
            return Ok(dtos);
        }

        [HttpGet("{ID}", Name = "GetUserByID")]
        public async Task<ActionResult> GetUserById(Guid ID)
        {
            var getUserDetailQuery = new GetUserDetailQuery() { ID = ID };
            return Ok(await _mediator.Send(getUserDetailQuery));
        }

        [HttpPut(Name = "UpdateUser")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand updateEventCommand)
        {
            _logger.LogInformation("UpdateEvent Initiated");

            var response = await _mediator.Send(updateEventCommand);
            _logger.LogInformation("UpdateEvent Completed");
            return Ok(response);


        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }

        [HttpDelete("{ID}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            _logger.LogInformation("deleteAllUsers Initiated");

            var deleteUserCommand = new DeleteUserCommand() { ID = ID };
            await _mediator.Send(deleteUserCommand);
            _logger.LogInformation("deleteAllUsers Completed");

            return NoContent();
        }
        [HttpGet("GetUserByUserId", Name = "GetUserByUserId")]
        public async Task<ActionResult> GetUserByUserId(Guid UserId)
        {
            var getUserByUserId = new GetUserByUserIdQuery()
            {
                UserId = UserId
            };
            return Ok(await _mediator.Send(getUserByUserId));
        }

        [HttpGet("SendOTP", Name = "SendOTP")]
        public async Task<ActionResult> SendOTP(string Email)
        {
            var sendOTPQuery = new SendOTPQuery() 
            { Email = Email };
            return Ok(await _mediator.Send(sendOTPQuery));
        }


        [HttpGet("VerifyOTP", Name = "VerifyOTP")]
        public async Task<ActionResult> VerifyOTP(string Email, string VerifyCode)
        {
            var verifyOTPQuery = new VerifyOTPQuery()
            { Email = Email, VerifyCode=VerifyCode};
            return Ok(await _mediator.Send(verifyOTPQuery));
        }


        /*[HttpGet("SignIn", Name = "UserLogin")]
        public async Task<ActionResult> UserLogin(string useName, string Password)
        {
            var getUserEmailQuery = new GetUserLoginDetailsQuery() { userName = useName, Password = Password };
            return Ok(await _mediator.Send(getUserEmailQuery));
        }*/


        /*[HttpPut("UpdateUserPassword", Name = "updateUserPassword")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UserPassword([FromBody] UpdateUserPasswordCommand UserCommand)
        {
            _logger.LogInformation("UpdateEvent Initiated");

            var response = await _mediator.Send(UserCommand);
            _logger.LogInformation("UpdateEvent completed");

            return Ok(response);
        }*/
    }
}
