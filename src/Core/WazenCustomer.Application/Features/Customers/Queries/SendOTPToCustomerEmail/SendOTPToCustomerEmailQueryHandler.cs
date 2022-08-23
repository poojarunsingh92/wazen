using AutoMapper;
using MediatR;
using RestSharp;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;
using System.Net;
using System.Text.Json;

namespace WazenCustomer.Application.Features.Customers.Queries.SendOTPToCustomerEmail
{
    public class SendOTPToCustomerEmailQueryHandler : IRequestHandler<SendOTPToCustomerEmailQuery, Response<SendOTPToCustomerEmailVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly Random _random = new Random();

        public SendOTPToCustomerEmailQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ILogger<SendOTPToCustomerEmailQueryHandler> logger, IMediator mediator)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _logger = logger;
            _mediator = mediator;
        }
        public async Task<Response<SendOTPToCustomerEmailVm>> Handle(SendOTPToCustomerEmailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByEmail(request.Email);
            if (customer == null)
            {
                var resposeObject = new Response<SendOTPToCustomerEmailVm>("Customer ID is not available");
                return resposeObject;
            }
            /*Verification Code Generation*/
            var body = (_random.Next(1111, 9999)).ToString();
            customer.VerifyCode = body;
            await _customerRepository.UpdateAsync(customer);

            //Need to send otp on user email address 
            //Need use rest client

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

            //AzureServevr
            RestClient client = new RestClient("http://notification.wazen.ml/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);

            //Server
            //RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);

            //Local
            //RestClient client = new RestClient("http://localhost:54811/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);
            var sentOTP = new RestRequest(Method.GET);
            sentOTP.AddHeader("Content-Type", "application/json");
            sentOTP.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse sendOTPResponse = client.Execute(sentOTP);
            if (sendOTPResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = sendOTPResponse.Content;
            }
            var otpResponse = JsonSerializer.Deserialize<SendOTPMailToCustomerVm>(newResponse);
            var resp = new SendOTPToCustomerEmailVm() { ID= customer.ID, Email = customer.Email, VerifyCode= otpResponse.data.verifyCode };
            var response = new Response<SendOTPToCustomerEmailVm>(resp, "success");
            return response;
        }
    }
}
