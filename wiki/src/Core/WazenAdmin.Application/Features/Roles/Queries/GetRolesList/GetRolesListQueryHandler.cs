using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using RestSharp;
using System.Text.Json;

namespace WazenAdmin.Application.Features.Roles.Queries.GetRolesList
{
    public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, Response<IEnumerable<RoleListVM>>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetRolesListQueryHandler(IMapper mapper, IRoleRepository roleRepository, ILogger<GetRolesListQueryHandler> logger)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<RoleListVM>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var getRoleCommandResponse = new Response<IEnumerable<RoleListVM>>();

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

            //Azure
            RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Role/GetAllRolesData");


            //Server
            //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Role/GetAllRolesData");

            //Local
            //RestClient client = new RestClient("http://localhost:59410/api/v1/Role/GetAllRolesData");
            var requestIdentityRegister = new RestRequest(Method.GET);

            requestIdentityRegister.AddHeader("Content-Type", "application/json");
            string jwtToken = "Bearer " + request.token;

            requestIdentityRegister.AddHeader("Authorization", jwtToken);

            IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);

            if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                getRoleCommandResponse.Data = null;
                getRoleCommandResponse.Message = "You are not authorized";
                getRoleCommandResponse.Succeeded = false;

                return getRoleCommandResponse;
            }
            else if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                getRoleCommandResponse.Data = null;
                getRoleCommandResponse.Message = "Forbidden";
                getRoleCommandResponse.Succeeded = false;

                return getRoleCommandResponse;
            }
            else if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getRegisterResponse.Content;
            }
            var actualResponse = JsonSerializer.Deserialize<GetAllRoles>(newResponse);
            List<RoleListVM> roleVM = new List<RoleListVM>();
            foreach (var role in actualResponse.data.roles)
            {
                roleVM.Add(new RoleListVM()
                {
                    Id = role.id,
                    ConcurrencyStamp = role.concurrencyStamp,
                    Description = role.description,
                    isActive = role.isActive,
                    Name = role.name,
                    NormalizedName = role.normalizedName,
                    ReadPermission = role.readPermission,
                    Status = role.status,
                    ViewPermission = role.viewPermission,
                    WritePermission = role.writePermission
                });
            }
            getRoleCommandResponse.Succeeded = actualResponse.succeeded;
            getRoleCommandResponse.Message = actualResponse.message;
            getRoleCommandResponse.Errors = actualResponse.errors;
            getRoleCommandResponse.Data = roleVM;
            return getRoleCommandResponse;


        }
    }
}
