using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Infrastructure;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Customers.Queries.GetCustomerByNINAndDOB
{
    public class GetCustomerByNINAndDOBQueryHandler : IRequestHandler<GetCustomerByNINAndDOBQuery, Response<GetCustomerByNINAndDOBVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueueService _queueService;

        public GetCustomerByNINAndDOBQueryHandler(IMapper mapper, ILogger<GetCustomerByNINAndDOBQueryHandler> logger, ICustomerRepository customerRepository, IQueueService queueService)
        {
            _mapper = mapper;
            _logger = logger;
            _customerRepository = customerRepository;
            _queueService = queueService;
        }
        public async Task<Response<GetCustomerByNINAndDOBVm>> Handle(GetCustomerByNINAndDOBQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<GetCustomerByNINAndDOBVm>();
            _logger.LogInformation("Handle Initiated");

            var isCustomerExist = await _customerRepository.GetCustomerByNINAndDOB(request.NIN, request.DateOfBirth);
            if(isCustomerExist == null)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                string newResponse1 = "";

                //AzureServer
                RestClient client1 = new RestClient("http://thirdparty.wazen.ml/api/v1/Citizen/getCitizenInfo");

                //Local
                //RestClient client1 = new RestClient("http://localhost:44337/api/v1/Citizen/getCitizenInfo");

                //Server
                //RestClient client1 = new RestClient("http://180.149.247.134:8097/api/v1/Citizen/getCitizenInfo");
                var requestYakeenGetCitizenInfo = new RestRequest(Method.GET);
                requestYakeenGetCitizenInfo.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
                requestYakeenGetCitizenInfo.AddHeader("Content-Type", "application/json");
                IRestResponse getCitizenInfoResponse = client1.Execute(requestYakeenGetCitizenInfo);
                if (getCitizenInfoResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse1 = getCitizenInfoResponse.Content;
                }
                var actualResponse = JsonSerializer.Deserialize<GetCitizenByInfoVm>(newResponse1);

                //Start of Registration
                //Here we need to call Registration of Customer API 

                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                string newResponse = "";


                //Azure Server
                RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Account/register");

                //Server
                //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Account/register");

                //Local
                //RestClient client = new RestClient("http://localhost:54810/api/v1/Account/register");
                var requestIdentityRegister = new RestRequest(Method.POST);

                requestIdentityRegister.AddHeader("Content-Type", "application/json");

                //Random data generation logic starts here
                Random ran = new Random();

                String b = "abcdefghijklmnopqrstuvwxyz0123456789";

                int length = 3;

                String random = "";

                for (int i = 0; i < length; i++)
                {
                    int a = ran.Next(36);
                    random = random + b.ElementAt(a);
                }
                //Random data generation logic ends here

                var identityReq = new IdentityRegistrationRequest()
                {
                    Email = "ankur.deshpande" + random + "@gmail.com",
                    FirstName = actualResponse.englishFirstName,
                    LastName = actualResponse.englishLastName,
                    Password = actualResponse.englishFirstName.ToLower() + "A007@",
                    UserName = "ankur.deshpande" + random + "@gmail.com",
                    RoleName = "CUSTOMER"
                };
                var body = JsonSerializer.Serialize(identityReq);
                requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
                if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = getRegisterResponse.Content;
                }
                var customerIdentityResponse = JsonSerializer.Deserialize<IdentityRegistrationResponse>(newResponse);

                //End of Registration
                var customerData = _mapper.Map<Customer>(actualResponse);
                customerData.NIN = request.NIN;
                customerData.SalutationId = 1;
                customerData.DateOfBirth = request.DateOfBirth;
                //tempCustomerData.Email = "abdulrahman.alnujaim@gmail.com";
                customerData.Email = "ankur.deshpande" + random + "@gmail.com";
                customerData.Mobile = "9102817323";
                customerData.GenderId = 1;
                customerData.NationalIdTypeId = 1;
                customerData.EducationId = 1;
                customerData.OccupationId = 1;
                customerData.MaritalStatusId = 1;
                customerData.userId = Guid.Parse(customerIdentityResponse.userId);
                var customer = await _customerRepository.AddAsync(customerData);
                await _queueService.SendMessageAsync<Customer>(customer, "AdminCustomer");
                var customerDetailDto = _mapper.Map<GetCustomerByNINAndDOBVm>(customer);
                response = new Response<GetCustomerByNINAndDOBVm>(customerDetailDto, "success");
                _logger.LogInformation("Handle Completed");
            }
            else
            {
                var customerDetail = _mapper.Map<GetCustomerByNINAndDOBVm>(isCustomerExist);
                response = new Response<GetCustomerByNINAndDOBVm>(customerDetail, "success");
            }
            return response;
        }
    }
}