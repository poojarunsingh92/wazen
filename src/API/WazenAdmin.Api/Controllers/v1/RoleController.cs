using System.Threading.Tasks;
using WazenAdmin.Application.Features.Roles.Commands.CreateRole;
using WazenAdmin.Application.Features.Roles.Commands.DeleteRole;
using WazenAdmin.Application.Features.Roles.Commands.UpdateRole;
using WazenAdmin.Application.Features.Roles.Queries.GetRoleDetail;
using WazenAdmin.Application.Features.Roles.Queries.GetRolesList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public RoleController(IMediator mediator, ILogger<RoleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

      [HttpGet("all", Name = "GetAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllRoles(string token)
        {
            _logger.LogInformation("GetAllRoles Initiated");
            var dtos = await _mediator.Send(new GetRolesListQuery() { token = token });
            _logger.LogInformation("GetAllRoles Completed");
            return Ok(dtos);
        }

        [HttpPut(Name = "UpdateRole")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateRoleCommand updateEventCommand)
        {
            _logger.LogInformation("UpdateEvent Initiated");

            var response = await _mediator.Send(updateEventCommand);
            _logger.LogInformation("UpdateEvent Completed");
            return Ok(response);


        }


        [HttpPost(Name = "AddRole")]
        public async Task<ActionResult> Create([FromBody] CreateRoleCommand createRoleCommand)
        {
            var response = await _mediator.Send(createRoleCommand);
            return Ok(response);
        }


        [HttpGet("GetRoleByID")]
        public async Task<ActionResult> GetRoleByID(string ID, string token)
        {
            var getRoleByID= new GetRoleDetailQuery() { Token = token, ID = ID };
            var response = await _mediator.Send(getRoleByID);
            return Ok(response);
        }

        [HttpDelete("{ID}", Name = "DeleteRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string ID,string token)
        {
            _logger.LogInformation("deleteAllRoles Initiated");

            var deleteRoleCommand = new DeleteRoleCommand() { ID = ID,token=token };
            var del = await _mediator.Send(deleteRoleCommand);
            _logger.LogInformation("deleteAllRoles Completed");

            return Ok(del);
        }

        

    }
}
