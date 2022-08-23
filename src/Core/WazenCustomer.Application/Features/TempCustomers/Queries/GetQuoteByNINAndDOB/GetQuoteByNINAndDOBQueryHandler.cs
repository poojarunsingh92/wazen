using AutoMapper;
using MediatR;
using Microsoft.Extensions.Hosting;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Helper;
using WazenCustomer.Application.Models;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteByNINAndDOB
{
    public class GetQuoteByNINAndDOBQueryHandler : IRequestHandler<GetQuoteByNINAndDOBQuery, Response<GetQuoteByNINAndDOBVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IQueueService _queueService;
        private readonly Random _random = new Random();

        public GetQuoteByNINAndDOBQueryHandler(IMapper mapper, IQueueService queueService, ICustomerRepository customerRepository, ITempCustomerRepository tempCustomerQuoteRepository)
        {
            _mapper = mapper;
            _queueService = queueService;
            _customerRepository = customerRepository;
            _tempCustomerRepository = tempCustomerQuoteRepository;
        }

        public async Task<Response<GetQuoteByNINAndDOBVm>> Handle(GetQuoteByNINAndDOBQuery request, CancellationToken cancellationToken)
        {
            //First we will search in Customer by using NIN and DOB
            var customer = await _customerRepository.GetCustomerByNINAndDOB(request.NIN, request.DateOfBirth);
            if (customer == null)
            {
                //Will try to get data from TempCustomer if it not present Customer and present in TempCustomer
                var tempCustomer = await _tempCustomerRepository.GetQuoteByNINAndDOB(request.NIN, request.DateOfBirth);

                //Get data from Yakeen if it not present in TempCustomer as well
                if (tempCustomer == null)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


                    string newResponse1 = "";

                    //AzureServer
                    RestClient client1 = new RestClient("http://thirdparty.wazen.ml/api/v1/Citizen/getCitizenInfo");

                    //Server
                    //RestClient client1 = new RestClient("http://180.149.247.134:8097/api/v1/Citizen/getCitizenInfo");


                    //Local
                    //RestClient client1 = new RestClient("http://localhost:44337/api/v1/Citizen/getCitizenInfo");

                    var requestYakeenGetCitizenInfo = new RestRequest(Method.GET);
                    requestYakeenGetCitizenInfo.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
                    requestYakeenGetCitizenInfo.AddHeader("Content-Type", "application/json");
                    IRestResponse getCitizenInfoResponse = client1.Execute(requestYakeenGetCitizenInfo);
                    if (getCitizenInfoResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        newResponse1 = getCitizenInfoResponse.Content;
                    }
                    var actualResponse = JsonSerializer.Deserialize<GetCitizenByInfoVm>(newResponse1);

                    var tempCustomerData = _mapper.Map<TempCustomer>(actualResponse);
                    tempCustomerData.NIN = request.NIN;
                    tempCustomerData.SalutationId = 1;
                    tempCustomerData.DateOfBirth = request.DateOfBirth;
                    //tempCustomerData.Email = "abdulrahman.alnujaim@gmail.com";
                    tempCustomerData.Email = "shevateganeshd@gmail.com";
                    tempCustomerData.Mobile = "9302817323";
                    tempCustomerData.GenderId = 1;
                    tempCustomerData.NationalIdTypeId = 1;
                    tempCustomerData.EducationId = 1;
                    tempCustomerData.MaritalStatusId = 1;
                    //tempCustomerData.IsDelete = false;
                    tempCustomer = await _tempCustomerRepository.AddAsync(tempCustomerData);
                    await _queueService.SendMessageAsync<TempCustomer>(tempCustomer, "TempCustomer");                    
                }
                /*
                //OTP Send Logic Here
                //Verification Code Generation
                var body = (_random.Next(1111, 9999)).ToString();
                tempCustomer.VerifyCode = body;
                await _tempCustomerRepository.UpdateAsync(tempCustomer);

                //Need to send otp on user email address 
                //Need use rest client

                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                string newResponse = "";

                //Server
                //RestClient client2 = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);

                //Local
                RestClient client2 = new RestClient("http://localhost:54811/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + tempCustomer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + tempCustomer.VerifyCode);
                var sentOTP = new RestRequest(Method.GET);
                sentOTP.AddHeader("Content-Type", "application/json");
                sentOTP.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse sendOTPResponse = client2.Execute(sentOTP);
                if (sendOTPResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = sendOTPResponse.Content;
                }*/

                var tempCustomerDetailDto = _mapper.Map<GetQuoteByNINAndDOBVm>(tempCustomer);
                var response = new Response<GetQuoteByNINAndDOBVm>(tempCustomerDetailDto, "success");
                return response;
            }
            else
            {
                /*
                //OTP Send Logic Here
                //Verification Code Generation
                var body = (_random.Next(1111, 9999)).ToString();
                customer.VerifyCode = body;
                await _customerRepository.UpdateAsync(customer);

                //Need to send otp on user email address 
                //Need use rest client

                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                string newResponse = "";

                //Server
                //RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);

                //Local
                RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);
                var sentOTP = new RestRequest(Method.GET);
                sentOTP.AddHeader("Content-Type", "application/json");
                sentOTP.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse sendOTPResponse = client.Execute(sentOTP);
                if (sendOTPResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = sendOTPResponse.Content;
                }*/

                var tempCustomerDetailDto = _mapper.Map<GetQuoteByNINAndDOBVm>(customer);
                var response = new Response<GetQuoteByNINAndDOBVm>(tempCustomerDetailDto, "success");
                return response;
            }   
        }
    }
}