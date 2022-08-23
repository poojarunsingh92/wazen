using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Application.Features.Account.Queries.CustomerExist;
using RestSharp;
using System.Text.Json;
using System.Net;
using WazenCustomer.Application.Contracts.Infrastructure;

namespace WazenCustomer.Application.Features.Account.Commands.Register
{
    public class CreateRegistrationRequestCommandHandler : IRequestHandler<CreateRegistrationRequestCommand, Response<RegistrationResponse>>
    {
        private readonly IQueueService _queueService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRegistrationRequestCommandHandler> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMediator _mediator;

        public CreateRegistrationRequestCommandHandler(IQueueService queueService, IMapper mapper, ILogger<CreateRegistrationRequestCommandHandler> logger, ICustomerRepository customerRepository, ITempCustomerRepository tempCustomerRepository, IMediator mediator)
        {
            _queueService= queueService;
             _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _customerRepository = customerRepository;
            _tempCustomerRepository = tempCustomerRepository;
        }
        public async Task<Response<RegistrationResponse>> Handle(CreateRegistrationRequestCommand request, CancellationToken cancellationToken)
        {
            Response<RegistrationResponse> response = new Response<RegistrationResponse>();
            var customer = await _customerRepository.GetCustomerByNINAndMobile(request.NIN, request.Mobile);
            if(customer==null)
            {
                var tempCustomer = await _tempCustomerRepository.GetTempCustomerByNINAndMobile(request.NIN, request.Mobile);
                if(tempCustomer==null)
                {
                    var tempCustomerDetail = new TempCustomer()
                    {
                        ID = Guid.NewGuid(),
                        EnglishFirstName = request.FirstName,
                        EnglishLastName = request.LastName,
                        Mobile = request.Mobile,
                        DateOfBirth = DateTime.Parse("1990-01-10")/*new DateTime()*/,
                        SalutationId = request.SalutationId,
                        IsActive = true,
                        NewsLetterSubscription = false,
                        Email = request.Email,
                        NIN = request.NIN
                    };
                    //data insertion
                    await _tempCustomerRepository.AddAsync(tempCustomerDetail);
                    //rest client
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    string newResponse = "";

                    //Azure Server
                    RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Account/register");

                    //Server
                    //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Account/register");

                    //Local
                    //RestClient client = new RestClient("https://localhost:44330/api/v1/Account/register");
                    var requestIdentityRegister = new RestRequest(Method.POST);

                    requestIdentityRegister.AddHeader("Content-Type", "application/json");
                    var identityReq = new IdentityRegistrationRequest()
                    {
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Password = request.Password,
                        UserName = request.Email,
                        RoleName = request.RoleName
                    };
                    var body = JsonSerializer.Serialize(identityReq);
                    requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
                    IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
                    if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        newResponse = getRegisterResponse.Content;
                    }
                    var actualResponse = JsonSerializer.Deserialize<IdentityRegistrationResponse>(newResponse);

                    var customerDetail = new Customer()
                    {
                        ID = Guid.NewGuid(),
                        EnglishFirstName = request.FirstName,
                        EnglishLastName = request.LastName,
                        Mobile = request.Mobile,
                        DateOfBirth = DateTime.Parse("1990-01-10")/*new DateTime()*/,
                        SalutationId = request.SalutationId,
                        IsActive = true,
                        NewsLetterSubscription = false,
                        Email = request.Email,
                        NIN = request.NIN,
                        userId = actualResponse.userId,
                        NationalIdTypeId = request.NationalIdTypeId,
                        GenderId = 1,
                        OccupationId = 1,
                        MaritalStatusId=1,
                        EducationId=1
                    };
                    customerDetail = await _customerRepository.AddAsync(customerDetail);
                    await _queueService.SendMessageAsync<Customer>(customerDetail, "Customer");
                    response.Data = _mapper.Map<RegistrationResponse>(customerDetail);
                    response.Succeeded = true;
                    response.Message = "Registered Successfully";
                }
                else
                {
                    //Already Exist so will make it Register and then into Main
                    string newResponse = "";

                    //Azure Server
                    RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Account/register");

                    //Server
                    //RestClient client = new RestClient("http://180.149.247.134:8099/api/v1/Account/register");

                    //Local
                    //RestClient client = new RestClient("https://localhost:44330/api/v1/Account/register");
                    var requestIdentityRegister = new RestRequest(Method.POST);

                    requestIdentityRegister.AddHeader("Content-Type", "application/json");
                    var identityReq = new IdentityRegistrationRequest()
                    {
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Password = request.Password,
                        UserName = request.Email,
                        RoleName = request.RoleName
                    };
                    var body = JsonSerializer.Serialize(identityReq);
                    requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
                    IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
                    if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        newResponse = getRegisterResponse.Content;
                    }
                    var actualResponse = JsonSerializer.Deserialize<IdentityRegistrationResponse>(newResponse);

                    var customerNew = new Customer()
                    {
                        ID = Guid.NewGuid(),
                        EnglishFirstName = request.FirstName,
                        EnglishLastName = request.LastName,
                        Mobile = request.Mobile,
                        DateOfBirth = new DateTime(),
                        SalutationId = request.SalutationId,
                        IsActive = true,
                        NewsLetterSubscription = false,
                        Email = request.Email,
                        NIN = request.NIN,
                        userId = actualResponse.userId,
                        NationalIdTypeId = request.NationalIdTypeId
                    };
                    customerNew = await _customerRepository.AddAsync(customerNew);
                    response.Data = _mapper.Map<RegistrationResponse>(customerNew);
                    response.Succeeded = true;
                    response.Message = "Registered Successfully";
                }                
            }
            else
            {
                response.Succeeded = false;
                response.Message = "User Already Exist! Please Login with Credentials...";
            }
            return response;
        }
    }
}