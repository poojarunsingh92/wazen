using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WazenIdentity.Application.Contracts.Identity;
using WazenIdentity.Application.Models.Authentication;
using WazenIdentity.Application.Models.RolesUser;
using WazenIdentity.Application.Responses;
using WazenIdentity.Identity.Models;

namespace WazenIdentity.Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
     
        private readonly IMapper _mapper;



        public RoleService(IMapper mapper, RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
            
            _mapper = mapper;

        }

        
        public async Task<Response<RolesResponse>> RoleAddAsync(RolesRequest request)
        {
           
            Response<RolesResponse> rolesResponse = new Response<RolesResponse>();

            var existingUser = await _roleManager.FindByNameAsync(request.Name);

            if (existingUser != null)
            {
                rolesResponse.Data = null;
                rolesResponse.Message = "Role Already Exists";
                rolesResponse.Succeeded = true;
                return rolesResponse;
            }
            var role = new ApplicationRole()
            {
                Name = request.Name,
                NormalizedName = request.Name.ToUpper(),
                //ConcurrencyStamp = request.ConcurrencyStamp,
                Status = request.Status,
                Description = request.Description,
                ViewPermission = request.ViewPermission,
                WritePermission = request.WritePermission,
                ReadPermission = request.ReadPermission,
                isActive = request.isActive
            };

            var CreateResult = await _roleManager.CreateAsync(role);
           
            if (CreateResult.Succeeded)
            {
                rolesResponse.Succeeded = true;
                rolesResponse.Message = "Role Added Successfully";
                rolesResponse.Data = new RolesResponse()
                {
                    Name = request.Name,
                    NormalizedName = request.Name.ToUpper(),
                    //ConcurrencyStamp = request.ConcurrencyStamp,
                    Status = request.Status,
                    Description = request.Description,
                    ViewPermission = request.ViewPermission,
                    WritePermission = request.WritePermission,
                    ReadPermission = request.ReadPermission,
                    isActive = request.isActive
                };
            }
            else
            {
                rolesResponse.Succeeded = false;
                rolesResponse.Message = "Role Not Added Successfully";

            }
            return rolesResponse;
        }

        public async Task<Response<UpdateRolesResponse>> RoleUpdateAsync(UpdateRolesRequest request)
        {

            Response<UpdateRolesResponse> rolesResponse = new Response<UpdateRolesResponse>();

            var existingUser = await _roleManager.FindByIdAsync(request.Id.ToString());

            if (existingUser != null)
            {
                existingUser.Id = existingUser.Id;
                existingUser.Name = request.Name;
                existingUser.NormalizedName = request.Name.ToUpper();
                //existingUser.ConcurrencyStamp = request.ConcurrencyStamp;
                existingUser.Status = request.Status;
                existingUser.Description = request.Description;
                existingUser.ViewPermission = request.ViewPermission;
                existingUser.WritePermission = request.WritePermission;
                existingUser.ReadPermission = request.ReadPermission;
                existingUser.isActive = request.isActive;
                var updateRole =await _roleManager.UpdateAsync(existingUser);

                if (updateRole.Succeeded)
                {
                    rolesResponse.Data = new UpdateRolesResponse()
                    {
                        Name = existingUser.Name,
                        NormalizedName = existingUser.Name.ToUpper(),
                        ConcurrencyStamp = existingUser.ConcurrencyStamp,
                        Status = existingUser.Status,
                        Description = existingUser.Description,
                        ViewPermission = existingUser.ViewPermission,
                        WritePermission = existingUser.WritePermission,
                        ReadPermission = existingUser.ReadPermission,
                        isActive = existingUser.isActive
                    };
                    rolesResponse.Message = "Role Updated Successfully";
                    rolesResponse.Succeeded = true;
                    return rolesResponse;
                }
                else
                {

                    rolesResponse.Message = "Role Not Updated Successfully";
                    rolesResponse.Succeeded = true;
                    return rolesResponse;
                }
            }
            else
            {
                var role = new ApplicationRole()
                {
                    Name = request.Name,
                    NormalizedName = request.Name.ToUpper(),
                    //ConcurrencyStamp = request.ConcurrencyStamp,
                    Status = request.Status,
                    Description = request.Description,
                    ViewPermission = request.ViewPermission,
                    WritePermission = request.WritePermission,
                    ReadPermission = request.ReadPermission,
                    isActive = request.isActive
                };

                var CreateResult = await _roleManager.CreateAsync(role);

                if (CreateResult.Succeeded)
                {
                    rolesResponse.Succeeded = true;
                    rolesResponse.Message = "Role Added Successfully";
                    rolesResponse.Data = new UpdateRolesResponse()
                    {
                        Name = request.Name,
                        NormalizedName = request.Name.ToUpper(),
                        //ConcurrencyStamp = request.ConcurrencyStamp,
                        Status = request.Status,
                        Description = request.Description,
                        ViewPermission = request.ViewPermission,
                        WritePermission = request.WritePermission,
                        ReadPermission = request.ReadPermission,
                        isActive = request.isActive
                    };
                }
                else
                {
                    rolesResponse.Succeeded = false;
                    rolesResponse.Message = "Role Not Added Successfully";

                }
                return rolesResponse;
            }
        }

        public async Task<DeleteResponse> RoleDeleteAsync(string request)
        {
            var deleteResponse = new DeleteResponse("Deleting Role",true);

            var existingUser = await _roleManager.FindByIdAsync(request);
            if (existingUser != null)
            {
               var result= await _roleManager.DeleteAsync(existingUser);
                if (result.Succeeded)
                {
                    deleteResponse.Message = "Role Deleted Successfully";
                    deleteResponse.Succeeded = true;
                }
                else{
                    deleteResponse.Message = "Role Not Deleted Successfully";
                    deleteResponse.Succeeded = true;
                }
            }
            else
            {
                deleteResponse.Message = "No Role Found";
                deleteResponse.Succeeded = true;
            }
            return deleteResponse;
        }
    
    public async Task<Response<GetAllRoles>> GetAllRolesAsync() {

            var response = new Response<GetAllRoles>();
            var rolesresponse =  _roleManager.Roles.ToList();
            List<WazenIdentity.Application.Models.RolesUser.Role> data = new List<WazenIdentity.Application.Models.RolesUser.Role>();

            foreach (var role in rolesresponse)
            {
                data.Add(new WazenIdentity.Application.Models.RolesUser.Role()
                {
                    Id = role.Id,
                    Name = role.Name,
                    ConcurrencyStamp = role.ConcurrencyStamp,
                    Description = role.Description,
                    isActive = role.isActive,
                    NormalizedName = role.NormalizedName,
                    ReadPermission = role.ReadPermission,
                    Status = role.Status,
                    ViewPermission = role.ViewPermission,
                    WritePermission = role.WritePermission

                });
            }
            response.Data = new GetAllRoles();
            response.Data.Roles = data;
            response.Succeeded = true;
            return response;
        }

        public async Task<Response<RoleByID>> GetRoleByID(string id)
        {
            Response<RoleByID> response = new Response<RoleByID>();
            var roleData = await _roleManager.FindByIdAsync(id);

            if (roleData == null)
            {

                response.Message = "No Role Found";
                response.Succeeded = true;
                
            }
            else
            {
                response.Message = "Role Found ";
                response.Succeeded = true;
                response.Data = new RoleByID()
                {
                    concurrencyStamp=roleData.ConcurrencyStamp,
                    description=roleData.Description,
                    id=roleData.Id.ToString(),
                    isActive= roleData.isActive,
                    name=roleData.Name,
                    normalisedName= roleData.NormalizedName,
                    readPermission= roleData.ReadPermission,
                    status= roleData.Status,
                    viewPermission=roleData.ViewPermission,
                    writePermission= roleData.WritePermission
                };
            }
            return response;
        }
    }
}
   
    

