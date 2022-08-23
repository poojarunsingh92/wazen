using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using RestSharp;
using System.Text.Json;

namespace WazenAdmin.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Response<RolesResponse>>
    {
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Response<RolesResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            //rest client 

            var createRoleCommandResponse = new Response<RolesResponse>();

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

            //Azure 
            RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Role/AddRole");

            //Server
            //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Role/AddRole");

            //Local
            //RestClient client = new RestClient("http://localhost:59410/api/v1/Role/AddRole");
            var requestIdentityRegister = new RestRequest(Method.POST);

            requestIdentityRegister.AddHeader("Content-Type", "application/json");
            var roleRequest = new RestClientRolesRequest()
            {
                Name = request.Name,
                //ConcurrencyStamp = request.ConcurrencyStamp,
                Status = request.Status,
                Description = request.Description,
                ViewPermission = request.ViewPermission,
                WritePermission = request.WritePermission,
                ReadPermission = request.ReadPermission,
                isActive = request.isActive

            };
            string jwtToken ="Bearer "+ request.token;
            requestIdentityRegister.AddHeader("Authorization",jwtToken);
            var body = JsonSerializer.Serialize(roleRequest);
            requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
          
            if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                createRoleCommandResponse.Data = null;
                createRoleCommandResponse.Message = "You are not authorized";
                createRoleCommandResponse.Succeeded = false;
                return createRoleCommandResponse;
            }else if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                createRoleCommandResponse.Data = null;
                createRoleCommandResponse.Message = "Forbidden";
                createRoleCommandResponse.Succeeded = false;
                return createRoleCommandResponse;
            }
            else if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getRegisterResponse.Content;
            }
            var actualResponse = JsonSerializer.Deserialize<RestClientRolesResponse>(newResponse);

            createRoleCommandResponse.Data = new RolesResponse() {
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
            createRoleCommandResponse.Succeeded = actualResponse.succeeded;
            createRoleCommandResponse.Message = actualResponse.message;
            createRoleCommandResponse.Errors = actualResponse.errors;
            


            return createRoleCommandResponse;
        }
    }
}
