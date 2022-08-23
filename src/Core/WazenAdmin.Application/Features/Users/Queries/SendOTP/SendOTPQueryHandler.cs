using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Users.Queries.SendOTP
{
    public class SendOTPQueryHandler : IRequestHandler<SendOTPQuery, Response<SendOTPVm>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly Random _random = new Random();

        public SendOTPQueryHandler(IMapper mapper, IUserRepository userRepository, ILogger<SendOTPQueryHandler> logger, IMediator mediator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
            _mediator = mediator;
        }

        public async System.Threading.Tasks.Task<Response<SendOTPVm>> Handle(SendOTPQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                var resposeObject = new Response<SendOTPVm>("User is not available");
                return resposeObject;
            }
            var body = (_random.Next(1111, 9999)).ToString();
            //user.VerifyCode = body;
            await _userRepository.UpdateAsync(user);


            //Need to send otp on user email address 
            //Need use rest client

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

            //Server
            //RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + user.Email + "&Subject=" + "OTPVerification" + "&OTP=" + user.VerifyCode);

            //Local
            RestClient client = new RestClient("http://localhost:44330/api/v1/SendMailToCustomer/SendMailToCustomer?To=" + user.Email + "&Subject="+"OTPVerification"+"&OTP=" /*+ user.VerifyCode*/);
        

            var sentOTP = new RestRequest(Method.GET);
            sentOTP.AddHeader("Content-Type", "application/json");
            sentOTP.AddParameter("application/json", body, ParameterType.RequestBody);
            //sentOTP.AddParameter("To", user.Email);
            //sentOTP.AddParameter("Subject", "OTP Verification");
            //sentOTP.AddParameter("OTP", user.VerifyCode);
            IRestResponse sendOTPResponse = client.Execute(sentOTP);
            if (sendOTPResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = sendOTPResponse.Content;
            }

            var resp = new SendOTPVm() { VerifyCode = body };
            var response = new Response<SendOTPVm>(resp, "success");
            /*response.Data.VerifyCode = body;
            response.Succeeded = true;
            response.Message = "success";*/
            return response;
            throw new NotImplementedException();
        }
    }
}

