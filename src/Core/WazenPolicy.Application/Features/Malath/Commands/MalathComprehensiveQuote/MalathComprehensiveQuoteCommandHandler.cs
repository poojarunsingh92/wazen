﻿using MediatR;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote
{
    public class MalathComprehensiveQuoteCommandHandler : IRequestHandler<MalathComprehensiveQuoteCommand, Response<MalathComprehensiveQuoteResponse>>
    {
        private readonly ILogger<MalathComprehensiveQuoteCommandHandler> _logger;
        public MalathComprehensiveQuoteCommandHandler(ILogger<MalathComprehensiveQuoteCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Response<MalathComprehensiveQuoteResponse>> Handle(MalathComprehensiveQuoteCommand request, CancellationToken cancellationToken)
        {
            var Username = "WAZENUSER";
            var Password = "wazen@dK245K";

            var client = new RestClient("https://api.malath.com.sa/MalathMotorServiceTest/Api/Quotation");
            client.Authenticator = new HttpBasicAuthenticator(Username, Password);
            client.Timeout = -1;
            var requestPolicy = new RestRequest(Method.POST);
            requestPolicy.AddHeader("Authorization", "Basic V2FsYWFAMjU6V2FsYWEjMjAyISo=");
            requestPolicy.AddHeader("Content-Type", "application/json");
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            var body = JsonSerializer.Serialize<MalathComprehensiveQuoteCommand>(request, opt);
            requestPolicy.AddParameter("application/json", body, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(requestPolicy);
            //var code = response.StatusCode;
            //var response = "{\"RequestReferenceNo\":\"de0d04f4-0aa1-4418-85b8-1834083b4367\",\"StatusCode\":1,\"QuotationNo\":\"6926956\",\"QuotationDate\":\"2022-01-02T08:40:43+03:00\",\"QuotationExpiryDate\":\"2022-01-03T00:40:43+03:00\",\"Products\":[{\"ProductId\":\"692695600000\",\"ProductPrice\":3155.4,\"ExcessValue\":0,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":3262.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":473.31,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":1006.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":1113.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"Car Hire facility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"PersonalAccidentBenefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"PersonalAccidentBenefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"Unnamed Driver Age not less than 21(Aditional deductible at 100% from primary deductible withMinimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"ThirdPartyLiability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"OwnDamage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"EmergencyMedicalExpenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"NaturalPeril-Hurricanes,Earthquakes,VolcanicEruptions,Tornado,Typhoon,Lightings,andLandslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"NaturalPeril-FloodandHail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing,ProtectionandRemoval\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695600500\",\"ProductPrice\":3069.4,\"ExcessValue\":500,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":3187.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":460.41,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":969.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":1087.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"CarHirefacility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"PersonalAccidentBenefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"PersonalAccidentBenefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"UnnamedDriverAgenotlessthan21(Aditionaldeductibleat100%fromprimarydeductiblewithMinimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"ThirdPartyLiability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"OwnDamage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"EmergencyMedicalExpenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"NaturalPeril-Hurricanes,Earthquakes,VolcanicEruptions,Tornado,Typhoon,Lightings,andLandslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"NaturalPeril-FloodandHail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing,ProtectionandRemoval\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695601000\",\"ProductPrice\":2960.4,\"ExcessValue\":1000,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":3092.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":444.06,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":921.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":1053.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"CarHirefacility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"PersonalAccidentBenefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"PersonalAccidentBenefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"UnnamedDriverAgenotlessthan21(Aditionaldeductibleat100%fromprimarydeductiblewithMinimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"ThirdPartyLiability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"OwnDamage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"EmergencyMedicalExpenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"NaturalPeril-Hurricanes,Earthquakes,VolcanicEruptions,Tornado,Typhoon,Lightings,andLandslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"NaturalPeril-FloodandHail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing,ProtectionandRemoval\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695601500\",\"ProductPrice\":2861.4,\"ExcessValue\":1500,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":3007.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":429.21,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":878.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":1024.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"CarHirefacility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"PersonalAccidentBenefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"PersonalAccidentBenefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"UnnamedDriverAgenotlessthan21(Aditionaldeductibleat100%fromprimarydeductiblewithMinimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"ThirdPartyLiability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"OwnDamage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"EmergencyMedicalExpenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"NaturalPeril-Hurricanes,Earthquakes,VolcanicEruptions,Tornado,Typhoon,Lightings,andLandslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"NaturalPeril-FloodandHail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing,ProtectionandRemoval\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695602000\",\"ProductPrice\":2774.4,\"ExcessValue\":2000,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":2931.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":416.16,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":840.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":997.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"CarHirefacility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"PersonalAccidentBenefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"PersonalAccidentBenefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"UnnamedDriverAgenotlessthan21(Aditionaldeductibleat100%fromprimarydeductiblewithMinimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"ThirdPartyLiability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"OwnDamage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"EmergencyMedicalExpenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"NaturalPeril-Hurricanes,Earthquakes,VolcanicEruptions,Tornado,Typhoon,Lightings,andLandslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"NaturalPeril-FloodandHail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing,ProtectionandRemoval\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695605000\",\"ProductPrice\":2480.4,\"ExcessValue\":5000,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":2675.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":372.06,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":712.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":907.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"CarHirefacility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"PersonalAccidentBenefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"PersonalAccidentBenefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"GeographicalareaExtensiontoinclude(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"Unnamed Driver Age not less than 21(Aditional deductible at 100% from primary deductible with Minimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"Third Party Liability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"Own Damage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"Emergency Medical Expenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"Natural Peril-Hurricanes, Earthquakes, Volcanic Eruptions,Tornado,Typhoon, Lightings, and Landslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"Natural Peril-Flood and Hail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing, Protection and Removal\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0}]}],\"Errors\":[]}";
            var response = "{\"RequestReferenceNo\":\"de0d04f4-0aa1-4418-85b8-1834083b4367\",\"StatusCode\":1,\"QuotationNo\":\"6926956\",\"QuotationDate\":\"2022-01-02T08:40:43+03:00\",\"QuotationExpiryDate\":\"2022-01-03T00:40:43+03:00\",\"Products\":[{\"ProductId\":\"692695600000\",\"ProductPrice\":3155.4,\"ExcessValue\":0,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":3262.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":473.31,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":1006.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":1113.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"Car Hire facility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"Personal Accident Benefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"Geographical area Extension to include(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"PersonalAccidentBenefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"Unnamed Driver Age not less than 21(Aditional deductible at 100% from primary deductible withMinimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"Third Party Liability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"Own Damage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"Emergency Medical Expenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"Natural Peril-Hurricanes, Earthquakes, Volcanic Eruptions, Tornado, Typhoon, Lightings, and Landslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"Natural Peril-Flood and Hail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing, Protection and Removal\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695600500\",\"ProductPrice\":3069.4,\"ExcessValue\":500,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":3187.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":460.41,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":969.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":1087.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"Car Hire facility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"Personal Accident Benefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"Geographical area Extension to include(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"Personal Accident Benefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"Unnamed Driver Age not less than 21(Aditional deductible at 100% from primary deductible with Minimum 1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"Third Party Liability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"Own Damage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"Emergenc yMedical Expenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"Natural Peril-Hurricanes, Earthquakes, Volcanic Eruptions,Tornado,Typhoon,Lightings,andLandslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"Natural Peril-FloodandHail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing, Protection and Removal\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695601000\",\"ProductPrice\":2960.4,\"ExcessValue\":1000,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":3092.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":444.06,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":921.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":1053.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"Car Hire facility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"Personal Accident Benefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"Geographical area Extension to include(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"Personal Accident Benefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"Unnamed Driver Age not less than 21(Aditional deductible at 100% from primary deductible with Minimum 1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"Third Party Liability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"Own Damage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"Emergency Medical Expenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"Natural Peril-Hurricanes, Earthquakes, Volcanic Eruptions, Tornado, Typhoon, Lightings,and Landslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"Natural Peril-FloodandHail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing, Protection and Removal\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695601500\",\"ProductPrice\":2861.4,\"ExcessValue\":1500,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":3007.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":429.21,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":878.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":1024.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"Car Hire facility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"Personal Accident Benefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"Geographical area Extension to include(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"Personal Accident Benefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(Egypt, Jordan & Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"Unnamed Driver Age not less than 21(Aditional deductible at 100% from primary deductible with Minimum 1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"Third Party Liability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"Own Damage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"Emergency Medical Expenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"Natural Peril-Hurricanes, Earthquakes, Volcanic Eruptions, Tornado, Typhoon,Lightings,and Landslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"Natural Peril-FloodandHail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing, Protection and Removal\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695602000\",\"ProductPrice\":2774.4,\"ExcessValue\":2000,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":2931.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":416.16,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":840.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":997.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"Car Hire facility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"Personal Accident Benefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"Geographical area Extension to include(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"Personal Accident Benefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"Unnamed Driver Age not less than 21(Aditional deductible at 100% from primary deductible with Minimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"Third Party Liability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"Own Damage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"Emergency Medical Expenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"Natural Peril-Hurricanes, Earthquakes, VolcanicEruptions, Tornado, Typhoon,Lightings, and Landslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"Natural Peril-Flood and Hail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing, Protection and Removal\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"AgencyRepairCover\",\"CoverPrice\":0.0}]},{\"ProductId\":\"692695605000\",\"ProductPrice\":2480.4,\"ExcessValue\":5000,\"VehicleLimitValue\":39000,\"PriceDetails\":[{\"PriceTypeCode\":\"SUB_PREM\",\"PriceValue\":2675.4,\"PercentageValue\":null},{\"PriceTypeCode\":\"VAT\",\"PriceValue\":372.06,\"PercentageValue\":15.0},{\"PriceTypeCode\":\"AGENCY\",\"PriceValue\":712.0,\"PercentageValue\":null},{\"PriceTypeCode\":\"NCD_DISC\",\"PriceValue\":907.0,\"PercentageValue\":35.0}],\"Covers\":[{\"CoverCode\":105,\"CoverId\":\"105\",\"CoverNameAr\":\"توفيرسيارةبديلة\",\"CoverNameEn\":\"CarHirefacility\",\"CoverPrice\":400.0},{\"CoverCode\":106,\"CoverId\":\"106\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللسائق\",\"CoverNameEn\":\"PersonalAccidentBenefits-Driver\",\"CoverPrice\":60.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0},{\"CoverCode\":113,\"CoverId\":\"113\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةلدولالخليجي\",\"CoverNameEn\":\"Geographical area Extension to include(GCC)\",\"CoverPrice\":200.0},{\"CoverCode\":114,\"CoverId\":\"114\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لدولالخليجي,لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(GCC,Egypt,Jordan&Lebanon)\",\"CoverPrice\":400.0},{\"CoverCode\":116,\"CoverId\":\"116\",\"CoverNameAr\":\"تغطيةالحوادثالشخصيةللراكب\",\"CoverNameEn\":\"Personal Accident Benefits-Passenger\",\"CoverPrice\":260.0},{\"CoverCode\":123,\"CoverId\":\"123\",\"CoverNameAr\":\"تغطيةالتوسعةالجغرافيةالعربية-لبنان,مصر,الأردن\",\"CoverNameEn\":\"Geographical area Extension to include(Egypt,Jordan&Lebanon)\",\"CoverPrice\":200.0},{\"CoverCode\":133,\"CoverId\":\"133\",\"CoverNameAr\":\"تغطيةسائقغيرمسمييبلغعمرهم21سنةوأكثر(التحملالإضافي100%منالتحملالأساسيبحدأدني1500)\",\"CoverNameEn\":\"Unnamed Driver Age not less than 21(Aditional deductible at 100% from primary deductible with Minimum1,500)\",\"CoverPrice\":0.0},{\"CoverCode\":100,\"CoverId\":\"100\",\"CoverNameAr\":\"المسؤوليةالمدنيةتجاهالغير-ضدالغير\",\"CoverNameEn\":\"Third Party Liability\",\"CoverPrice\":0.0},{\"CoverCode\":101,\"CoverId\":\"101\",\"CoverNameAr\":\"أضرارخاصة\",\"CoverNameEn\":\"Own Damage\",\"CoverPrice\":0.0},{\"CoverCode\":104,\"CoverId\":\"104\",\"CoverNameAr\":\"التكلفهالطبيهالطارئه\",\"CoverNameEn\":\"Emergency Medical Expenses\",\"CoverPrice\":0.0},{\"CoverCode\":132,\"CoverId\":\"132\",\"CoverNameAr\":\"الكوارثالطبيعية-الأعاصير،الزلازل،الانفجاراتالبركانية،الزوابعالإستوائية،البرق،وإنزلاقاتالتربة\",\"CoverNameEn\":\"Natural Peril-Hurricanes, Earthquakes, Volcanic Eruptions,Tornado,Typhoon, Lightings, and Landslide\",\"CoverPrice\":0.0},{\"CoverCode\":131,\"CoverId\":\"131\",\"CoverNameAr\":\"الكوارثالطبيعية-الفيضاناتوالسيولوالبرد\",\"CoverNameEn\":\"Natural Peril-Flood and Hail\",\"CoverPrice\":0.0},{\"CoverCode\":103,\"CoverId\":\"103\",\"CoverNameAr\":\"تغطيةالسحبوالحماية\",\"CoverNameEn\":\"Towing, Protection and Removal\",\"CoverPrice\":0.0},{\"CoverCode\":107,\"CoverId\":\"107\",\"CoverNameAr\":\"تغطيةالوكالة\",\"CoverNameEn\":\"Agency Repair Cover\",\"CoverPrice\":0.0}]}],\"Errors\":[]}";
            //var actualResponse = JsonSerializer.Deserialize<MalathTPLQuoteResponse>(response.Content);
            if (response == null)
            {
                var responseMalathQuotes = new Response<MalathComprehensiveQuoteResponse>();
                return responseMalathQuotes;
            }
            var actualResponse = JsonSerializer.Deserialize<MalathComprehensiveQuoteResponse>(response);
            return new Response<MalathComprehensiveQuoteResponse>(actualResponse);
        }
    }
}