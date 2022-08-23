using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenIdentity.Application.Contracts.Identity;
using WazenIdentity.Application.Models.RolesUser;
using WazenIdentity.Application.Responses;

namespace WazenIdentity.Api.Controllers.v1
{
    [Authorize(Roles = "SYSTEM_ADMIN")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [HttpPost("AddRole")]
        public async Task<ActionResult<RolesResponse>> AddsAsync(RolesRequest request)
        {
            return Ok(await _roleService.RoleAddAsync(request));
        }

        [HttpPut("UpdateRole")]
        public async Task<ActionResult<UpdateRolesResponse>> UpdateRole(UpdateRolesRequest request)
        {
            return Ok(await _roleService.RoleUpdateAsync(request));
        }
        [HttpDelete("DeleteRole")]
        public async Task<ActionResult<DeleteResponse>> DeleteRole(string request)
        {
            return Ok(await _roleService.RoleDeleteAsync(request));
        }
        [HttpGet("GetAllRolesData")]
        public async Task<ActionResult> RolesGetAll()
        {
            return Ok(await _roleService.GetAllRolesAsync());
        }
        [HttpGet("GetRoleByID")]
        public async Task<ActionResult> GetRoleByID(string ID)
        {
            return Ok(await _roleService.GetRoleByID(ID));
        }
    }


}
