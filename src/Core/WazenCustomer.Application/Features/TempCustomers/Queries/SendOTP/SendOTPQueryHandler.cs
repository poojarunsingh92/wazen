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

namespace WazenCustomer.Application.Features.TempCustomers.Queries.SendOTP
{
    public class SendOTPQueryHandler : IRequestHandler<SendOTPQuery, Response<SendOTPVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly Random _random = new Random();

        public SendOTPQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ILogger<SendOTPQueryHandler> logger, IMediator mediator)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _logger = logger;
            _mediator = mediator;
        }
        public async Task<Response<SendOTPVm>> Handle(SendOTPQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByCustomerID(request.CustomerID);
            if (customer == null)
            {
                var resposeObject = new Response<SendOTPVm>("Customer ID is not available");
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

            //Server
            //RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);

            //Server
            RestClient client = new RestClient("http://notification.wazen.ml/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);

            //Local
            //RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + customer.Email + "&Subject=" + "OTPVerification" + "&OTP=" + customer.VerifyCode);
            var sentOTP = new RestRequest(Method.GET);
            sentOTP.AddHeader("Content-Type", "application/json");
            sentOTP.AddParameter("application/json", body, ParameterType.RequestBody);            
            IRestResponse sendOTPResponse = client.Execute(sentOTP);
            if (sendOTPResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = sendOTPResponse.Content;
            }

            var resp = new SendOTPVm() { VerifyCode = body };
            var response = new Response<SendOTPVm>(resp, "success");
            return response;
        }
    }
}