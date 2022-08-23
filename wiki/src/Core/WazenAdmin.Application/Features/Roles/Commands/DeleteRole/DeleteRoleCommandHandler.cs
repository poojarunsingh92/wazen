using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Responses;
using System.Net;
using RestSharp;
using System.Text.Json;

namespace WazenAdmin.Application.Features.Roles.Commands.DeleteRole
{
     public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Response<DeleteResponse>>
    {
        private readonly IRoleRepository _roleRepsitory;
        //private readonly IUserRepository _userRepository;

        public DeleteRoleCommandHandler(IRoleRepository roleRepsitory/*, IUserRepository userRepository*/)
        {
            _roleRepsitory = roleRepsitory;
            //_userRepository = userRepository;
        }        

        public async Task<Response<DeleteResponse>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var deleteRoleCommandResponse = new Response<DeleteResponse>();

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

            //Azure
            RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Role/DeleteRole?request=" + request.ID);

            //Server
            //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Role/DeleteRole?request="+ request.ID);

            //Local
            //RestClient client = new RestClient("http://localhost:54810/api/v1/Role/DeleteRole?request=" + request.ID);
            var requestIdentityRegister = new RestRequest(Method.DELETE);

            requestIdentityRegister.AddHeader("Content-Type", "application/json");  
            string jwtToken = "Bearer " + request.token;
            requestIdentityRegister.AddHeader("Authorization", jwtToken); 
          
            IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);

            if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                deleteRoleCommandResponse.Data = null;
                deleteRoleCommandResponse.Message = "You are not authorized";
                deleteRoleCommandResponse.Succeeded = false;
                return deleteRoleCommandResponse;
            }
            else if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                deleteRoleCommandResponse.Data = null;
                deleteRoleCommandResponse.Message = "Forbidden";
                deleteRoleCommandResponse.Succeeded = false;
                return deleteRoleCommandResponse;
            }
            else if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getRegisterResponse.Content;
            }
            var actualResponse = JsonSerializer.Deserialize<DeleteResponse>(newResponse);

            deleteRoleCommandResponse.Data = null;
            deleteRoleCommandResponse.Message = actualResponse.message;
            deleteRoleCommandResponse.Succeeded = actualResponse.succeeded;
            return deleteRoleCommandResponse;
            //var roleToDelete = await _roleRepsitory.GetByIdAsync(request.ID);

            //if (roleToDelete == null)
            //{
            //    throw new NotFoundException(nameof(Role), request.ID);
            //}

            /*var user = await _userRepository.GetByRoleTypeAsync(request.Id);           
            
            if (user != null)
            {
                return new Response<bool>("This role is assigned to user") ;
            }
            else
            {
                await _roleRepsitory.DeleteAsync(roleToDelete);
                return new Response<bool>(true,"Record deleted");
            }   */

            //await _roleRepsitory.DeleteAsync(roleToDelete);
            //return new Response<bool>(true, "Record deleted");
        }
    }
}
