using AutoMapper;
using MediatR;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Models.Authentication;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Authentication.Commands.RegisterAccount
{

    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, ServiceBaseResponse2<AdminResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterAccountCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ServiceBaseResponse2<AdminResponse>> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var adminResponse = new ServiceBaseResponse2<AdminResponse>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";
            //Azure 
            RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Account/register");

            //Server
            //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Account/register");

            //Local
            //RestClient client = new RestClient("http://localhost:54810/api/v1/Account/register");

            var requestIdentityRegister = new RestRequest(Method.POST);

            requestIdentityRegister.AddHeader("Content-Type", "application/json");

            var adminRequest = new AdminServiceRequest()
            {

                userName = request.Username,

                email = request.Email,
                firstName = request.FirstName,
                lastName = request.LastName,
                password = request.Password,
                roleName = request.RoleName
            };
            var body = JsonSerializer.Serialize(adminRequest);
            requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
            if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getRegisterResponse.Content;
            }
            var adminServiceResponse = JsonSerializer.Deserialize<AdminServiceResponse>(newResponse);
            if (adminServiceResponse.userId != null)
            {
                User userreq = new User();
                
                userreq.IsActive = request.IsActive;
                userreq.Name = request.FirstName + ' ' + request.LastName;
                userreq.Username = request.Username;
                userreq.Userid = Guid.Parse(adminServiceResponse.userId);
                //userreq.RoleType = Guid.Parse(adminServiceResponse.roleId);
                userreq.Password = request.Password;
                userreq.Date = new DateTime();
                userreq.Designation = request.Designation;
                userreq.Email = request.Email;
                userreq.ContactNo = request.ContactNo;
                var response = await _userRepository.AddAsync(userreq);


                adminResponse.succeeded = true;
                adminResponse.data = _mapper.Map<AdminResponse>(response);
                adminResponse.message = "Admin Created Successfully";
                return adminResponse;

            }

            adminResponse.succeeded = false;
            adminResponse.message = "Admin Not Created";

            return adminResponse;
        }
    }
}
