using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Domain.Entities;
using WazenAdmin.Application.Exceptions;
using System.Net;
using RestSharp;
using System.Text.Json;

namespace WazenAdmin.Application.Features.Roles.Queries.GetRoleDetail
{
    public  class GetRoleDetailQueryHandler : IRequestHandler<GetRoleDetailQuery , Response<RoleDetailVm>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        
        public GetRoleDetailQueryHandler(IMapper mapper, IRoleRepository roleRepository, ILogger<GetRoleDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;           
        }
        public async Task<Response<RoleDetailVm>> Handle(GetRoleDetailQuery request, CancellationToken cancellationToken)
        {
            
            var response = new Response<RoleDetailVm>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

             //Azure
            RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Role/GetRoleByID?ID=" + request.ID);

            //Server
            //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Role/GetRoleByID?ID="+request.ID);

            //Local
            //RestClient client = new RestClient("http://localhost:54810/api/v1/Role/GetRoleByID?ID="+request.ID);
            var requestIdentityRegister = new RestRequest(Method.GET);

            requestIdentityRegister.AddHeader("Content-Type", "application/json");
            string jwtToken = "Bearer " + request.Token;

            requestIdentityRegister.AddHeader("Authorization", jwtToken);

            IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);

            if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                response.Data = null;
                response.Message = "You are not authorized";
                response.Succeeded = false;

                return response;
            }
            else if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                response.Data = null;
                response.Message = "Forbidden";
                response.Succeeded = false;

                return response;
            }
            else if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getRegisterResponse.Content;
            }
            var actualResponse = JsonSerializer.Deserialize<RoleResponseFromRestClient>(newResponse);
            RoleDetailVm vmresp = new RoleDetailVm()
            {
                concurrencyStamp = actualResponse.data.concurrencyStamp,
                description = actualResponse.data.description,
                id = actualResponse.data.id.ToString(),
                isActive = actualResponse.data.isActive,
                name = actualResponse.data.name,
                normalisedName = actualResponse.data.normalisedName,
                readPermission = actualResponse.data.readPermission,
                status = actualResponse.data.status,
                viewPermission = actualResponse.data.viewPermission,
                writePermission = actualResponse.data.writePermission
            };
            response.Data = vmresp;
            response.Succeeded = actualResponse.succeeded;
            response.Message = actualResponse.message;
            response.Errors = actualResponse.errors;
            return response;
        }
    }
}
