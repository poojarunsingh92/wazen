using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Exceptions;
using WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote;
using WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote;
using WazenPolicy.Application.Models;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.ACIG.Command.ACIGCMPQuote
{
    public class ACIGCMPQuoteCommandHandler : IRequestHandler<ACIGCMPQuoteCommand, Response<ACIGCMPQuoteResponse>>
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly Random _random = new Random();

        public ACIGCMPQuoteCommandHandler(IMediator mediator, ILogger<ACIGCMPQuoteCommandHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<Response<ACIGCMPQuoteResponse>> Handle(ACIGCMPQuoteCommand request, CancellationToken cancellationToken)
        {          

            //request.UserId = "";
            //request.QuoteRequestRefNo= "UTTest" + (_random.Next(1000) + 1).ToString();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            string newResponseACIG = "";
            var Username = "Wazen";
            var Password = "rLg7/B#w9q";

            RestClient clientACIG = new RestClient("https://51.211.177.73/TestAcigGeneric/Api/Quote/GetQuotes");

            clientACIG.Authenticator = new HttpBasicAuthenticator(Username, Password);
            ACIGCMPQuoteCommand quoteRequest = new ACIGCMPQuoteCommand();
            Random ran = new Random();
            String b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 4;
            String random = "";

            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(36);
                random = random + b.ElementAt(a);
            }

            quoteRequest.QuoteRequestRefNo = random + (_random.Next(1000) + 1).ToString();
            var requestACIG = new RestRequest(Method.POST);
            requestACIG.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
            requestACIG.AddHeader("Content-Type", "application/json");
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string body = JsonSerializer.Serialize<ACIGCMPQuoteCommand>(quoteRequest, opt);
            //var req = "{ \"UserId\": 683, \"UserName\" :\"Test\", \"QuoteRequestRefNo\": \"UTTest207\",  \"Product\": \"Unified\", \"PolicyEffectiveDate\": \"2022-04-16 02:30:01\",  \"PromoCode\": null, \"InsuredInfo\": { \"IdTypeCode\": 2, \"IdNo\": \"2065564035\", \"NameEng\": \"Ameen Al rafie\", \"NameAr\": \"أمين الرافعي\", \"IdExpiryDate\": \"01-1442\", \"IdRegistrationCityCode\": \"7\", \"BirthDateG\": \"01-01-1983\", \"BirthDateH\": \"01-01-1420\", \"GenderCode\": 2, \"MaritalStatusCode\": 2, \"OccupationCode\": 1, \"EducationCode\": 1, \"NationalityCode\": 390,  \"ChildrenBelow16\": 0, \"MobileNo\": \"580235141\", \"EmailId\": \"gajula.suresh@amtpl.com\", \"NcdYears\": 5, \"NcdReference\": \"NCD12589\", \"NoOfAccidents\": 0, \"AccidentsLiability\": 0, \"IsTransferOfOwnership\": false, \"OwnerId\": null, \"Address\": { \"Street\": \"Makkah\", \"District\": \"Jeddah\", \"City\": \"Riyadh\", \"CityCode\": 34330, \"PostalCode\": \"58266\", \"BuildingNumber\": 2569, \"AdditionalNumber\": 5269, \"UnitNumber\": 0, \"LanguageCode\": null }, \"AccidentDetails\": { \"accidentDate\": null, \"carModel\": null, \"carType\": null, \"caseNumber\": null, \"causeOfAccident\": null, \"cityName\": null, \"damageParts\": null, \"driverAge\": null, \"driverIdNumber\": null, \"estimatedAmount\": 0, \"liability\": 0, \"sequenceNumber\": null }}, \"VehicleInfo\": { \"VehicleIdTypeCode\": 1, \"RepairTypeCode\": 2, \"BodyTypeCode\": 0, \"ChassisNumber\": \"MALC741B0LM177285\", \"ColorCode\": 1, \"ColorDesc\": \"White\",    \"SequenceNumber\": \"256968466\", \"CustomNumber\": null, \"Cylinders\": 0, \"DrivingCityCode\": 0, \"EngineSize\": null, \"ExpectedAnnualMileage\": 0, \"VehicleValue\": \"52565\", \"MakeCode\": \"11\", \"MakeCodeELM\": \"11\", \"MakeDesc\": \"Toyota\",    \"ModelCode\": \"45\",    \"ModelCodeELM\": \"45\", \"ModelDesc\": \"Fortuner\", \"ManufactureYear\": \"2011\", \"PlateTypeCode\": \"1\", \"PlateNumber\": \"8296\", \"FirstPlateLetter\": \"ص\", \"SecondPlateLetter\": \"ل\", \"ThirdPlateLetter\": \"ك\", \"NightParkingCode\": 1, \"RegistrationCityCode\": \"7\", \"RegistrationExpiryDate\": \"11-01-1445\", \"SeatsCapacity\": 0, \"TransmissionTypeCode\": 1, \"UsagePurposeCode\": 1, \"Weight\": 0, \"Automatic_Braking_System\": 2, \"Cruise_Control\": 2, \"Adaptive_Cruise_Control\": 2, \"Rear_Parking_Sensors\": 2, \"Front_Sensors\": 2, \"Front_Camera\": 2, \"Rear_Camera\": 2, \"Degree_Camera_360\": 2, \"Fire_Extinguisher\": 2, \"Modifications_In_The_car\": 1, \"Modifications_In_The_Car_Desc\": \"vehicle\", \"Vehicle_Axle_Weight\": null, \"Antilock_Braking_System\": 2  }, \"DriverInfo\": [{ \"IsPolicyHolder\": true, \"IsMaindriver\": true, \"IdTypeCode\": 1, \"IdNo\": \"1569854789\", \"NameEng\": \"Salman bin Nasser bin Hussein Al Sultan\", \"NameAr\": \"سلمان بن ناصر بن حسين السلطان\", \"BirthDateG\": null, \"BirthDateH\": \"01-14-1420\", \"DriverAge\": 0, \"GenderCode\": 1, \"MaritalStatusCode\": 1, \"OccupationCode\": 1, \"EducationCode\": 1, \"NationalityCode\": 390, \"ChildrenBelow16\": 0, \"RelationWithInsuredCode\": 1, \"HealthConditionsCode\": 1, \"MobileNo\": null, \"EmailId\": null, \"LicenseTypeCode\": 0, \"LicenseExpiryDate\": \"01-01-1442\", \"DrivingExpYears\": 5, \"NoOfYearsSaudiLicenseHeld\": 8, \"NcdYears\": 0, \"NcdReference\": null, \"VehicleUsagePercentage\": 100, \"WorkCompanyName\": null, \"TrafficViolationsCode\": null, \"CityCode\": null, \"HomeAddress\": null, \"OfficeAddress\": null, \"CountriesDrivingLicense\": [ { \"LicenseCountryCode\": 167, \"LicenseYears\": 8}, { \"LicenseCountryCode\": 171, \"LicenseYears\": 25 }]}]}";

            requestACIG.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = clientACIG.Execute(requestACIG);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponseACIG = response.Content;
            }
            else
            {
                var responseACIGQuotes = new Response<ACIGCMPQuoteResponse>();
                return responseACIGQuotes;
            }
            var actualResponseACIG = JsonSerializer.Deserialize<ACIGCMPQuoteResponse>(newResponseACIG);
            var responseACIGQuote = new Response<ACIGCMPQuoteResponse>(actualResponseACIG);
            return responseACIGQuote;
        }
    }
}
