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
using WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote
{
    public class WalaaComprehensiveQuoteCommandHandler : IRequestHandler<WalaaComprehensiveQuoteCommand, Response<WalaaComprehensiveQuoteResponse>>
    {
        private readonly ILogger<WalaaComprehensiveQuoteCommandHandler> _logger;
        private readonly Random _random = new Random();
        public WalaaComprehensiveQuoteCommandHandler(ILogger<WalaaComprehensiveQuoteCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Response<WalaaComprehensiveQuoteResponse>> Handle(WalaaComprehensiveQuoteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            Random ran = new Random();
            String b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 4;
            String random = "";

            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(36);
                random = random + b.ElementAt(a);
            }

            request.ReferenceId = random + (_random.Next(1000) + 1).ToString();
            var Username = "Walaa@25";
            var Password = "Walaa#202!*";

            var client = new RestClient("https://ivox-uat.walaa.com/walaaapiservice/Walaa/Insurance/CMPQuote");
            client.Authenticator = new HttpBasicAuthenticator(Username, Password);
            client.Timeout = -1;
            var requestPolicy = new RestRequest(Method.POST);
            requestPolicy.AddHeader("Authorization", "Basic V2FsYWFAMjU6V2FsYWEjMjAyISo=");
            requestPolicy.AddHeader("Content-Type", "application/json");
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            var body = JsonSerializer.Serialize<WalaaComprehensiveQuoteCommand>(request, opt);
            //requestPolicy.AddParameter("application/json", "{\"ProviderCompanyCode\": \"25\",\"ProviderCompanyName\": \"WZAN Broker\",	\"ReferenceId\": \"dab92f1aae87493\",	\"QuotationNo\": \"P03-QN-21-300-0000000417\",	\"ProductId\": \"2250\", \"InsuredId\": 2198197184,	\"InsuredMobileNumber\": \"0500995104\",	\"InsuredEmail\": \"suhesh@walaa.com\",	\"InsuredBuildingNo\": 3939,	\"InsuredZipCode\": 23337,	\"InsuredAdditionalNumber\": 7938,	\"InsuredUnitNo\": 17,	\"InsuredCity\": \"جدة\",	\"InsuredDistrict\": \"حي العزيزية\",	\"InsuredStreet\": \"غير معروف\", \"PaymentMethodCode\": 1, \"PaymentMethod\": null,	\"PaymentAmount\": 2541.07,	\"PaymentBillNumber\": \"504814300\",	\"PaymentUsername\": \"UNKNOWN\",	\"InsuredIBAN\": \"SA1210567890123456789012\",	\"InsuredBankCode\": \"10\", \"Benefits\": [{\"BenefitId\": \"146\"}, {\"BenefitId\": \"145\"}]}", ParameterType.RequestBody);

            requestPolicy.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(requestPolicy);
            if (response.Content == null)
            {
                var responseWalaaQuotes = new Response<WalaaComprehensiveQuoteResponse>();
                return responseWalaaQuotes;
            }
            var actualResponse = JsonSerializer.Deserialize<WalaaComprehensiveQuoteResponse>(response.Content);
            _logger.LogInformation("Handle Completed");
            return new Response<WalaaComprehensiveQuoteResponse>(actualResponse);
        }
    }
}
