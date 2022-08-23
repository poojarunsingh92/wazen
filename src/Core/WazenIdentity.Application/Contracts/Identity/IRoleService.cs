using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenIdentity.Application.Models.RolesUser;
using WazenIdentity.Application.Responses;

namespace WazenIdentity.Application.Contracts.Identity
{
  public interface IRoleService
    {
        Task<Response<RolesResponse>> RoleAddAsync(RolesRequest request);
        Task<Response<UpdateRolesResponse>> RoleUpdateAsync(UpdateRolesRequest request);

        Task<DeleteResponse> RoleDeleteAsync(string request);
        Task<Response<GetAllRoles>> GetAllRolesAsync();
        Task<Response<RoleByID>> GetRoleByID(string id);
    }
}
