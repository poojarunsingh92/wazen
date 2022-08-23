using MediatR;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Walaa.Commands.WalaaPolicy
{
    public class WalaaPolicyCommandHandler : IRequestHandler<WalaaPolicyCommand, Response<WalaaPolicyResponse>>
    {
        private readonly ILogger<WalaaPolicyCommandHandler> _logger;
        public WalaaPolicyCommandHandler(ILogger<WalaaPolicyCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Response<WalaaPolicyResponse>> Handle(WalaaPolicyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            var Username = "Walaa@25";
            var Password = "Walaa#202!*";

            int PolicyType = 1;
            string url = string.Empty;
            if (PolicyType == 1)
            {
                //Comprehensive
                url = "https://ivox-uat.walaa.com/walaaapiservice/Walaa/Insurance/CMPPolicyRequest";
            }
            else
            {
                //TPL
                url = "https://ivox-uat.walaa.com/walaaapiservice/Walaa/Insurance/TPLPolicyRequest";
            }

            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator(Username, Password);
            client.Timeout = -1;
            var requestPolicy = new RestRequest(Method.POST);
            requestPolicy.AddHeader("Authorization", "Basic V2FsYWFAMjU6V2FsYWEjMjAyISo=");
            requestPolicy.AddHeader("Content-Type", "application/json");

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            var body = JsonSerializer.Serialize<WalaaPolicyCommand>(request, opt);

            requestPolicy.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(requestPolicy);
            var actualResponse = JsonSerializer.Deserialize<WalaaPolicyResponse>(response.Content);
            _logger.LogInformation("Handle Completed");
            return new Response<WalaaPolicyResponse>(actualResponse);
        }
    }
}
