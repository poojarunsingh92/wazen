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

namespace WazenPolicy.Application.Features.Malath.Commands.MalathPolicy
{
    public class MalathPolicyCommandHandler : IRequestHandler<MalathPolicyCommand, Response<MalathPolicyResponse>>
    {
        private readonly ILogger<MalathPolicyCommandHandler> _logger;
        public MalathPolicyCommandHandler(ILogger<MalathPolicyCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Response<MalathPolicyResponse>> Handle(MalathPolicyCommand request, CancellationToken cancellationToken)
        {
            var Username = "WAZENUSER";
            var Password = "wazen@dK245K";

            var client = new RestClient("");
            client.Authenticator = new HttpBasicAuthenticator(Username, Password);
            client.Timeout = -1;
            var requestPolicy = new RestRequest(Method.POST);
            requestPolicy.AddHeader("Authorization", "Basic V2FsYWFAMjU6V2FsYWEjMjAyISo=");
            requestPolicy.AddHeader("Content-Type", "application/json");

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            var body = JsonSerializer.Serialize<MalathPolicyCommand>(request, opt);

            requestPolicy.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(requestPolicy);
            var actualResponse = JsonSerializer.Deserialize<MalathPolicyResponse>(response.Content);
            return new Response<MalathPolicyResponse>(actualResponse);
        }
    }
}
