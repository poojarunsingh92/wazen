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
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote
{
    public class WalaaTPLQuoteCommandHandler : IRequestHandler<WalaaTPLQuoteCommand, Response<WalaaTPLQuoteResponse>>
    {
        private readonly ILogger<WalaaTPLQuoteCommandHandler> _logger;
        private readonly Random _random = new Random();
        public WalaaTPLQuoteCommandHandler(ILogger<WalaaTPLQuoteCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Response<WalaaTPLQuoteResponse>> Handle(WalaaTPLQuoteCommand request, CancellationToken cancellationToken)
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

            var client = new RestClient("https://ivox-uat.walaa.com/walaaapiservice/Walaa/Insurance/TPLQuote");
            client.Authenticator = new HttpBasicAuthenticator(Username, Password);
            client.Timeout = -1;
            var requestPolicy = new RestRequest(Method.POST);
            requestPolicy.AddHeader("Authorization", "Basic V2FsYWFAMjU6V2FsYWEjMjAyISo=");
            requestPolicy.AddHeader("Content-Type", "application/json");
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            var body = JsonSerializer.Serialize<WalaaTPLQuoteCommand>(request, opt);
            //requestPolicy.AddParameter("application/json", "{\"ProviderCompanyCode\": \"25\", \"ProviderCompanyName\": \"WZAN Broker\",	\"ReferenceId\": \"ref0000001\", \"ProductTypeCode\": 1, \"PolicyEffectiveDate\": \"2021-04-11T09:50:47\", \"PostCode\": \"13318\",	\"InsuredIdTypeCode\": 1, \"InsuredId\": 1026055705, \"InsuredBirthDateH\": \"15-04-1394\",	\"InsuredBirthDateG\": \"07-05-1994\", \"InsuredGenderCode\": \"M\", \"InsuredNationalityCode\": \"113\", \"InsuredIdIssuePlaceCode\": \"1\", \"InsuredIdIssuePlace\": \"\", \"InsuredFirstNameAr\": \"سيش\", \"InsuredMiddleNameAr\": \"\", \"InsuredLastNameAr\": \"سيلادوراي\", \"InsuredFirstNameEn\": \"SUHESH\",	\"InsuredMiddleNameEn\": \"\",	\"InsuredLastNameEn\": \"SELLADURAI\", \"InsuredSocialStatusCode\": \"2\",	\"InsuredOccupationCode\": \"G\",	\"InsuredOccupation\": \"قطاع حكومي\"	\"InsuredEducationCode\": 5, \"InsuredChildrenBelow16Years\": 0, \"InsuredWorkCityCode\": \"1\", \"InsuredWorkCity\": \"الرياض\", \"InsuredCityCode\": \"1\", \"InsuredCity\": \"الرياض\",	 \"VehicleIdTypeCode\": 1,	\"VehicleId\": 535634510, \"VehiclePlateNumber\": 3037,	\"VehiclePlateText1\": \"ر\", \"VehiclePlateText2\": \"ي\", \"VehiclePlateText3\": \"ح\", \"VehicleChassisNumber\": \"2FMGK5B82FBA12551\",	\"VehicleOwnerName\": \"فهد عبدالعزيز محمد الداود\",	\"VehicleOwnerId\": 1026055705,	\"VehiclePlateTypeCode\": \"1\", \"VehicleModelYear\": 2015, \"VehicleModelCode\": \"55\",	\"VehicleModel\": \"فليكس\"	, \"VehicleMakerCode\": \"21\", \"VehicleMaker\": \"فورد\", \"VehicleMajorColorCode\": \"2\",	\"VehicleMajorColor\": \"أسود\", \"VehicleBodyTypeCode\": \"5\", \"VehicleRegPlaceCode\": \"1\", \"VehicleRegPlace\": \"الرياض\", \"VehicleRegExpiryDate\": \"09-10-1443\", \"VehicleCylinders\": 6, \"VehicleWeight\": 2248,	\"VehicleLoad\": 7,	\"VehicleOwnerTransfer\": false, \"VehicleValue\": 50000, \"DeductibleValue\": null, \"VehicleAgencyRepair\": false, \"VehicleEngineSizeCode\": 0, \"VehicleUseCode\": 1, \"VehicleMileage\": null,	\"VehicleTransmissionTypeCode\": 2,	\"VehicleMileageExpectedAnnualCode\": 1, \"VehicleAxleWeightCode\": null, \"Accidents\": null, \"VehicleOvernightParkingLocationCode\": 1, \"VehicleModificationDetails\": \"\", \"NCDFreeYears\": 11,	\"NCDReference\": \"NCD1102217343\", \"Drivers\": [{\"DriverTypeCode\": 1, \"DriverId\": 1026055705, \"DriverIdTypeCode\": 1, \"DriverNationalityCode\": \"113\", \"DriverGenderCode\": \"M\", \"DriverBirthDateG\": \"1974-05-07\", \"DriverBirthDateH\": \"15-04-1394\", \"DriverFirstNameAr\": \"فهد\", \"DriverMiddleNameAr\": \"عبدالعزيز\", \"DriverLastNameAr\": \"محمد الداود\", \"DriverFirstNameEn\": \"FAHAD\", \"DriverMiddleNameEn\": \"ABDULAZIZ\", \"DriverLastNameEn\": \"MOHAMMED ALDAWOOD\", \"DriverSocialStatusCode\": \"2\", \"DriverOccupationCode\": \"G\", \"DriverOccupation\": \"قطاع حكومي\", \"DriverDrivingPercentage\": 100, \"DriverEducationCode\": 5, \"DriverMedicalConditionCode\": 1, \"DriverChildrenBelow16Years\": 0, \"DriverHomeCityCode\": \"1\",	\"DriverHomeCity\": \"الرياض\",	 \"DriverWorkCityCode\": \"1\", \"DriverWorkCity\": \"الرياض\",	 \"DriverNCDFreeYears\": 11, \"DriverNCDReference\": \"NCD1102217343\", \"DriverRelationship\": null, \"DriverLicenses\": [{\"LicenseCountryCode\": 113, \"LicenseNumberYears\": 2, \"DriverLicenseTypeCode\": \"3\", \"DriverLicenseExpiryDate\": \"01-01-1449\"}], \"DriverViolations\": null, \"Accidents\": null}],	\"VehicleSpecifications\": [{\"VehicleSpecificationCode\": 1}, { \"VehicleSpecificationCode\": 2}]}", ParameterType.RequestBody);
            //requestPolicy.AddParameter("Application/json", "{\"ProviderCompanyCode\": \"25\",\"ProviderCompanyName\": \"WZAN Broker\",	\"ReferenceId\": \"ref0000001\",	\"ProductTypeCode\": 1,	\"PolicyEffectiveDate\": \"2021-04-11T09:50:47\",	\"PostCode\": \"13318\",	\"InsuredIdTypeCode\": 1,	\"InsuredId\": 1026055705,	\"InsuredBirthDateH\": \"15-04-1394\",	\"InsuredBirthDateG\": \"07-05-1994\",	\"InsuredGenderCode\": \"M\",	\"InsuredNationalityCode\": \"113\",	\"InsuredIdIssuePlaceCode\": \"1\",	\"InsuredIdIssuePlace\": \"\",	\"InsuredFirstNameAr\": \"سيش\",	\"InsuredMiddleNameAr\": \"\",	\"InsuredLastNameAr\": \"سيلادوراي\",	\"InsuredFirstNameEn\": \"SUHESH\",	\"InsuredMiddleNameEn\": \"\",	\"InsuredLastNameEn\": \"SELLADURAI\",	\"InsuredSocialStatusCode\": \"2\",	\"InsuredOccupationCode\": \"G\",	\"InsuredOccupation\": \"قطاع حكومي\",	\"InsuredEducationCode\": 5,	\"InsuredChildrenBelow16Years\": 0,	\"InsuredWorkCityCode\": \"1\",	\"InsuredWorkCity\": \"الرياض\",	\"InsuredCityCode\": \"1\",	\"InsuredCity\": \"الرياض\",	\"VehicleIdTypeCode\": 1,	\"VehicleId\": 535634510,	\"VehiclePlateNumber\": 3037,	\"VehiclePlateText1\": \"ر\",	\"VehiclePlateText2\": \"ي\",	\"VehiclePlateText3\": \"ح\",	\"VehicleChassisNumber\": \"2FMGK5B82FBA12551\",	\"VehicleOwnerName\": \"فهد عبدالعزيز محمد  الداود\",	\"VehicleOwnerId\": 1026055705,	\"VehiclePlateTypeCode\": \"1\",	\"VehicleModelYear\": 2015,	\"VehicleModelCode\": \"55\",	\"VehicleModel\": \"فليكس\",	\"VehicleMakerCode\": \"21\",	\"VehicleMaker\": \"فورد\",	\"VehicleMajorColorCode\": \"2\",	\"VehicleMajorColor\": \"أسود\",	\"VehicleBodyTypeCode\": \"5\",	\"VehicleRegPlaceCode\": \"1\",	\"VehicleRegPlace\": \"الرياض\",	\"VehicleRegExpiryDate\": \"09-10-1443\",	\"VehicleCylinders\": 6,	\"VehicleWeight\": 2248,	\"VehicleLoad\": 7,	\"VehicleOwnerTransfer\": false,	\"VehicleValue\": 50000,	\"DeductibleValue\": null,	\"VehicleAgencyRepair\": false,	\"VehicleEngineSizeCode\": 0,	\"VehicleUseCode\": 1,	\"VehicleMileage\": null,	\"VehicleTransmissionTypeCode\": 2,	\"VehicleMileageExpectedAnnualCode\": 1,	\"VehicleAxleWeightCode\": null,	\"Accidents\": null,	\"VehicleOvernightParkingLocationCode\": 1,	\"VehicleModificationDetails\": \"\",	\"NCDFreeYears\": 11,	\"NCDReference\": \"NCD1102217343\",	\"Drivers\": [{		\"DriverTypeCode\": 1,		\"DriverId\": 1026055705,		\"DriverIdTypeCode\": 1,			\"DriverNationalityCode\": \"113\",		\"DriverGenderCode\": \"M\",		\"DriverBirthDateG\": \"1974-05-07\",		\"DriverBirthDateH\": \"15-04-1394\",		\"DriverFirstNameAr\": \"فهد\",		\"DriverMiddleNameAr\": \"عبدالعزيز\",		\"DriverLastNameAr\": \"محمد الداود\",		\"DriverFirstNameEn\": \"FAHAD\",		\"DriverMiddleNameEn\": \"ABDULAZIZ\",		\"DriverLastNameEn\": \"MOHAMMED ALDAWOOD\",		\"DriverSocialStatusCode\": \"2\",		\"DriverOccupationCode\": \"G\",		\"DriverOccupation\": \"قطاع حكومي\",		\"DriverDrivingPercentage\": 100,		\"DriverEducationCode\": 5,		\"DriverMedicalConditionCode\": 1,		\"DriverChildrenBelow16Years\": 0,		\"DriverHomeCityCode\": \"1\",		\"DriverHomeCity\": \"الرياض\",		\"DriverWorkCityCode\": \"1\",		\"DriverWorkCity\": \"الرياض\",		\"DriverNCDFreeYears\": 11,		\"DriverNCDReference\": \"NCD1102217343\",		\"DriverRelationship\": null,		\"DriverLicenses\": [{\"LicenseCountryCode\": 113,\"LicenseNumberYears\": 2,\"DriverLicenseTypeCode\": \"3\",	\"DriverLicenseExpiryDate\": \"01-01-1449\"}],\"DriverViolations\": null,		\"Accidents\": null	}],	\"VehicleSpecifications\": [{\"VehicleSpecificationCode\": 1}, {\"VehicleSpecificationCode\": 2	}]}",ParameterType.RequestBody);
            requestPolicy.AddParameter("Application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(requestPolicy);
            if(response.Content==null)
            {
                var responseWalaaQuotes = new Response<WalaaTPLQuoteResponse>();
                return responseWalaaQuotes;
            }
            var actualResponse = JsonSerializer.Deserialize<WalaaTPLQuoteResponse>(response.Content);
            _logger.LogInformation("Handle Completed");
            return new Response<WalaaTPLQuoteResponse>(actualResponse);
        }
    }
}
