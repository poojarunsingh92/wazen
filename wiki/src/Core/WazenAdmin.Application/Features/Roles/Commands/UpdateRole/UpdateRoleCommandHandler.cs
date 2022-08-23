using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using RestSharp;
using System.Text.Json;

namespace WazenAdmin.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Response<UpdateRolesResponse>>
    {
       
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
          
        }

        //public async Task<Response<Guid>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        //{
        //    //rest client 

        //    var createRoleCommandResponse = new Response<UpdateRolesResponse>();
        //    //var roleToUpdate = await _roleRepsitory.GetByIdAsync(request.ID);

        //    //if (roleToUpdate == null)
        //    //{
        //    //    var resposeObject = new Response<Guid>(request.ID + " is not available");
        //    //    return resposeObject;
        //    //}

        //    //var validator = new UpdateRoleCommandValidator();
        //    //var validationResult = await validator.ValidateAsync(request);

        //    //if (validationResult.Errors.Count > 0)
        //    //    throw new ValidationException(validationResult);

        //    //_mapper.Map(request, roleToUpdate, typeof(UpdateRoleCommand), typeof(Role));

        //    //await _roleRepsitory.UpdateAsync(roleToUpdate);

        //    //return new Response<Guid>(request.ID, "Updated successfully ");
        //}

        public async Task<Response<UpdateRolesResponse>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {

            //rest client 

            var updateRoleCommandResponse = new Response<UpdateRolesResponse>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

            //Azure 
            RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Role/UpdateRole");

            //Server
            //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Role/UpdateRole");

            //Local
            //RestClient client = new RestClient("http://localhost:59410/api/v1/Role/UpdateRole");

            var requestIdentityRegister = new RestRequest(Method.PUT);
            requestIdentityRegister.AddHeader("Content-Type", "application/json");
            string jwtToken = "Bearer " + request.Token;
            requestIdentityRegister.AddHeader("Authorization", jwtToken);
            var roleRequest = new RoleRequest()
            {
                Id=request.Id,
                Name = request.Name,
                //ConcurrencyStamp = request.ConcurrencyStamp,
                Status = request.Status,
                Description = request.Description,
                ViewPermission = request.ViewPermission,
                WritePermission = request.WritePermission,
                ReadPermission = request.ReadPermission,
                isActive = request.isActive

            };


            var body = JsonSerializer.Serialize(roleRequest);
            requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
            if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getRegisterResponse.Content;
            }
            var actualResponse = JsonSerializer.Deserialize<RoleResponse>(newResponse);

            updateRoleCommandResponse.Data = new UpdateRolesResponse()
            {
                name = actualResponse.data.name,
                normalizedName = actualResponse.data.name.ToUpper(),
                //concurrencyStamp = actualResponse.data.concurrencyStamp,
                status = actualResponse.data.status,
                description = actualResponse.data.description,
                viewPermission = actualResponse.data.viewPermission,
                writePermission = actualResponse.data.writePermission,
                readPermission = actualResponse.data.readPermission,
                isActive = actualResponse.data.isActive
            };

            updateRoleCommandResponse.Succeeded = actualResponse.succeeded;
            updateRoleCommandResponse.Message = actualResponse.message;
            updateRoleCommandResponse.Errors = actualResponse.errors;



            return updateRoleCommandResponse;
        }
    }
}
