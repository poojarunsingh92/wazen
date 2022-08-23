using MediatR;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote
{
    public class MalathTPLQuoteCommandHandler : IRequestHandler<MalathTPLQuoteCommand, Response<MalathTPLQuoteResponse>>
    {
        private readonly ILogger<MalathTPLQuoteCommandHandler> _logger;
        private readonly ICountriesRepository _countriesRepository;
        public MalathTPLQuoteCommandHandler(ILogger<MalathTPLQuoteCommandHandler> logger, ICountriesRepository countriesRepository)
        {
            _logger = logger;
            _countriesRepository = countriesRepository;
        }

        public async Task<Response<MalathTPLQuoteResponse>> Handle(MalathTPLQuoteCommand request, CancellationToken cancellationToken)
        {
            //var data = await _countriesRepository.GetCountries();

            var Username = "WAZENUSER";
            var Password = "wazen@dK245K";

            var client = new RestClient("https://api.malath.com.sa/MalathMotorServiceTest/Api/Quotation");
            client.Authenticator = new HttpBasicAuthenticator(Username, Password);
            client.Timeout = -1;
            var requestPolicy = new RestRequest(Method.POST);
            requestPolicy.AddHeader("Authorization", "Basic V2FsYWFAMjU6V2FsYWEjMjAyISo=");
            requestPolicy.AddHeader("Content-Type", "application/json");
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            var body = JsonSerializer.Serialize<MalathTPLQuoteCommand>(request, opt);
            //requestPolicy.AddParameter("application/json", "{\"ProviderCompanyCode\": \"25\",\"ProviderCompanyName\": \"WZAN Broker\",	\"ReferenceId\": \"dab92f1aae87493\",	\"QuotationNo\": \"P03-QN-21-300-0000000417\",	\"ProductId\": \"2250\", \"InsuredId\": 2198197184,	\"InsuredMobileNumber\": \"0500995104\",	\"InsuredEmail\": \"suhesh@walaa.com\",	\"InsuredBuildingNo\": 3939,	\"InsuredZipCode\": 23337,	\"InsuredAdditionalNumber\": 7938,	\"InsuredUnitNo\": 17,	\"InsuredCity\": \"جدة\",	\"InsuredDistrict\": \"حي العزيزية\",	\"InsuredStreet\": \"غير معروف\", \"PaymentMethodCode\": 1, \"PaymentMethod\": null,	\"PaymentAmount\": 2541.07,	\"PaymentBillNumber\": \"504814300\",	\"PaymentUsername\": \"UNKNOWN\",	\"InsuredIBAN\": \"SA1210567890123456789012\",	\"InsuredBankCode\": \"10\", \"Benefits\": [{\"BenefitId\": \"146\"}, {\"BenefitId\": \"145\"}]}", ParameterType.RequestBody);
            requestPolicy.AddParameter("application/json", body, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(requestPolicy);
            //var code = response.StatusCode;
            var response = "{\"RequestReferenceNo\": \"64a007ba-b1ed-49af-a41d-900ebf19e730\", \"StatusCode\": 1,\"QuotationNo\": \"6927010\",\"QuotationDate\": \"2022-01-02T11:20:15+03:00\",    \"QuotationExpiryDate\": \"2022-01-03T03:20:15+03:00\",\"Products\": [{ \"ProductId\": \"6927010\",            \"ProductPrice\": 708.4,\"ExcessValue\": null,\"VehicleLimitValue\": null,\"PriceDetails\": [{\"PriceTypeCode\": \"SUB_PREM\",\"PriceValue\": 984.4, \"PercentageValue\": null },{ \"PriceTypeCode\": \"VAT\", \"PriceValue\": 106.26, \"PercentageValue\": 15.0 }, {\"PriceTypeCode\": \"NCD_DISC\",\"PriceValue\": 276.0,\"PercentageValue\": 30.0 } ],\"Covers\": [ { \"CoverCode\": 106,\"CoverId\": \"106\", \"CoverNameAr\": \"تغطية الحوادث الشخصية للسائق\", \"CoverNameEn\": \"Personal Accident Benefits - Driver\",\"CoverPrice\": 60.0 },{\"CoverCode\": 116,\"CoverId\": \"116\",\"CoverNameAr\": \"تغطية الحوادث الشخصية للراكب\",\"CoverNameEn\": \"Personal Accident Benefits - Passenger\", \"CoverPrice\": 260.0}]}],\"Errors\":[]}";
            //var actualResponse = JsonSerializer.Deserialize<MalathTPLQuoteResponse>(response.Content);
            if(response==null)
            {
                var responseMalathQuotes = new Response<MalathTPLQuoteResponse>();
                return responseMalathQuotes;
            }
            var actualResponse = JsonSerializer.Deserialize<MalathTPLQuoteResponse>(response);
            return new Response<MalathTPLQuoteResponse>(actualResponse);
        }
    }
}