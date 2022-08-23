using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Features.ACIG.Command.ACIGCMPQuote;
using WazenPolicy.Application.Features.ACIG.Command.ACIGTPLQuote;
using WazenPolicy.Application.Features.TempCustomers.Queries.GetTempCustomerDetailByID;
using WazenPolicy.Application.Features.Drivers.Queries.GetDriverDetailByCustomerVehicleID;
using WazenPolicy.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList;
using WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote;
using WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote;
using WazenPolicy.Application.Features.Vehicles.Queries.GetVehicleDetailByID;
using WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationListByVehicleID;
using WazenPolicy.Application.Features.ViolationTypes.Queries.GetViolationTypeDetailByID;
using WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote;
using WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote;
using WazenPolicy.Application.Responses;
using WazenPolicy.Domain.Entities;
using WazenPolicy.Application.Features.TempVehicles.Queries.GetTempVehicleDetailByID;
using WazenPolicy.Application.Features.TempDrivers.Queries.GetTempDriverDetailByCustomerVehicleID;
using WazenPolicy.Application.Features.Customers.Queries.GetCustomerDetailByID;
using WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationListByVehicleID;

using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using WazenPolicy.Application.Models.RedisCache;

namespace WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseFromRedis
{
  public  class GetQuoteResponseFromRedisQueryHandler : IRequestHandler<GetQuoteResponseFromRedisQuery, Response<RedisQuoteResponse>>
    {
        #region - variables and repositories 
        //private readonly IQuoteResponseRepository _quoteResponseRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        private ITempVehicleViolationRepository _tempVehicleViolationRespository;
        private IVehicleViolationRepository _vehicleViolationRespository;
        private IQuoteResponseRepository _quoteResponseRepository;

        //Repositories objects of ICs LookUp Tables
        private RedisDataConnection<ICAdditionalCoverr> _additionalCoverRepository;
        private RedisDataConnection<ICBankCode> _bankCodeRepository;
        private RedisDataConnection<ICCardIdType> _cardIdTypeRepository;
        private RedisDataConnection<ICCities> _citiesRepository;
        private RedisDataConnection<ICCountries> _countriesRepository;
        private RedisDataConnection<ICDeductable> _deductableRepository;
        private RedisDataConnection<ICDiscount> _discountRepository;
        private RedisDataConnection<ICDriverType> _driverTypeRepository;
        private RedisDataConnection<ICDrivingPercentage> _drivingPercentageRepository;
        private RedisDataConnection<ICEducation> _educationRepository;
        private RedisDataConnection<ICGender> _genderRepository;
        private RedisDataConnection<ICHealthCondition> _healthConditionRepository;
        private RedisDataConnection<ICImageTitle> _imageTitleRepository;
        private RedisDataConnection<ICLicenseType> _licenseTypeRepository;
        private RedisDataConnection<ICMaritalStatus> _maritalStatusRepository;
        private RedisDataConnection<ICMileages> _mileageRepository;
        private RedisDataConnection<ICNationality> _nationalityRepository;
        private RedisDataConnection<ICNCDFreeYear> _nCDFreeYearRepository;
        private RedisDataConnection<ICOccupation> _occupationRepository;
        private RedisDataConnection<ICParkingLocation> _parkingLocationRepository;
        private RedisDataConnection<ICPaymentMethod> _paymentMethodRepository;
        private RedisDataConnection<ICPlateLetter> _plateLetterRepository;
        private RedisDataConnection<ICPremiumBreakdownn> _premiumBreakdownRepository;
        private RedisDataConnection<ICPriceType> _priceTypeRepository;
        private RedisDataConnection<ICProductType> _productTypeRepository;
        private RedisDataConnection<ICRelationship> _relationshipRepository;
        private RedisDataConnection<ICRepairType> _repairTypeRepository;
        private RedisDataConnection<ICTransmissionType> _transmissionTypeRepository;
        private RedisDataConnection<ICVehicleAxlesWeight> _vehicleAxlesWeightRepository;
        private RedisDataConnection<ICVehicleColor> _vehicleColorRepository;
        private RedisDataConnection<ICVehicleEngineSize> _vehicleEngineSizeRepository;
        private RedisDataConnection<ICVehicleIdType> _vehicleIdTypeRepository;
        private RedisDataConnection<ICVehiclePlateType> _vehiclePlateTypeRepository;
        private RedisDataConnection<ICVehicleSpecificationn> _vehicleSpecificationRepository;
        private RedisDataConnection<ICVehicleUses> _vehicleUsesRepository;
        private RedisDataConnection<ICViolation> _violationRepository;
        private IDistributedCache _cache;

        #endregion

        #region - constructor
        public GetQuoteResponseFromRedisQueryHandler(IMapper mapper, IMediator mediator,
            ILogger<GetQuoteResponseFromRedisQueryHandler> logger,
           IQuoteResponseRepository quoteResponseRepository,
            ITempVehicleViolationRepository tempVehicleViolationRespository,
           IVehicleViolationRepository vehicleViolationRespository,
            RedisDataConnection<ICAdditionalCoverr> additionalCoverRepository,
            RedisDataConnection<ICBankCode> bankCodeRepository,
            RedisDataConnection<ICCities> citiesRepository,
            RedisDataConnection<ICCardIdType> cardIdTypeRepository,
            RedisDataConnection<ICCountries> countriesRepository,
            RedisDataConnection<ICDeductable> deductableRepository,
            RedisDataConnection<ICDiscount> discountRepository,
            RedisDataConnection<ICDriverType> driverTypeRepository,
            RedisDataConnection<ICDrivingPercentage> drivingPercentageRepository,
            RedisDataConnection<ICEducation> educationRepository,
            RedisDataConnection<ICGender> genderRepository,
            RedisDataConnection<ICHealthCondition> healthConditionRepository,
            RedisDataConnection<ICImageTitle> imageTitleRepository,
            RedisDataConnection<ICLicenseType> licenseTypeRepository,
            RedisDataConnection<ICMaritalStatus> maritalStatusRepository,
            RedisDataConnection<ICMileages> mileageRepository,
            RedisDataConnection<ICNationality> nationalityRepository,
            RedisDataConnection<ICNCDFreeYear> nCDFreeYearRepository,
            RedisDataConnection<ICOccupation> occupationRepository,
            RedisDataConnection<ICParkingLocation> parkingLocationRepository,
            RedisDataConnection<ICPaymentMethod> paymentMethodRepository,
            RedisDataConnection<ICPlateLetter> plateLetterRepository,
            RedisDataConnection<ICPremiumBreakdownn> premiumBreakdownRepository,
            RedisDataConnection<ICPriceType> priceTypeRepository,
            RedisDataConnection<ICProductType> productTypeRepository,
            RedisDataConnection<ICRelationship> relationshipRepository,
            RedisDataConnection<ICRepairType> repairTypeRepository,
            RedisDataConnection<ICTransmissionType> transmissionTypeRepository,
            RedisDataConnection<ICVehicleAxlesWeight> vehicleAxlesWeightRepository,
            RedisDataConnection<ICVehicleColor> vehicleColorRepository,
            RedisDataConnection<ICVehicleEngineSize> vehicleEngineSizeRepository,
            RedisDataConnection<ICVehicleIdType> vehicleIdTypeRepository,
            RedisDataConnection<ICVehiclePlateType> vehiclePlateTypeRepository,
            RedisDataConnection<ICVehicleSpecificationn> vehicleSpecificationRepository,
            RedisDataConnection<ICVehicleUses> vehicleUsesRepository,
            RedisDataConnection<ICViolation> violationRepository,
            IDistributedCache cache
            )
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _tempVehicleViolationRespository = tempVehicleViolationRespository;
            _vehicleViolationRespository = vehicleViolationRespository;
            _quoteResponseRepository = quoteResponseRepository;
            //
            _additionalCoverRepository = additionalCoverRepository;
            _bankCodeRepository = bankCodeRepository;
            _cardIdTypeRepository = cardIdTypeRepository;
            _citiesRepository = citiesRepository;
            _countriesRepository = countriesRepository;
            _deductableRepository = deductableRepository;
            _discountRepository = discountRepository;
            _driverTypeRepository = driverTypeRepository;
            _drivingPercentageRepository = drivingPercentageRepository;
            _educationRepository = educationRepository;
            _genderRepository = genderRepository;
            _healthConditionRepository = healthConditionRepository;
            _imageTitleRepository = imageTitleRepository;
            _licenseTypeRepository = licenseTypeRepository;
            _maritalStatusRepository = maritalStatusRepository;
            _mileageRepository = mileageRepository;
            _nationalityRepository = nationalityRepository;
            _nCDFreeYearRepository = nCDFreeYearRepository;
            _occupationRepository = occupationRepository;
            _parkingLocationRepository = parkingLocationRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _plateLetterRepository = plateLetterRepository;
            _premiumBreakdownRepository = premiumBreakdownRepository;
            _priceTypeRepository = priceTypeRepository;
            _productTypeRepository = productTypeRepository;
            _relationshipRepository = relationshipRepository;
            _repairTypeRepository = repairTypeRepository;
            _transmissionTypeRepository = transmissionTypeRepository;
            _vehicleAxlesWeightRepository = vehicleAxlesWeightRepository;
            _vehicleColorRepository = vehicleColorRepository;
            _vehicleEngineSizeRepository = vehicleEngineSizeRepository;
            _vehicleIdTypeRepository = vehicleIdTypeRepository;
            _vehiclePlateTypeRepository = vehiclePlateTypeRepository;
            _vehicleSpecificationRepository = vehicleSpecificationRepository;
            _vehicleUsesRepository = vehicleUsesRepository;
            _violationRepository = violationRepository;
            _cache = cache;
        }
        #endregion
        public async Task<Response<RedisQuoteResponse>> Handle(GetQuoteResponseFromRedisQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("QuoteResponse Handle Initiated");

            #region Fetching Details of Customer and Vehicle Starts
            _logger.LogInformation("CustomerDetails Initiated");
            var tempCustomerResponse = await _mediator.Send(new GetCustomerDetailByIDQuery() { ID = request.CustomerID });
            if (tempCustomerResponse.Data == null)
            {
                tempCustomerResponse = await _mediator.Send(new GetTempCustomerDetailByIDQuery() { ID = request.CustomerID });
            }
            _logger.LogInformation("TempCustomerDetails Completed");

            _logger.LogInformation("VehicleDetails Initiated");
            var tempVehicleResponse = await _mediator.Send(new GetVehicleDetailByIDQuery() { ID = request.VehicleID });
            if (tempVehicleResponse.Data == null)
            {
                tempVehicleResponse = await _mediator.Send(new GetTempVehicleDetailByIDQuery() { ID = request.VehicleID });
            }
            _logger.LogInformation("VehicleDetails Completed");

            _logger.LogInformation("DriverDetails Initiated");
            var tempDriverResponse = await _mediator.Send(new GetDriverDetailByCustomerVehicleIDQuery() { CustomerVehicleId = request.VehicleID });
            if (tempDriverResponse.Data == null)
            {
                tempDriverResponse = await _mediator.Send(new GetTempDriverDetailByCustomerVehicleIDQuery() { CustomerVehicleId = request.VehicleID });
            }
            _logger.LogInformation("DriverDetails Completed");

            _logger.LogInformation("VehicleViolationDetails Initiated");
            var vehicleViolationResponse = await _mediator.Send(new GetVehicleViolationListByVehicleIDQuery() { VehicleID = request.VehicleID });
            List<VehicleViolation> vehicleViolationsResponse = await _vehicleViolationRespository.GetVehicleViolationListByVehicleID(request.VehicleID);
            if (vehicleViolationResponse == null)
            {
                vehicleViolationResponse = await _mediator.Send(new GetTempVehicleViolationListByVehicleIDQuery() { VehicleID = request.VehicleID });
                vehicleViolationsResponse = await _tempVehicleViolationRespository.GetTempVehicleViolationListByVehicleID(request.VehicleID);
            }
            _logger.LogInformation("VehicleViolationDetails Completed");

            _logger.LogInformation("ViolationTypeDetails Initiated");
            var violationTypeResponse = new List<ViolationType>();
            if (vehicleViolationsResponse != null)
            {
                for (int i = 0; i < vehicleViolationsResponse.Count; i++)
                {
                    var violationType = await _mediator.Send(new GetViolationTypeDetailByIDQuery() { ID = vehicleViolationsResponse[i].ViolationTypeId ?? default(int) });
                    ViolationType type = new ViolationType();
                    type = _mapper.Map<ViolationType>(violationType.Data);
                    violationTypeResponse.Add(type);
                }
            }

            _logger.LogInformation("ViolationTypeDetails Completed");
            #endregion Fetching Details of Customer and Vehicle Ends

            #region Fetching Data of the Insurance Companies 
            var insuranceCompanies = await _mediator.Send(new GetInsuranceCompanyListQuery());

            _logger.LogInformation("InsuranceCompanies LookUp Table Values Fetch Started");
            #endregion

            List<ICAdditionalCoverr> additionalCoverList = await _additionalCoverRepository.RedisData("additionalCoverList");
            List<ICBankCode> bankCodeList = await _bankCodeRepository.RedisData("bankCodeList");
            List<ICCardIdType> cardIdTypeList = await _cardIdTypeRepository.RedisData("cardIdTypeList");
            List<ICCities> citiesList = await _citiesRepository.RedisData("citiesList");
            List<ICCountries> countriesList = await _countriesRepository.RedisData("countriesList");
            List<ICDeductable> deductableList = await _deductableRepository.RedisData("deductableList");
            List<ICDiscount> discountList = await _discountRepository.RedisData("discountList");
            List<ICDriverType> driverTypeList = await _driverTypeRepository.RedisData("driverTypeList");
            List<ICDrivingPercentage> drivingPercentageList = await _drivingPercentageRepository.RedisData("drivingPercentageList");
            List<ICEducation> educationList = await _educationRepository.RedisData("educationList");
            List<ICGender> genderList = await _genderRepository.RedisData("genderList");
            List<ICHealthCondition> healthConditionList = await _healthConditionRepository.RedisData("healthConditionList");
            List<ICImageTitle> imageTitleList = await _imageTitleRepository.RedisData("imageTitleList");
            List<ICLicenseType> licenseTypeList = await _licenseTypeRepository.RedisData("licenseTypeList");
            List<ICMaritalStatus> maritalStatusList = await _maritalStatusRepository.RedisData("maritalStatusList");
            List<ICMileages> mileageList = await _mileageRepository.RedisData("mileageList");
            List<ICNationality> nationalitiesList = await _nationalityRepository.RedisData("nationalitiesList");
            List<ICNCDFreeYear> nCDFreeYearList = await _nCDFreeYearRepository.RedisData("nCDFreeYearList");
            List<ICOccupation> occupationList = await _occupationRepository.RedisData("occupationList");
            List<ICParkingLocation> parkingLocationList = await _parkingLocationRepository.RedisData("parkingLocationList");
            List<ICPaymentMethod> paymentMethodList = await _paymentMethodRepository.RedisData("paymentMethodList");
            List<ICPlateLetter> plateLetterList = await _plateLetterRepository.RedisData("plateLetterList");
            List<ICPremiumBreakdownn> premiumBreakList = await _premiumBreakdownRepository.RedisData("premiumBreakList");
            List<ICPriceType> priceTypeList = await _priceTypeRepository.RedisData("priceTypeList");
            List<ICProductType> productTypeList = await _productTypeRepository.RedisData("productTypeList");
            List<ICRelationship> relationshipList = await _relationshipRepository.RedisData("relationshipList");
            List<ICRepairType> repairTypeList = await _repairTypeRepository.RedisData("repairTypeList");
            List<ICTransmissionType> transmissionTypeList = await _transmissionTypeRepository.RedisData("transmissionTypeList");
            List<ICVehicleAxlesWeight> vehicleAxlesWeightList = await _vehicleAxlesWeightRepository.RedisData("vehicleAxlesWeightList");
            List<ICVehicleColor> vehicleColorList = await _vehicleColorRepository.RedisData("vehicleColorList");
            List<ICVehicleEngineSize> vehicleEngineSizeList = await _vehicleEngineSizeRepository.RedisData("vehicleEngineSizeList");
            List<ICVehicleIdType> vehicleIdTypeList = await _vehicleIdTypeRepository.RedisData("vehicleIdTypeList");
            List<ICVehiclePlateType> vehiclePlateTypeList = await _vehiclePlateTypeRepository.RedisData("vehiclePlateTypeList");
            List<ICVehicleSpecificationn> vehicleSpecificationList = await _vehicleSpecificationRepository.RedisData("vehicleSpecificationList");
            List<ICVehicleUses> vehicleUsesList = await _vehicleUsesRepository.RedisData("vehicleUsesList");
            List<ICViolation> violationList = await _violationRepository.RedisData("violationList");
            RedisQuoteResponse listQuotes = new RedisQuoteResponse();
            listQuotes.Quote = new List<Quote>();
            //As of now do not have access to Insurance Company Details so commented
            //var insuranceCompanies = await _insuranceCompaniesRepository.ListAllAsync();
            listQuotes.customerid = request.CustomerID.ToString();

            if (request.QuoteType == "TPL")
            {
                _logger.LogInformation("TPL Quote  Initiated");
                #region NCD Eligibility Starts
                //NCD Eligibility Starts

                //Start of NCDEligibility
                //Here NCDEligibility API call will happen and using these(NCDReference and NCDFreeYears) 2 response values ACIG, Walaa and Malath API will get call

                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                string newResponse = "";

                //AzureServer
                RestClient client = new RestClient("http://thirdparty.wazen.ml/api/v1/NCDEligibility/NCDEligibility");

                //Server
                //RestClient client = new RestClient("http://180.149.247.134:8097/api/v1/NCDEligibility/NCDEligibility");

                var requestNCDEligibility = new RestRequest(Method.GET);
                requestNCDEligibility.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
                requestNCDEligibility.AddHeader("Content-Type", "application/json");
                //requestNCDEligibility.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse getNCDEligibilityResponse = client.Execute(requestNCDEligibility);
                if (getNCDEligibilityResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = getNCDEligibilityResponse.Content;
                }
                NCDEligiblityResponseRedis nCDEligibilityResponse = new NCDEligiblityResponseRedis();
                if (newResponse != "")
                    nCDEligibilityResponse = JsonSerializer.Deserialize<NCDEligiblityResponseRedis>(newResponse);

                //NCD Eligibility Ends
                #endregion NCD Eligibility Ends

                #region TPL ACIG
                //TPL ACIG Starts                
                #region Need to given call to TPL ACIG                

                Guid ICID = insuranceCompanies.Data[0].Id;
                //Guid ICID = Guid.Parse("f6c16294-a259-442c-b343-f526bc9dd8cd");//insuranceCompanies.Data[0].Id;
                //Guid ICID = Guid.Parse("193b9cd6-2a2e-41ff-b4a3-02668e32d123");//insuranceCompanies.Data[0].Id;

                _logger.LogInformation("Retrieving matching record from Lists by Passing Value and ACIG ICID Initiated");
                var addCovers = additionalCoverList.FirstOrDefault<ICAdditionalCoverr>(x => x.Description == "Personal Accident Benefit to Driver " && x.ICID == ICID);
                var bankCode = bankCodeList.FirstOrDefault<ICBankCode>(x => x.Description == "National Bank of Kuwait" && x.ICID == ICID);
                var cardIdType = cardIdTypeList.FirstOrDefault<ICCardIdType>(x => x.Description == "Citizen" && x.ICID == ICID);
                var city = citiesList.FirstOrDefault<ICCities>(x => x.Description == "KALWAH" && x.ICID == ICID);
                var country = countriesList.FirstOrDefault<ICCountries>(x => x.Description == "Resident" && x.ICID == ICID);
                var deductable = deductableList.FirstOrDefault<ICDeductable>(x => x.Description == "0,5000,7500,10000,25000,50000" && x.ICID == ICID);
                var discount = discountList.FirstOrDefault<ICDiscount>(x => x.Description == "No Claim Discount" && x.ICID == ICID);
                var driverType = driverTypeList.FirstOrDefault<ICDriverType>(x => x.Description == "Main Driver" && x.ICID == ICID);
                var drivingPercent = drivingPercentageList.FirstOrDefault<ICDrivingPercentage>(x => x.Description == "0.5" && x.ICID == ICID);
                var education = educationList.FirstOrDefault<ICEducation>(x => x.Description == "None" && x.ICID == ICID);
                var gender = genderList.FirstOrDefault<ICGender>(x => x.Description == "Male" && x.ICID == ICID);
                var healthCondition = healthConditionList.FirstOrDefault<ICHealthCondition>(x => x.Description == "During daytime only" && x.ICID == ICID);
                var imageTitle = imageTitleList.FirstOrDefault<ICImageTitle>(x => x.Description == "Image Front" && x.ICID == ICID);
                var licenseType = licenseTypeList.FirstOrDefault<ICLicenseType>(x => x.Description == "Private under 25 Years" && x.ICID == ICID);
                var maritalStatus = maritalStatusList.FirstOrDefault<ICMaritalStatus>(x => x.Description == "Single" && x.ICID == ICID);
                var mileage = mileageList.FirstOrDefault<ICMileages>(x => x.Description == "Less than 50,000 KM" && x.ICID == ICID);
                var nationality = nationalitiesList.FirstOrDefault<ICNationality>(x => x.Description == "Suede" && x.ICID == ICID);
                var ncdFreeYear = nCDFreeYearList.FirstOrDefault<ICNCDFreeYear>(x => x.Description == "Bonus" && x.ICID == ICID);
                var occupation = occupationList.FirstOrDefault<ICOccupation>(x => x.Description == "Employee" && x.ICID == ICID);
                var parkingLocation = parkingLocationList.FirstOrDefault<ICParkingLocation>(x => x.Description == "Garage" && x.ICID == ICID);
                var paymentMethod = paymentMethodList.FirstOrDefault<ICPaymentMethod>(x => x.Description == "MASTER" && x.ICID == ICID);
                var plateLetter = plateLetterList.FirstOrDefault<ICPlateLetter>(x => x.Description == "" && x.ICID == ICID);
                var premium = premiumBreakList.FirstOrDefault<ICPremiumBreakdownn>(x => x.Description == "Basic Cover " && x.ICID == ICID);
                var priceType = priceTypeList.FirstOrDefault<ICPriceType>(x => x.Description == "Image Right" && x.ICID == ICID);
                var productType = productTypeList.FirstOrDefault<ICProductType>(x => x.Description == "TPL" && x.ICID == ICID);
                var relationship = relationshipList.FirstOrDefault<ICRelationship>(x => x.Description == "Brother / Sister" && x.ICID == ICID);
                var repairType = repairTypeList.FirstOrDefault<ICRepairType>(x => x.Description == "Agency" && x.ICID == ICID);
                var transmissionType = transmissionTypeList.FirstOrDefault<ICTransmissionType>(x => x.Description == "Manual" && x.ICID == ICID);
                var vehicleAxlesWeight = vehicleAxlesWeightList.FirstOrDefault<ICVehicleAxlesWeight>(x => x.Description == "Less than19999 Tons" && x.ICID == ICID);
                var vehicleColor = vehicleColorList.FirstOrDefault<ICVehicleColor>(x => x.Description == "Black" && x.ICID == ICID);
                var vehicleEngineSize = vehicleEngineSizeList.FirstOrDefault<ICVehicleEngineSize>(x => x.Description == "More than 4001CC" && x.ICID == ICID);
                var vehicleIdType = vehicleIdTypeList.FirstOrDefault<ICVehicleIdType>(x => x.Description == "Sequence" && x.ICID == ICID);
                var vehiclePlateType = vehiclePlateTypeList.FirstOrDefault<ICVehiclePlateType>(x => x.Description == "commercial Transport" && x.ICID == ICID);
                var vehicleSpecification = vehicleSpecificationList.FirstOrDefault<ICVehicleSpecificationn>(x => x.Description == "FRONT SENSORS" && x.ICID == ICID);
                var vehicleUses = vehicleUsesList.FirstOrDefault<ICVehicleUses>(x => x.Description == "Light Commercial" && x.ICID == ICID);
                var violation = violationList.FirstOrDefault<ICViolation>(x => x.Description == "Carrying out road-works before notifying the relevant authorities" && x.ICID == ICID);
                _logger.LogInformation("Retrieving matching record from Lists by Passing Value and ACIG ICID Completed");

                ACIGTPLQuoteCommand acigTPLQuoteCommand = new ACIGTPLQuoteCommand();

                #region Adding Lookup values into ACIG Command Request
                acigTPLQuoteCommand.UserId = 755;
                acigTPLQuoteCommand.UserName = "Wazen";
                acigTPLQuoteCommand.QuoteRequestRefNo = "UTTest";
                acigTPLQuoteCommand.Product = /*productType.ValueEng*/ "TPL";
                acigTPLQuoteCommand.PolicyEffectiveDate = DateTime.Now.AddDays(1).ToString();

                //Customer OR InsuredInfo
                acigTPLQuoteCommand.InsuredInfo.IdTypeCode = int.Parse(cardIdType.ValueEng) /*2*/;
                acigTPLQuoteCommand.InsuredInfo.IdNo = tempCustomerResponse.Data.NIN /*"2065564035"*/;
                acigTPLQuoteCommand.InsuredInfo.NameEng = tempCustomerResponse.Data.EnglishFirstName + " " + tempCustomerResponse.Data.EnglishMiddleName + "" + tempCustomerResponse.Data.EnglishLastName /*"Ameen Al rafie"*/;
                acigTPLQuoteCommand.InsuredInfo.NameAr = "أمين الرافعي";
                acigTPLQuoteCommand.InsuredInfo.IdExpiryDate = "01-1442";
                acigTPLQuoteCommand.InsuredInfo.IdRegistrationCityCode = "7";
                acigTPLQuoteCommand.InsuredInfo.BirthDateG = tempCustomerResponse.Data.DateOfBirth.ToString() /*"01-01-1983"*/;
                acigTPLQuoteCommand.InsuredInfo.BirthDateH = "01-01-1420";
                acigTPLQuoteCommand.InsuredInfo.GenderCode = /*int.Parse(gender.ValueEng)*/2;
                acigTPLQuoteCommand.InsuredInfo.MaritalStatusCode = int.Parse(maritalStatus.ValueEng) /*2*/;
                acigTPLQuoteCommand.InsuredInfo.OccupationCode = int.Parse(occupation.ValueEng) /*1*/;
                acigTPLQuoteCommand.InsuredInfo.EducationCode = int.Parse(education.ValueEng) /*1*/;
                acigTPLQuoteCommand.InsuredInfo.NationalityCode = int.Parse(nationality.ValueEng) /*90*/;
                acigTPLQuoteCommand.InsuredInfo.ChildrenBelow16 = 0;
                acigTPLQuoteCommand.InsuredInfo.MobileNo = tempCustomerResponse.Data.Mobile /*"580235141"*/;
                acigTPLQuoteCommand.InsuredInfo.EmailId = tempCustomerResponse.Data.Email /*"gajula.suresh@amtpl.com"*/;
                acigTPLQuoteCommand.InsuredInfo.NcdYears = nCDEligibilityResponse.ncdFreeYears /*int.Parse(ncdFreeYear.ValueEng)*/ /*5*/;
                acigTPLQuoteCommand.InsuredInfo.NcdReference = nCDEligibilityResponse.ncdReference /*"NCD12589"*/;
                acigTPLQuoteCommand.InsuredInfo.NoOfAccidents = 0;
                acigTPLQuoteCommand.InsuredInfo.AccidentsLiability = 0;
                acigTPLQuoteCommand.InsuredInfo.IsTransferOfOwnership = false;
                acigTPLQuoteCommand.InsuredInfo.OwnerId = null;

                //Address
                acigTPLQuoteCommand.InsuredInfo.Address.Street = "Makkah";
                acigTPLQuoteCommand.InsuredInfo.Address.District = "Jeddah";
                acigTPLQuoteCommand.InsuredInfo.Address.City = city.Description/*"Riyadh"*/;
                acigTPLQuoteCommand.InsuredInfo.Address.CityCode = int.Parse(city.ValueEng)/*34330*/;
                acigTPLQuoteCommand.InsuredInfo.Address.PostalCode = 58266;
                acigTPLQuoteCommand.InsuredInfo.Address.BuildingNumber = 2569;
                acigTPLQuoteCommand.InsuredInfo.Address.AdditionalNumber = 5269;
                acigTPLQuoteCommand.InsuredInfo.Address.UnitNumber = 1;
                acigTPLQuoteCommand.InsuredInfo.Address.LanguageCode = null;

                //AccidentDetails
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails = new WazenPolicy.Application.Features.ACIG.Command.ACIGTPLQuote.AccidentDetail();
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.accidentDate = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.carModel = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.carType = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.caseNumber = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.causeOfAccident = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.cityName = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.damageParts = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.driverAge = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.driverIdNumber = null;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.estimatedAmount = 0.0M;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.liability = 0;
                acigTPLQuoteCommand.InsuredInfo.AccidentDetails.sequenceNumber = tempVehicleResponse.Data.SequenceNumber /*null*/;

                //VehicleInformation
                acigTPLQuoteCommand.VehicleInfo.VehicleIdTypeCode = int.Parse(vehicleIdType.ValueEng)/*1*/;
                acigTPLQuoteCommand.VehicleInfo.RepairTypeCode = int.Parse(repairType.ValueEng) /*2*/;
                acigTPLQuoteCommand.VehicleInfo.BodyTypeCode = 0;
                acigTPLQuoteCommand.VehicleInfo.ChassisNumber = "MALC741B0LM177285";
                acigTPLQuoteCommand.VehicleInfo.ColorCode = int.Parse(vehicleColor.ValueEng) /*1*/;
                acigTPLQuoteCommand.VehicleInfo.ColorDesc = vehicleColor.Description /*"White"*/;
                acigTPLQuoteCommand.VehicleInfo.SequenceNumber = tempVehicleResponse.Data.SequenceNumber /*"256968468"*/;
                acigTPLQuoteCommand.VehicleInfo.CustomNumber = tempVehicleResponse.Data.SequenceNumberCustomID /*null*/;
                acigTPLQuoteCommand.VehicleInfo.Cylinders = 0;
                acigTPLQuoteCommand.VehicleInfo.DrivingCityCode = int.Parse(city.ValueEng) /*0*/;
                acigTPLQuoteCommand.VehicleInfo.EngineSize = null;
                acigTPLQuoteCommand.VehicleInfo.ExpectedAnnualMileage = /*int.Parse(mileage.ValueEng)*/ 0;
                acigTPLQuoteCommand.VehicleInfo.VehicleValue = 52565;
                acigTPLQuoteCommand.VehicleInfo.MakeCode = "11";
                acigTPLQuoteCommand.VehicleInfo.MakeCodeELM = "11";
                acigTPLQuoteCommand.VehicleInfo.MakeDesc = tempVehicleResponse.Data.VehicleMake /*"Toyota"*/;
                acigTPLQuoteCommand.VehicleInfo.ModelCode = "45";
                acigTPLQuoteCommand.VehicleInfo.ModelCodeELM = "45";
                acigTPLQuoteCommand.VehicleInfo.ModelDesc = tempVehicleResponse.Data.VehicleModel /*"Fortuner"*/;
                acigTPLQuoteCommand.VehicleInfo.ManufactureYear = tempVehicleResponse.Data.YearofManufacture /*"2015"*/;
                acigTPLQuoteCommand.VehicleInfo.PlateTypeCode = vehiclePlateType.ValueEng /*"1"*/;
                acigTPLQuoteCommand.VehicleInfo.PlateNumber = "8296";
                acigTPLQuoteCommand.VehicleInfo.FirstPlateLetter = tempVehicleResponse.Data.FirstPlateLetter /*"ص"*/;
                acigTPLQuoteCommand.VehicleInfo.SecondPlateLetter = "ل";
                acigTPLQuoteCommand.VehicleInfo.ThirdPlateLetter = "ك";
                acigTPLQuoteCommand.VehicleInfo.NightParkingCode = int.Parse(parkingLocation.ValueEng) /*1*/;
                acigTPLQuoteCommand.VehicleInfo.RegistrationCityCode = "7";
                acigTPLQuoteCommand.VehicleInfo.RegistrationExpiryDate = "11-01-1445";
                acigTPLQuoteCommand.VehicleInfo.SeatsCapacity = 0;
                acigTPLQuoteCommand.VehicleInfo.TransmissionTypeCode = int.Parse(transmissionType.ValueEng) /*1*/;
                acigTPLQuoteCommand.VehicleInfo.UsagePurposeCode = int.Parse(vehicleUses.ValueEng)/*1*/;
                acigTPLQuoteCommand.VehicleInfo.Weight = 0;
                acigTPLQuoteCommand.VehicleInfo.Automatic_Braking_System = 2;
                acigTPLQuoteCommand.VehicleInfo.Cruise_Control = 2;
                acigTPLQuoteCommand.VehicleInfo.Adaptive_Cruise_Control = 2;
                acigTPLQuoteCommand.VehicleInfo.Rear_Parking_Sensors = 2;
                acigTPLQuoteCommand.VehicleInfo.Front_Sensors = 2;
                acigTPLQuoteCommand.VehicleInfo.Front_Camera = 2;
                acigTPLQuoteCommand.VehicleInfo.Rear_Camera = 2;
                acigTPLQuoteCommand.VehicleInfo.Degree_Camera_360 = 2;
                acigTPLQuoteCommand.VehicleInfo.Fire_Extinguisher = 2;
                acigTPLQuoteCommand.VehicleInfo.Modifications_In_The_car = 1;
                acigTPLQuoteCommand.VehicleInfo.Modifications_In_The_Car_Desc = "vehicle";
                acigTPLQuoteCommand.VehicleInfo.Vehicle_Axle_Weight = /*int.Parse(vehicleAxlesWeight.ValueEng)*/ null;
                acigTPLQuoteCommand.VehicleInfo.Antilock_Braking_System = 2;

                //Driver Information
                acigTPLQuoteCommand.DriverInfo[0].IsPolicyHolder = true;
                acigTPLQuoteCommand.DriverInfo[0].IsMaindriver = tempDriverResponse.Data.IsMainDriver /*true*/;
                acigTPLQuoteCommand.DriverInfo[0].IdTypeCode = int.Parse(cardIdType.ValueEng) /*1*/;
                acigTPLQuoteCommand.DriverInfo[0].IdNo = "1569854789";
                acigTPLQuoteCommand.DriverInfo[0].NameEng = tempDriverResponse.Data.DriverName /*"Salman bin Nasser bin Hussein Al Sultan"*/;
                acigTPLQuoteCommand.DriverInfo[0].NameAr = "سلمان بن ناصر بن حسين السلطان";
                acigTPLQuoteCommand.DriverInfo[0].BirthDateG = tempDriverResponse.Data.DateOfBirth.ToString() /*null*/;
                acigTPLQuoteCommand.DriverInfo[0].BirthDateH = "01-14-1420";
                acigTPLQuoteCommand.DriverInfo[0].DriverAge = 0;
                acigTPLQuoteCommand.DriverInfo[0].GenderCode = int.Parse(gender.ValueEng) /*1*/;
                acigTPLQuoteCommand.DriverInfo[0].MaritalStatusCode = int.Parse(maritalStatus.ValueEng) /*1*/;
                acigTPLQuoteCommand.DriverInfo[0].OccupationCode = int.Parse(occupation.ValueEng) /*1*/;
                acigTPLQuoteCommand.DriverInfo[0].EducationCode = int.Parse(education.ValueEng) /*1*/;
                acigTPLQuoteCommand.DriverInfo[0].NationalityCode = int.Parse(nationality.ValueEng) /*90*/;
                acigTPLQuoteCommand.DriverInfo[0].ChildrenBelow16 = int.Parse(tempDriverResponse.Data.ChildrenBelow16) /*0*/;
                acigTPLQuoteCommand.DriverInfo[0].RelationWithInsuredCode = 1;
                acigTPLQuoteCommand.DriverInfo[0].HealthConditionsCode = int.Parse(healthCondition.ValueEng) /*1*/;
                acigTPLQuoteCommand.DriverInfo[0].MobileNo = null;
                acigTPLQuoteCommand.DriverInfo[0].EmailId = null;
                acigTPLQuoteCommand.DriverInfo[0].LicenseTypeCode = int.Parse(licenseType.ValueEng) /*0*/;
                acigTPLQuoteCommand.DriverInfo[0].LicenseExpiryDate = "01-01-1442";
                acigTPLQuoteCommand.DriverInfo[0].DrivingExpYears = 5;
                acigTPLQuoteCommand.DriverInfo[0].NoOfYearsSaudiLicenseHeld = 8;
                acigTPLQuoteCommand.DriverInfo[0].NcdYears = nCDEligibilityResponse.ncdFreeYears /*int.Parse(ncdFreeYear.ValueEng)*/ /*0*/;
                acigTPLQuoteCommand.DriverInfo[0].NcdReference = nCDEligibilityResponse.ncdReference /*null*/;
                acigTPLQuoteCommand.DriverInfo[0].VehicleUsagePercentage = int.Parse(tempVehicleResponse.Data.VehicleUsagePercentage) /*100*/;
                acigTPLQuoteCommand.DriverInfo[0].WorkCompanyName = tempDriverResponse.Data.WorkCompanyName /*null*/;
                acigTPLQuoteCommand.DriverInfo[0].TrafficViolationsCode = int.Parse(violation.ValueEng) /*null*/;
                acigTPLQuoteCommand.DriverInfo[0].CityCode = int.Parse(city.ValueEng) /*null*/;
                acigTPLQuoteCommand.DriverInfo[0].HomeAddress = null;
                acigTPLQuoteCommand.DriverInfo[0].OfficeAddress = null;
                acigTPLQuoteCommand.DriverInfo[0].CountriesDrivingLicense[0].LicenseCountryCode = int.Parse(country.ValueEng)/*167*/;
                acigTPLQuoteCommand.DriverInfo[0].CountriesDrivingLicense[0].LicenseYears = 8;
                acigTPLQuoteCommand.DriverInfo[0].CountriesDrivingLicense[1].LicenseCountryCode = int.Parse(country.ValueEng) /*167*/;
                acigTPLQuoteCommand.DriverInfo[0].CountriesDrivingLicense[1].LicenseYears = 25;
                #endregion End of ACIGTPL Command Request

                var actualResponseTPLACIG = await _mediator.Send(acigTPLQuoteCommand);
                if (actualResponseTPLACIG.Data == null)
                {
                    goto Walaa;
                }
                else
                {
                    if (actualResponseTPLACIG.Data.Errors != null)
                    {
                        if (actualResponseTPLACIG.Data.Errors.Count >= 1)
                        {
                            _logger.LogInformation(actualResponseTPLACIG.Data.Errors.ToList().ToString());
                            goto Walaa;
                        }
                    }
                }

                var additionalTPLCoverList = new List<WazenPolicy.Application.Features.ACIG.Command.ACIGTPLQuote.AdditionalCover>();

                for (int i = 0; i < actualResponseTPLACIG.Data.Quote.Count; i++)
                {
                    if (actualResponseTPLACIG.Data.Quote[i].AdditionalCovers != null)
                    {
                        for (int j = 0; j < actualResponseTPLACIG.Data.Quote[i].AdditionalCovers.Count; j++)
                        {
                            additionalTPLCoverList.Add(actualResponseTPLACIG.Data.Quote[i].AdditionalCovers[j]);
                        }
                    }
                }

                var premiumBreakdownList = new List<PremiumBreakdown>();

                for (int i = 0; i < actualResponseTPLACIG.Data.Quote.Count; i++)
                {
                    if (actualResponseTPLACIG.Data.Quote[i].PremiumDetails != null)
                    {
                        for (int j = 0; j < actualResponseTPLACIG.Data.Quote[i].PremiumDetails.Count; j++)
                        {
                            if (actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown != null)
                            {
                                for (int k = 0; k < actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown.Count; k++)
                                {
                                    var premiumBreakdownDetail = new PremiumBreakdown()
                                    {
                                        TypeCode = actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown[k].TypeCode.ToString(),
                                        Amount = Double.Parse(actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown[k].Amount.ToString()),
                                        Percentage = Double.Parse(actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown[k].Percentage.ToString())
                                    };
                                    premiumBreakdownList.Add(premiumBreakdownDetail);
                                }
                            }
                        }
                    }
                }

                var discountBreakdownList = new List<DiscountBreakdown>();
                for (int i = 0; i < actualResponseTPLACIG.Data.Quote.Count; i++)
                {
                    if (actualResponseTPLACIG.Data.Quote[i].PremiumDetails != null)
                    {
                        for (int j = 0; j < actualResponseTPLACIG.Data.Quote[i].PremiumDetails.Count; j++)
                        {
                            if (actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown != null)
                            {
                                for (int k = 0; k < actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown.Count; k++)
                                {
                                    var discountBreakdownDetail = new DiscountBreakdown()
                                    {
                                        TypeCode = actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown[k].TypeCode.ToString(),
                                        Amount = Double.Parse(actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown[k].Amount.ToString()),
                                        Percentage = Double.Parse(actualResponseTPLACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown[k].Percentage.ToString())
                                    };
                                    discountBreakdownList.Add(discountBreakdownDetail);
                                }
                            }
                        }
                    }
                }

                var additionalCoversList = new List<AdditionalCovers>();

                for (int i = 0; i < additionalTPLCoverList.Count; i++)
                {
                    var addCover = new AdditionalCovers()
                    {
                        FeatureCode = additionalTPLCoverList[i].FeatureCode,
                        FeatureDesc = additionalTPLCoverList[i].FeatureDesc,
                        FeatureAmount = additionalTPLCoverList[i].FeatureAmount,
                        TaxAmount = additionalTPLCoverList[i].TaxAmount
                    };

                    additionalCoversList.Add(addCover);
                }

                var premiumDetailss = new List<PremiumDetails>();
                for (int i = 0; i < actualResponseTPLACIG.Data.Quote[0].PremiumDetails.Count; i++)
                {
                    var premiumDetail = new PremiumDetails()
                    {
                        deductable = actualResponseTPLACIG.Data.Quote[i].PremiumDetails[i].Deductable,
                        GrossPremium = 0.0,
                        TotalDiscount = 0.0,
                        PremiumExcVat = 0.0,
                        TotalTax = 0.0,
                        TotalPremium = Double.Parse(actualResponseTPLACIG.Data.Quote[i].PremiumDetails[i].TotalPremium.ToString()),
                        premiumBreakdown = premiumBreakdownList,
                        discountBreakdowns = discountBreakdownList,
                        additionalCovers = additionalCoversList,
                    };
                    premiumDetailss.Add(premiumDetail);
                }

                var quoteTPL_ACIG = new Quote();
                quoteTPL_ACIG.ICID = insuranceCompanies.Data[0].Id;
                quoteTPL_ACIG.vehicleId = request.VehicleID;
                quoteTPL_ACIG.QuoteRequestRefNo = actualResponseTPLACIG.Data.QuoteRequestRefNo;
                quoteTPL_ACIG.QuotationNo = actualResponseTPLACIG.Data.Quote[0].QuotationNo;
                quoteTPL_ACIG.product = "TPL";
                quoteTPL_ACIG.companyName = insuranceCompanies.Data[0].InsuranceCompanyName; //"ACIG";
                quoteTPL_ACIG.premiumDetails = premiumDetailss;
                listQuotes.Quote.Add(quoteTPL_ACIG);

            #endregion End of call to ACIG
            //TPL ACIG Ends
            #endregion TPL ACIG

                #region TPL Walaa
                //TPL Walaa Starts
                Walaa:
                    ICID = insuranceCompanies.Data[1].Id; //a5e6d869-1aee-4208-9cb1-8871bdeb17c3
                    //ICID = Guid.Parse("F6C16294-A259-442C-B343-F526BC9DD8CD");//insuranceCompanies.Data[1].Id;

                    _logger.LogInformation("Retrieving matching record from Lists by Passing Value and Walaa ICID Initiated");
                    addCovers = additionalCoverList.FirstOrDefault<ICAdditionalCoverr>(x => x.Description == "Road Side Assistance" && x.ICID == ICID);
                    bankCode = bankCodeList.FirstOrDefault<ICBankCode>(x => x.Description == "National Bank of Kuwait" && x.ICID == ICID);
                    cardIdType = cardIdTypeList.FirstOrDefault<ICCardIdType>(x => x.Description == "Resident" && x.ICID == ICID);
                    city = citiesList.FirstOrDefault<ICCities>(x => x.Description == "AL-KHATHAM" && x.ICID == ICID);
                    country = countriesList.FirstOrDefault<ICCountries>(x => x.Description == "Armenia" && x.ICID == ICID);
                    deductable = deductableList.FirstOrDefault<ICDeductable>(x => x.Description == "0,5000,7500,10000,25000,50000" && x.ICID == ICID);
                    discount = discountList.FirstOrDefault<ICDiscount>(x => x.Description == "NCD Discount" && x.ICID == ICID);
                    driverType = driverTypeList.FirstOrDefault<ICDriverType>(x => x.Description == "Main Driver" && x.ICID == ICID);
                    drivingPercent = drivingPercentageList.FirstOrDefault<ICDrivingPercentage>(x => x.Description == "1" && x.ICID == ICID);
                    education = educationList.FirstOrDefault<ICEducation>(x => x.Description == "High Education" && x.ICID == ICID);
                    gender = genderList.FirstOrDefault<ICGender>(x => x.Description == "Male" && x.ICID == ICID);
                    healthCondition = healthConditionList.FirstOrDefault<ICHealthCondition>(x => x.Description == "No Restriction" && x.ICID == ICID);
                    imageTitle = imageTitleList.FirstOrDefault<ICImageTitle>(x => x.Description == "Image Front" && x.ICID == ICID);
                    licenseType = licenseTypeList.FirstOrDefault<ICLicenseType>(x => x.Description == "TEMPORARY LICENSE (PERMISSION)" && x.ICID == ICID);
                    maritalStatus = maritalStatusList.FirstOrDefault<ICMaritalStatus>(x => x.Description == "Single Male" && x.ICID == ICID);
                    mileage = mileageList.FirstOrDefault<ICMileages>(x => x.Description == "20000-30000" && x.ICID == ICID);
                    nationality = nationalitiesList.FirstOrDefault<ICNationality>(x => x.Description == "Mauritius" && x.ICID == ICID);
                    ncdFreeYear = nCDFreeYearList.FirstOrDefault<ICNCDFreeYear>(x => x.Description == "‘1’ Claim in Year 1 (Applicable next year)" && x.ICID == ICID);
                    occupation = occupationList.FirstOrDefault<ICOccupation>(x => x.Description == "Employee" && x.ICID == ICID);
                    parkingLocation = parkingLocationList.FirstOrDefault<ICParkingLocation>(x => x.Description == "Road-Side" && x.ICID == ICID);
                    paymentMethod = paymentMethodList.FirstOrDefault<ICPaymentMethod>(x => x.Description == "MASTER" && x.ICID == ICID);
                    plateLetter = plateLetterList.FirstOrDefault<ICPlateLetter>(x => x.Description == "U" && x.ICID == ICID);
                    premium = premiumBreakList.FirstOrDefault<ICPremiumBreakdownn>(x => x.Description == "Basic Cover " && x.ICID == ICID);
                    priceType = priceTypeList.FirstOrDefault<ICPriceType>(x => x.Description == "No Claim Discount" && x.ICID == ICID);
                    productType = productTypeList.FirstOrDefault<ICProductType>(x => x.Description == "Third-Party Vehicle Insurance" && x.ICID == ICID);
                    relationship = relationshipList.FirstOrDefault<ICRelationship>(x => x.Description == "None" && x.ICID == ICID);
                    repairType = repairTypeList.FirstOrDefault<ICRepairType>(x => x.Description == "Workshop" && x.ICID == ICID);
                    transmissionType = transmissionTypeList.FirstOrDefault<ICTransmissionType>(x => x.Description == "Manual" && x.ICID == ICID);
                    vehicleAxlesWeight = vehicleAxlesWeightList.FirstOrDefault<ICVehicleAxlesWeight>(x => x.Description == "Up Tp 20 Tons" && x.ICID == ICID);
                    vehicleColor = vehicleColorList.FirstOrDefault<ICVehicleColor>(x => x.Description == "Black" && x.ICID == ICID);
                    vehicleEngineSize = vehicleEngineSizeList.FirstOrDefault<ICVehicleEngineSize>(x => x.Description == "Up To 2,000 CC" && x.ICID == ICID);
                    vehicleIdType = vehicleIdTypeList.FirstOrDefault<ICVehicleIdType>(x => x.Description == "Sequence Number" && x.ICID == ICID);
                    vehiclePlateType = vehiclePlateTypeList.FirstOrDefault<ICVehiclePlateType>(x => x.Description == "Private Car" && x.ICID == ICID);
                    vehicleSpecification = vehicleSpecificationList.FirstOrDefault<ICVehicleSpecificationn>(x => x.Description == "ANTI THEFT ALARM" && x.ICID == ICID);
                    vehicleUses = vehicleUsesList.FirstOrDefault<ICVehicleUses>(x => x.Description == "Private" && x.ICID == ICID);
                    violation = violationList.FirstOrDefault<ICViolation>(x => x.Description == "Speed Ticket" && x.ICID == ICID);
                    _logger.LogInformation("Retrieving matching record from Lists by Passing Value and Walaa ICID Completed");

                    WalaaTPLQuoteCommand walaaTPLRequest = new WalaaTPLQuoteCommand();
                    #region Adding Lookup values into WalaaTPL Command Request

                    walaaTPLRequest.ProviderCompanyCode = "25";
                    walaaTPLRequest.ProviderCompanyName = "WZAN Broker";
                    walaaTPLRequest.ReferenceId = "12453";
                    walaaTPLRequest.ProductTypeCode = 1;
                    walaaTPLRequest.PolicyEffectiveDate = DateTime.Now.AddDays(1);
                    walaaTPLRequest.PostCode = "13318";

                    //InsuredInfo
                    walaaTPLRequest.InsuredIdTypeCode = 1;
                    walaaTPLRequest.InsuredId = 1026055705;
                    walaaTPLRequest.InsuredBirthDateH = "15-04-1394";
                    walaaTPLRequest.InsuredBirthDateG = "07-05-1994" /*tempCustomerResponse.Data.DateOfBirth.ToString()*/ /*"07-05-1994"*/;
                    walaaTPLRequest.InsuredGenderCode = "M";
                    walaaTPLRequest.InsuredNationalityCode = "113";
                    walaaTPLRequest.InsuredIdIssuePlaceCode = "1";
                    walaaTPLRequest.InsuredIdIssuePlace = "";
                    walaaTPLRequest.InsuredFirstNameAr = "سيش";
                    walaaTPLRequest.InsuredMiddleNameAr = "";
                    walaaTPLRequest.InsuredLastNameAr = "سيلادوراي";
                    walaaTPLRequest.InsuredFirstNameEn = tempCustomerResponse.Data.EnglishFirstName /*"SUHESH"*/;
                    walaaTPLRequest.InsuredMiddleNameEn = tempCustomerResponse.Data.EnglishMiddleName /*""*/;
                    walaaTPLRequest.InsuredLastNameEn = tempCustomerResponse.Data.EnglishLastName /*"SELLADURAI"*/;
                    walaaTPLRequest.InsuredSocialStatusCode = maritalStatus.ValueEng /*"2"*/;
                    walaaTPLRequest.InsuredOccupationCode = "G";
                    walaaTPLRequest.InsuredOccupation = "قطاع حكومي";
                    walaaTPLRequest.InsuredEducationCode = int.Parse(education.ValueEng) /*5*/;
                    walaaTPLRequest.InsuredChildrenBelow16Years = 0;
                    walaaTPLRequest.InsuredWorkCityCode = "1";
                    walaaTPLRequest.InsuredWorkCity = "الرياض";
                    walaaTPLRequest.InsuredCityCode = "1";
                    walaaTPLRequest.InsuredCity = "الرياض";

                    //Vehicle
                    walaaTPLRequest.VehicleIdTypeCode = 1;
                    walaaTPLRequest.VehicleId = 535634510;
                    walaaTPLRequest.VehiclePlateNumber = 3037;
                    walaaTPLRequest.VehiclePlateText1 = "ر";
                    walaaTPLRequest.VehiclePlateText2 = "ي";
                    walaaTPLRequest.VehiclePlateText3 = "ح";
                    walaaTPLRequest.VehicleChassisNumber = "2FMGK5B82FBA12551";
                    walaaTPLRequest.VehicleOwnerName = "فهد عبدالعزيز محمد  الداود";
                    walaaTPLRequest.VehicleOwnerId = 1026055705;
                    walaaTPLRequest.VehiclePlateTypeCode = vehiclePlateType.ValueEng /*"1"*/;
                    walaaTPLRequest.VehicleModelYear = int.Parse(tempVehicleResponse.Data.YearofManufacture) /*2015*/;
                    walaaTPLRequest.VehicleModelCode = "55";
                    walaaTPLRequest.VehicleModel = "فليكس";
                    walaaTPLRequest.VehicleMakerCode = "21";
                    walaaTPLRequest.VehicleMaker = "فورد";
                    walaaTPLRequest.VehicleMajorColorCode = vehicleColor.ValueEng /*"2"*/;
                    walaaTPLRequest.VehicleMajorColor = "أسود";
                    walaaTPLRequest.VehicleBodyTypeCode = "5";
                    walaaTPLRequest.VehicleRegPlaceCode = "1";
                    walaaTPLRequest.VehicleRegPlace = "الرياض";
                    walaaTPLRequest.VehicleRegExpiryDate = "09-10-1443";
                    walaaTPLRequest.VehicleCylinders = 6;
                    walaaTPLRequest.VehicleWeight = 2248;
                    walaaTPLRequest.VehicleLoad = 7;
                    walaaTPLRequest.VehicleOwnerTransfer = false;
                    walaaTPLRequest.VehicleValue = 50000;
                    walaaTPLRequest.DeductibleValue = null;
                    walaaTPLRequest.VehicleAgencyRepair = false;
                    walaaTPLRequest.VehicleEngineSizeCode = int.Parse(vehicleEngineSize.ValueEng) /*0*/;
                    walaaTPLRequest.VehicleUseCode = int.Parse(vehicleUses.ValueEng) /*1*/;
                    walaaTPLRequest.VehicleMileage = int.Parse(mileage.ValueEng) /*0*/;
                    walaaTPLRequest.VehicleTransmissionTypeCode = int.Parse(transmissionType.ValueEng) /*2*/;
                    walaaTPLRequest.VehicleMileageExpectedAnnualCode = 1;
                    walaaTPLRequest.VehicleAxleWeightCode = 0;
                    walaaTPLRequest.Accidents = null;
                    walaaTPLRequest.VehicleOvernightParkingLocationCode = int.Parse(parkingLocation.ValueEng) /*1*/;
                    walaaTPLRequest.VehicleModificationDetails = "";
                    walaaTPLRequest.NCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*11*/;
                    walaaTPLRequest.NCDReference = nCDEligibilityResponse.ncdReference/*"NCD1102217343"*/;

                    //Drivers
                    walaaTPLRequest.Drivers = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.Driver>();
                    var driver = new WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.Driver()
                    {
                        DriverTypeCode = 1,
                        DriverId = 1026055705,
                        DriverIdTypeCode = 1,
                        DriverNationalityCode = "113",
                        DriverGenderCode = "M",
                        DriverBirthDateH = "15-04-1394",
                        DriverBirthDateG = tempDriverResponse.Data.DateOfBirth.ToString("yyyy-MM-dd") /*"1974-05-07"*/,
                        DriverFirstNameAr = "فهد",
                        DriverMiddleNameAr = "عبدالعزيز",
                        DriverLastNameAr = "محمد الداود",
                        DriverFirstNameEn = tempDriverResponse.Data.DriverName /*"FAHAD"*/,
                        DriverMiddleNameEn = "ABDULAZIZ",
                        DriverLastNameEn = "MOHAMMED ALDAWOOD",
                        DriverSocialStatusCode = "2",
                        DriverOccupationCode = "G",
                        DriverOccupation = "قطاع حكومي",
                        DriverDrivingPercentage = int.Parse(drivingPercent.ValueEng) /*100*/,
                        DriverEducationCode = int.Parse(education.ValueEng) /*5*/,
                        DriverMedicalConditionCode = int.Parse(healthCondition.ValueEng) /*1*/,
                        DriverChildrenBelow16Years = 0,
                        DriverHomeCityCode = "1",
                        DriverHomeCity = "الرياض",
                        DriverWorkCityCode = "1",
                        DriverWorkCity = "الرياض",
                        DriverNCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*11*/,
                        DriverNCDReference = nCDEligibilityResponse.ncdReference /*"NCD1102217343"*/,
                        DriverRelationship = int.Parse(relationship.ValueEng) /*0*/,
                        DriverLicenses = null,
                        DriverViolations = null,
                        Accidents = null
                    };

                    //Driver Licenses
                    driver.DriverLicenses = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.DriverLicense>();

                    var driverLicenses = new WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.DriverLicense()
                    {
                        LicenseCountryCode = 113,
                        LicenseNumberYears = 2,
                        DriverLicenseTypeCode = "3",
                        DriverLicenseExpiryDate = "01-01-1449"
                    };
                    driver.DriverLicenses.Add(driverLicenses);

                    //Driver Violation
                    driver.DriverViolations = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.DriverViolation>();

                    var driverVi1 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.DriverViolation()
                    {
                        ViolationCode = "27"
                    };
                    //driver.DriverViolations.Add(driverVi1);
                    var driverVi2 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.DriverViolation()
                    {
                        ViolationCode = "28"
                    };
                    //driver.DriverViolations.Add(driverVi2);
                    var driverVi3 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.DriverViolation()
                    {
                        ViolationCode = "29"
                    };
                    //driver.DriverViolations.Add(driverVi3);

                    //Accidents
                    //driver.Accidents = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.Accident>();

                    var accidents = new WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.Accident()
                    {
                        CaseNumber = null,
                        AccidentDate = DateTime.Now,
                        Liability = 0
                    };
                    //driver.Accidents.Add(accidents);

                    walaaTPLRequest.Drivers.Add(driver);

                    walaaTPLRequest.Drivers[0].DriverViolations.Add(driverVi1);
                    walaaTPLRequest.Drivers[0].DriverViolations.Add(driverVi2);
                    walaaTPLRequest.Drivers[0].DriverViolations.Add(driverVi3);

                    //Vehicle Specifications
                    walaaTPLRequest.VehicleSpecifications = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.VehicleSpecification>();
                    var vehicleSpecifications1 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.VehicleSpecification()
                    {
                        VehicleSpecificationCode = 1.ToString()
                    };
                    walaaTPLRequest.VehicleSpecifications.Add(vehicleSpecifications1);
                    var vehicleSpecifications2 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote.VehicleSpecification()
                    {
                        VehicleSpecificationCode = 2.ToString()
                    };
                    walaaTPLRequest.VehicleSpecifications.Add(vehicleSpecifications2);

                    #endregion End of WalaaTPL Command Request
                    //walaaTPLRequest.Drivers[0].DriverViolations.Add(driverVi1);
                    //walaaTPLRequest.Drivers[0].DriverViolations.Add(driverVi2);
                    //walaaTPLRequest.Drivers[0].DriverViolations.Add(driverVi3);

                    var responseTPL = await _mediator.Send(walaaTPLRequest);
                    if (responseTPL.Data == null)
                    {
                        goto Malath;
                    }
                    else
                    {
                        if (responseTPL.Data.Errors != null)
                        {
                            if (responseTPL.Data.Errors.Count >= 1)
                            {
                                _logger.LogInformation(responseTPL.Data.Errors.ToList().ToString());
                                goto Malath;
                            }
                        }
                    }


                    Quote quoteTPL_Walaa = new Quote();

                    List<AdditionalCovers> additionalCovers = new List<AdditionalCovers>();
                    for (int i = 0; i < responseTPL.Data.Products.Count; i++)
                    {
                        for (int j = 0; j < responseTPL.Data.Products[i].Benefits.Count; j++)
                        {
                            var additionalCover = new AdditionalCovers()
                            {
                                FeatureCode = responseTPL.Data.Products[i].Benefits[j].BenefitCode,
                                FeatureDesc = responseTPL.Data.Products[i].Benefits[j].BenefitDescEn,
                                FeatureAmount = responseTPL.Data.Products[i].Benefits[j].BenefitPrice,
                                TaxAmount = 0.0
                            };
                            additionalCovers.Add(additionalCover);
                        }
                    }

                    List<PremiumBreakdown> premiumBreakdown = new List<PremiumBreakdown>();

                    for (int i = 0; i < responseTPL.Data.Products.Count; i++)
                    {
                        for (int j = 0; j < responseTPL.Data.Products[i].PriceDetails.Count; j++)
                        {
                            var premiumBreakdownDetail = new PremiumBreakdown()
                            {
                                TypeCode = responseTPL.Data.Products[i].PriceDetails[j].PriceTypeCode.ToString(),
                                Amount = Double.Parse(responseTPL.Data.Products[i].PriceDetails[j].PriceValue),
                                Percentage = Double.Parse(responseTPL.Data.Products[i].PriceDetails[j].PercentageValue)
                            };
                            premiumBreakdown.Add(premiumBreakdownDetail);
                        }
                    }

                    List<DiscountBreakdown> discountBreakdowns = new List<DiscountBreakdown>();

                    List<PremiumDetails> premiumDetails = new List<PremiumDetails>();

                    for (int i = 0; i < responseTPL.Data.Products.Count; i++)
                    {
                        for (int j = 0; j < responseTPL.Data.Products[i].PriceDetails.Count; j++)
                        {
                            var premiumDetail = new PremiumDetails()
                            {
                                deductable = 0,
                                GrossPremium = 0.0,
                                TotalDiscount = 0.0,
                                PremiumExcVat = 0.0,
                                TotalTax = 0.0,
                                TotalPremium = Double.Parse(responseTPL.Data.Products[i].ProductPrice),
                                additionalCovers = additionalCovers,
                                premiumBreakdown = premiumBreakdown,
                                discountBreakdowns = discountBreakdowns
                            };
                            premiumDetails.Add(premiumDetail);
                        }
                    }

                    quoteTPL_Walaa.ICID = insuranceCompanies.Data[1].Id;
                    quoteTPL_Walaa.vehicleId = request.VehicleID;
                    quoteTPL_Walaa.QuoteRequestRefNo = responseTPL.Data.ReferenceId;
                    quoteTPL_Walaa.QuotationNo = responseTPL.Data.QuotationNo;
                    quoteTPL_Walaa.product = "TPL";
                    quoteTPL_Walaa.companyName = insuranceCompanies.Data[1].InsuranceCompanyName; //"Walaa";
                    quoteTPL_Walaa.premiumDetails = premiumDetails;

                    listQuotes.Quote.Add(quoteTPL_Walaa);

                //TPL Walaa Ends
                #endregion TPL Walaa

                #region TPL Malath
                //TPL Malath Starts
                Malath:
                    ICID = insuranceCompanies.Data[2].Id;
                    //ICID = Guid.Parse("F6C16294-A259-442C-B343-F526BC9DD8CD");//insuranceCompanies.Data[2].Id;
                    _logger.LogInformation("Retrieving matching record from Lists by Passing Value and Malath ICID Initiated");
                    addCovers = additionalCoverList.FirstOrDefault<ICAdditionalCoverr>(x => x.Description == "Natural Perils" && x.ICID == ICID);
                    bankCode = bankCodeList.FirstOrDefault<ICBankCode>(x => x.Description == "National Bank of Kuwait" && x.ICID == ICID);
                    cardIdType = cardIdTypeList.FirstOrDefault<ICCardIdType>(x => x.Description == "Resident" && x.ICID == ICID);
                    city = citiesList.FirstOrDefault<ICCities>(x => x.Description == "HAWTAT BNEY TAMEEM" && x.ICID == ICID);
                    country = countriesList.FirstOrDefault<ICCountries>(x => x.Description == "KOREA (NORTH)" && x.ICID == ICID);
                    deductable = deductableList.FirstOrDefault<ICDeductable>(x => x.Description == "0,5000,7500,10000,25000,50000" && x.ICID == ICID);
                    discount = discountList.FirstOrDefault<ICDiscount>(x => x.Description == "Additional Age Contribution" && x.ICID == ICID);
                    driverType = driverTypeList.FirstOrDefault<ICDriverType>(x => x.Description == "Additional Driver" && x.ICID == ICID);
                    drivingPercent = drivingPercentageList.FirstOrDefault<ICDrivingPercentage>(x => x.Description == "0.5" && x.ICID == ICID);
                    education = educationList.FirstOrDefault<ICEducation>(x => x.Description == "High Education" && x.ICID == ICID);
                    gender = genderList.FirstOrDefault<ICGender>(x => x.Description == "Female" && x.ICID == ICID);
                    healthCondition = healthConditionList.FirstOrDefault<ICHealthCondition>(x => x.Description == "Driving Inside KSA Only" && x.ICID == ICID);
                    imageTitle = imageTitleList.FirstOrDefault<ICImageTitle>(x => x.Description == "Image Front" && x.ICID == ICID);
                    licenseType = licenseTypeList.FirstOrDefault<ICLicenseType>(x => x.Description == "LIGHT TRANSPORT" && x.ICID == ICID);
                    maritalStatus = maritalStatusList.FirstOrDefault<ICMaritalStatus>(x => x.Description == "Single Female" && x.ICID == ICID);
                    mileage = mileageList.FirstOrDefault<ICMileages>(x => x.Description == "80000-90000" && x.ICID == ICID);
                    nationality = nationalitiesList.FirstOrDefault<ICNationality>(x => x.Description == "South African" && x.ICID == ICID);
                    ncdFreeYear = nCDFreeYearList.FirstOrDefault<ICNCDFreeYear>(x => x.Description == "‘3’ Year Free Claim " && x.ICID == ICID);
                    occupation = occupationList.FirstOrDefault<ICOccupation>(x => x.Description == "Metal construction engineer" && x.ICID == ICID);
                    parkingLocation = parkingLocationList.FirstOrDefault<ICParkingLocation>(x => x.Description == "Garage" && x.ICID == ICID);
                    paymentMethod = paymentMethodList.FirstOrDefault<ICPaymentMethod>(x => x.Description == "MASTER" && x.ICID == ICID);
                    plateLetter = plateLetterList.FirstOrDefault<ICPlateLetter>(x => x.Description == "" && x.ICID == ICID);
                    premium = premiumBreakList.FirstOrDefault<ICPremiumBreakdownn>(x => x.Description == "Basic Cover " && x.ICID == ICID);
                    priceType = priceTypeList.FirstOrDefault<ICPriceType>(x => x.Description == "Image Right" && x.ICID == ICID);
                    productType = productTypeList.FirstOrDefault<ICProductType>(x => x.Description == "TPL" && x.ICID == ICID);
                    relationship = relationshipList.FirstOrDefault<ICRelationship>(x => x.Description == "Brother / Sister" && x.ICID == ICID);
                    repairType = repairTypeList.FirstOrDefault<ICRepairType>(x => x.Description == "Workshop" && x.ICID == ICID);
                    transmissionType = transmissionTypeList.FirstOrDefault<ICTransmissionType>(x => x.Description == "Manual Transmission" && x.ICID == ICID);
                    vehicleAxlesWeight = vehicleAxlesWeightList.FirstOrDefault<ICVehicleAxlesWeight>(x => x.Description == "Less than19999 Tons" && x.ICID == ICID);
                    vehicleColor = vehicleColorList.FirstOrDefault<ICVehicleColor>(x => x.Description == "Black" && x.ICID == ICID);
                    vehicleEngineSize = vehicleEngineSizeList.FirstOrDefault<ICVehicleEngineSize>(x => x.Description == "More than 4001CC" && x.ICID == ICID);
                    vehicleIdType = vehicleIdTypeList.FirstOrDefault<ICVehicleIdType>(x => x.Description == "Sequence" && x.ICID == ICID);
                    vehiclePlateType = vehiclePlateTypeList.FirstOrDefault<ICVehiclePlateType>(x => x.Description == "Public Bus" && x.ICID == ICID);
                    vehicleSpecification = vehicleSpecificationList.FirstOrDefault<ICVehicleSpecificationn>(x => x.Description == "FRONT SENSORS" && x.ICID == ICID);
                    vehicleUses = vehicleUsesList.FirstOrDefault<ICVehicleUses>(x => x.Description == "COMMERCIAL" && x.ICID == ICID);
                    violation = violationList.FirstOrDefault<ICViolation>(x => x.Description == "Infringing rules by using strong lights" && x.ICID == ICID);
                    _logger.LogInformation("Retrieving matching record from Lists by Passing Value and Malath ICID Completed");

                    MalathTPLQuoteCommand malathTPLRequest = new MalathTPLQuoteCommand();

                    malathTPLRequest.RequestReferenceNo = "";
                    malathTPLRequest.ProductTypeCode = 1;
                    malathTPLRequest.PolicyEffectiveDate = DateTime.Now.AddDays(1);
                    malathTPLRequest.InsuredIdTypeCode = 1;
                    malathTPLRequest.InsuredId = "1086517141";
                    malathTPLRequest.InsuredIDExpiryDate = DateTime.Now.AddYears(1);
                    malathTPLRequest.InsuredBirthDate = "01-01-1410";
                    malathTPLRequest.InsuredGenderCode = "M";
                    malathTPLRequest.InsuredNationalityCode = "90";
                    malathTPLRequest.InsuredFirstNameAr = "شهدي";
                    malathTPLRequest.InsuredMiddleNameAr = "محمد";
                    malathTPLRequest.InsuredLastNameAr = "الشيمي";
                    malathTPLRequest.InsuredFirstNameEn = "Shohdy";
                    malathTPLRequest.InsuredMiddleNameEn = "Mohamed";
                    malathTPLRequest.InsuredLastNameEn = "ElSheemy";
                    malathTPLRequest.InsuredSocialStatusCode = "2";
                    malathTPLRequest.InsuredEducationCode = "M";
                    malathTPLRequest.InsuredOccupationCode = "2214061";
                    malathTPLRequest.InsuredChildrenBelow16Years = 2;
                    malathTPLRequest.InsuredBusinessCity = "الرياض";
                    malathTPLRequest.InsuredAddressCity = "الرياض";
                    malathTPLRequest.VehicleIdTypeCode = 2;
                    malathTPLRequest.VehiclePlateNumber = 5440;
                    malathTPLRequest.VehiclePlateText1 = "ب";
                    malathTPLRequest.VehiclePlateText2 = "ر";
                    malathTPLRequest.VehiclePlateText3 = "ص";
                    malathTPLRequest.VehicleChassisNumber = "9A1ZE5E34AF747397";
                    malathTPLRequest.VehicleId = "289912752";
                    malathTPLRequest.VehicleOwnerTransfer = false;
                    malathTPLRequest.VehicleOwnerName = "شهدي محمد الشيمي";
                    malathTPLRequest.VehicleOwnerId = 1086517141;
                    malathTPLRequest.VehiclePlateTypeCode = "1";
                    malathTPLRequest.VehicleModelYear = 2021;
                    malathTPLRequest.VehicleMaker = "شيفورلية";
                    malathTPLRequest.VehicleModel = "ماليبو";
                    malathTPLRequest.VehicleColor = "ابيض";
                    malathTPLRequest.VehicleRegExpiryDate = "22-11-1437";
                    malathTPLRequest.VehicleCylinders = 6;
                    malathTPLRequest.VehicleWeight = 1570;
                    malathTPLRequest.VehicleSeating = 5;
                    malathTPLRequest.VehicleUseCode = 1;
                    malathTPLRequest.VehicleMileage = 10205;
                    malathTPLRequest.VehicleTransmissionTypeCode = "A";
                    malathTPLRequest.VehicleMileageExpectedAnnualCode = 49999;
                    malathTPLRequest.VehicleAxleWeightCode = 19999;
                    malathTPLRequest.VehicleEngineSizeCode = 1999;
                    malathTPLRequest.VehicleOvernightParkingLocationCode = "R";
                    malathTPLRequest.VehicleModification = true;
                    malathTPLRequest.VehicleModificationDetails = "مزود سرعة";

                    //VehicleSpecification
                    malathTPLRequest.VehicleSpecifications = new List<WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.VehicleSpecification>();
                    var vehicleSpeci = new WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.VehicleSpecification()
                    {
                        VehicleSpecificationCode = 1
                    };
                    malathTPLRequest.VehicleSpecifications.Add(vehicleSpeci);
                    vehicleSpeci.VehicleSpecificationCode = 2;
                    malathTPLRequest.VehicleSpecifications.Add(vehicleSpeci);
                    vehicleSpeci.VehicleSpecificationCode = 3;
                    malathTPLRequest.VehicleSpecifications.Add(vehicleSpeci);

                    malathTPLRequest.NCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*3*/;
                    malathTPLRequest.NCDReference = nCDEligibilityResponse.ncdReference /*"NCD24081726802"*/;

                    //DriverInformation
                    malathTPLRequest.Drivers = new List<WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.Drivers>();
                    var driverr = new WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.Drivers()
                    {
                        DriverTypeCode = 1,
                        DriverId = 1086517141,
                        DriverIdTypeCode = 1,
                        DriverBirthDate = "01-01-1410",
                        DriverGenderCode = "M",
                        DriverBirthDateG = "1982-01-01",
                        DriverNationalityCode = "113",
                        DriverFirstNameAr = "شهدي",
                        DriverMiddleNameAr = "محمد",
                        DriverLastNameAr = "الشيمي",
                        DriverFirstNameEn = "Shohdy",
                        DriverMiddleNameEn = "Mohamed",
                        DriverLastNameEn = "ElSheemy",
                        DriverSocialStatusCode = "2",
                        DriverDrivingPercentage = 50,
                        DriverEducationCode = "M",
                        DriverOccupationCode = "2214061",
                        DriverMedicalConditionCode = new List<int>() { 2, 4 },
                        DriverChildrenBelow16Years = 2,
                        DriverAddressCity = "الرياض",
                        DriverBusinessCity = "الرياض",
                        DriverNOALast5Years = 0,
                        DriverNOCLast5Years = 0,
                        DriverNCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*3*/,
                        DriverNCDReference = nCDEligibilityResponse.ncdReference /*"NCD24081726802"*/,
                        DriverRelationship = null
                    };

                    //DriverLicense
                    driverr.DriverLicenses = new List<WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.DriverLicense>();
                    var driverLicense = new WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.DriverLicense()
                    {
                        LicenseCountryCode = 113,
                        LicenseNumberYears = 7,
                        DriverLicenseTypeCode = "1",
                        DriverLicenseExpiryDate = "22-05-1446"
                    };
                    driverr.DriverLicenses.Add(driverLicense);

                    driverLicense.LicenseCountryCode = 102;
                    driverLicense.LicenseNumberYears = 7;
                    driverLicense.DriverLicenseTypeCode = "1";
                    driverLicense.DriverLicenseExpiryDate = "22-05-1446";
                    driverr.DriverLicenses.Add(driverLicense);

                    //DriverViolation
                    driverr.DriverViolations = new List<WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.DriverViolation>();
                    var driverViolation1 = new WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.DriverViolation()
                    { ViolationCode = 1 };
                    driverr.DriverViolations.Add(driverViolation1);

                    driverViolation1.ViolationCode = 2;
                    driverr.DriverViolations.Add(driverViolation1);

                    malathTPLRequest.Drivers.Add(driverr);

                    //Driver2
                    driverr.DriverTypeCode = 2;
                    driverr.DriverId = 1086517142;
                    driverr.DriverIdTypeCode = 1;
                    driverr.DriverBirthDate = "01-01-1410";
                    driverr.DriverGenderCode = "F";
                    driverr.DriverBirthDateG = "1982-01-01";
                    driverr.DriverNationalityCode = "113";
                    driverr.DriverFirstNameAr = "مي";
                    driverr.DriverMiddleNameAr = "شهدي";
                    driverr.DriverLastNameAr = "الشيمي";
                    driverr.DriverFirstNameEn = "Mai";
                    driverr.DriverMiddleNameEn = "Shohdy";
                    driverr.DriverLastNameEn = "ElSheemy";
                    driverr.DriverSocialStatusCode = "2";
                    driverr.DriverDrivingPercentage = 50;
                    driverr.DriverEducationCode = "B";
                    driverr.DriverOccupationCode = "2214061";
                    driverr.DriverChildrenBelow16Years = 2;
                    driverr.DriverAddressCity = "الرياض";
                    driverr.DriverBusinessCity = "الرياض";
                    driverr.DriverNOALast5Years = 0;
                    driverr.DriverNOCLast5Years = 0;
                    driverr.DriverNCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*3*/;
                    driverr.DriverNCDReference = nCDEligibilityResponse.ncdReference /*"NCD24081726802"*/;
                    driverr.DriverRelationship = "WIFE";

                    //Driver Medical Condition
                    driverr.DriverMedicalConditionCode = new List<int>();
                    driverr.DriverMedicalConditionCode.Add(2);
                    driverr.DriverMedicalConditionCode.Add(4);

                    //DriverLicense
                    driverLicense.LicenseCountryCode = 113;
                    driverLicense.LicenseNumberYears = 7;
                    driverLicense.DriverLicenseTypeCode = "1";
                    driverLicense.DriverLicenseExpiryDate = "22-05-1446";
                    driverr.DriverLicenses.Add(driverLicense);

                    driverLicense.LicenseCountryCode = 102;
                    driverLicense.LicenseNumberYears = 7;
                    driverLicense.DriverLicenseTypeCode = "1";
                    driverLicense.DriverLicenseExpiryDate = "22-05-1446";
                    driverr.DriverLicenses.Add(driverLicense);

                    //DriverViolation
                    var driverViolation2 = new WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote.DriverViolation();
                    driverViolation2.ViolationCode = 1;
                    driverr.DriverViolations.Add(driverViolation2);

                    driverViolation2.ViolationCode = 2;
                    driverr.DriverViolations.Add(driverViolation2);

                    malathTPLRequest.Drivers.Add(driverr);

                    var responseMalathTPL = await _mediator.Send(malathTPLRequest);
                    if (responseMalathTPL.Data == null)
                    {
                        goto ListQuotes;
                    }
                    else
                    {
                        if (responseMalathTPL.Data.Error != null)
                        {
                            if (responseMalathTPL.Data.Error.Count >= 1)
                            {
                                _logger.LogInformation(responseMalathTPL.Data.Error.ToList().ToString());
                                goto ListQuotes;
                            }
                        }
                    }


                    Quote quoteTPL_Malath = new Quote();
                    var premiumDetailsList = new List<PremiumDetails>();
                    for (int i = 0; i < responseMalathTPL.Data.Products.Count; i++)
                    {
                        List<AdditionalCovers> additionalMalathTPLCovers = new List<AdditionalCovers>();
                        List<PremiumBreakdown> premiumBreakdownsList = new List<PremiumBreakdown>();
                        List<DiscountBreakdown> discountBreakdownsList = new List<DiscountBreakdown>();
                        for (int j = 0; j < responseMalathTPL.Data.Products[i].PriceDetails.Count; j++)
                        {
                            decimal percetage = responseMalathTPL.Data.Products[i].PriceDetails[j].PercentageValue ?? 0;
                            var premiumBreakdownDetail = new PremiumBreakdown()
                            {
                                TypeCode = responseMalathTPL.Data.Products[i].PriceDetails[j].PriceTypeCode,
                                Amount = Double.Parse(responseMalathTPL.Data.Products[i].PriceDetails[j].PriceValue.ToString()),
                                Percentage = Double.Parse(percetage.ToString())
                            };
                            premiumBreakdownsList.Add(premiumBreakdownDetail);
                        }

                        for (int k = 0; k < responseMalathTPL.Data.Products[i].Covers.Count; k++)
                        {
                            var cover = new AdditionalCovers()
                            {
                                FeatureCode = responseMalathTPL.Data.Products[i].Covers[k].CoverCode.ToString(),
                                FeatureDesc = responseMalathTPL.Data.Products[i].Covers[k].CoverNameEn,
                                FeatureAmount = Double.Parse(responseMalathTPL.Data.Products[i].Covers[k].CoverPrice.ToString()),
                                TaxAmount = 0.0,
                            };
                            additionalMalathTPLCovers.Add(cover);
                        }

                        var premiumDetail = new PremiumDetails()
                        {
                            deductable = 0,
                            GrossPremium = 0.00,
                            TotalDiscount = 0.00,
                            PremiumExcVat = 0.00,
                            TotalTax = 0.00,
                            TotalPremium = Double.Parse(responseMalathTPL.Data.Products[i].ProductPrice.ToString()),
                            additionalCovers = additionalMalathTPLCovers,
                            discountBreakdowns = discountBreakdownsList,
                            premiumBreakdown = premiumBreakdownsList
                        };
                        premiumDetailsList.Add(premiumDetail);
                    }

                    quoteTPL_Malath.ICID = insuranceCompanies.Data[2].Id;
                    quoteTPL_Malath.vehicleId = request.VehicleID;
                    quoteTPL_Malath.QuoteRequestRefNo = responseMalathTPL.Data.RequestReferenceNo.ToString();
                    quoteTPL_Malath.QuotationNo = responseMalathTPL.Data.QuotationNo;
                    quoteTPL_Malath.product = "TPL";
                    quoteTPL_Malath.companyName = insuranceCompanies.Data[2].InsuranceCompanyName; //"Malath";
                    quoteTPL_Malath.premiumDetails = premiumDetailsList;

                    listQuotes.Quote.Add(quoteTPL_Malath);
                    _logger.LogInformation("TPL Quote  Completed");
                    //TPL Malath Ends
                    #endregion
            }
            if (request.QuoteType == "CMP")
            {
                _logger.LogInformation("Comprehensive Quote  Initiated");
                #region NCD Eligibility Starts
                //NCD Eligibility Starts

                //Start of NCDEligibility
                //Here NCDEligibility API call will happen and using these(NCDReference and NCDFreeYears) 2 response values ACIG, Walaa and Malath API will get call

                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                string newResponse = "";

                //AzureServer
                RestClient client = new RestClient("http://thirdparty.wazen.ml/api/v1/NCDEligibility/NCDEligibility");

                //Server
                //RestClient client = new RestClient("http://180.149.247.134:8097/api/v1/NCDEligibility/NCDEligibility");
                var requestNCDEligibility = new RestRequest(Method.GET);
                requestNCDEligibility.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
                requestNCDEligibility.AddHeader("Content-Type", "application/json");
                //requestNCDEligibility.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse getNCDEligibilityResponse = client.Execute(requestNCDEligibility);
                if (getNCDEligibilityResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = getNCDEligibilityResponse.Content;
                }
                NCDEligiblityResponseRedis nCDEligibilityResponse = new NCDEligiblityResponseRedis();
                if (newResponse != "")
                    nCDEligibilityResponse = JsonSerializer.Deserialize<NCDEligiblityResponseRedis>(newResponse);

                //NCD Eligibility Ends
                #endregion NCD Eligibility Ends

                #region CMP ACIG
                //CMP ACIG Starts

                Guid ICID = insuranceCompanies.Data[0].Id;
                //Guid ICID = Guid.Parse("F6C16294-A259-442C-B343-F526BC9DD8CD");//insuranceCompanies.Data[2].Id;

                _logger.LogInformation("Retrieving matching record from Lists by Passing Value and ACIG ICID Initiated");
                var addCovers = additionalCoverList.FirstOrDefault<ICAdditionalCoverr>(x => x.Description == "Emergency Medical Expenses" && x.ICID == ICID);
                var bankCode = bankCodeList.FirstOrDefault<ICBankCode>(x => x.Description == "National Bank of Kuwait" && x.ICID == ICID);
                var cardIdType = cardIdTypeList.FirstOrDefault<ICCardIdType>(x => x.Description == "Resident" && x.ICID == ICID);
                var city = citiesList.FirstOrDefault<ICCities>(x => x.Description == "KALWAH" && x.ICID == ICID);
                var country = countriesList.FirstOrDefault<ICCountries>(x => x.Description == "Resident" && x.ICID == ICID);
                var deductable = deductableList.FirstOrDefault<ICDeductable>(x => x.Description == "0,5000,7500,10000,25000,50000" && x.ICID == ICID);
                var discount = discountList.FirstOrDefault<ICDiscount>(x => x.Description == "Additional Age Contribution" && x.ICID == ICID);
                var driverType = driverTypeList.FirstOrDefault<ICDriverType>(x => x.Description == "Additional Driver" && x.ICID == ICID);
                var drivingPercent = drivingPercentageList.FirstOrDefault<ICDrivingPercentage>(x => x.Description == "0.5" && x.ICID == ICID);
                var education = educationList.FirstOrDefault<ICEducation>(x => x.Description == "None" && x.ICID == ICID);
                var gender = genderList.FirstOrDefault<ICGender>(x => x.Description == "Female" && x.ICID == ICID);
                var healthCondition = healthConditionList.FirstOrDefault<ICHealthCondition>(x => x.Description == "During daytime only" && x.ICID == ICID);
                var imageTitle = imageTitleList.FirstOrDefault<ICImageTitle>(x => x.Description == "Image Front" && x.ICID == ICID);
                var licenseType = licenseTypeList.FirstOrDefault<ICLicenseType>(x => x.Description == "Private above or equal 25 years" && x.ICID == ICID);
                var maritalStatus = maritalStatusList.FirstOrDefault<ICMaritalStatus>(x => x.Description == "Single" && x.ICID == ICID);
                var mileage = mileageList.FirstOrDefault<ICMileages>(x => x.Description == "From 50,000  to 100,000 KM" && x.ICID == ICID);
                var nationality = nationalitiesList.FirstOrDefault<ICNationality>(x => x.Description == "Suede" && x.ICID == ICID);
                var ncdFreeYear = nCDFreeYearList.FirstOrDefault<ICNCDFreeYear>(x => x.Description == "‘3’ Year Free Claim " && x.ICID == ICID);
                var occupation = occupationList.FirstOrDefault<ICOccupation>(x => x.Description == "Employee" && x.ICID == ICID);
                var parkingLocation = parkingLocationList.FirstOrDefault<ICParkingLocation>(x => x.Description == "Garage" && x.ICID == ICID);
                var paymentMethod = paymentMethodList.FirstOrDefault<ICPaymentMethod>(x => x.Description == "MASTER" && x.ICID == ICID);
                var plateLetter = plateLetterList.FirstOrDefault<ICPlateLetter>(x => x.Description == "" && x.ICID == ICID);
                var premium = premiumBreakList.FirstOrDefault<ICPremiumBreakdownn>(x => x.Description == "Basic Cover" && x.ICID == ICID);
                var priceType = priceTypeList.FirstOrDefault<ICPriceType>(x => x.Description == "Image Right" && x.ICID == ICID);
                var productType = productTypeList.FirstOrDefault<ICProductType>(x => x.Description == "COMP" && x.ICID == ICID);
                var relationship = relationshipList.FirstOrDefault<ICRelationship>(x => x.Description == "Brother / Sister" && x.ICID == ICID);
                var repairType = repairTypeList.FirstOrDefault<ICRepairType>(x => x.Description == "Agency" && x.ICID == ICID);
                var transmissionType = transmissionTypeList.FirstOrDefault<ICTransmissionType>(x => x.Description == "Manual" && x.ICID == ICID);
                var vehicleAxlesWeight = vehicleAxlesWeightList.FirstOrDefault<ICVehicleAxlesWeight>(x => x.Description == "Less than19999 Tons" && x.ICID == ICID);
                var vehicleColor = vehicleColorList.FirstOrDefault<ICVehicleColor>(x => x.Description == "Black" && x.ICID == ICID);
                var vehicleEngineSize = vehicleEngineSizeList.FirstOrDefault<ICVehicleEngineSize>(x => x.Description == "More than 4001CC" && x.ICID == ICID);
                var vehicleIdType = vehicleIdTypeList.FirstOrDefault<ICVehicleIdType>(x => x.Description == "Sequence" && x.ICID == ICID);
                var vehiclePlateType = vehiclePlateTypeList.FirstOrDefault<ICVehiclePlateType>(x => x.Description == "Public Bus" && x.ICID == ICID);
                var vehicleSpecification = vehicleSpecificationList.FirstOrDefault<ICVehicleSpecificationn>(x => x.Description == "FRONT SENSORS" && x.ICID == ICID);
                var vehicleUses = vehicleUsesList.FirstOrDefault<ICVehicleUses>(x => x.Description == "COMMERCIAL" && x.ICID == ICID);
                var violation = violationList.FirstOrDefault<ICViolation>(x => x.Description == "Infringing rules by using strong lights" && x.ICID == ICID);
                _logger.LogInformation("Retrieving matching record from Lists by Passing Value and ACIG ICID Completed");

                #region Need to given call to CMP ACIG
                var acigCMPQuoteCommand = new ACIGCMPQuoteCommand();

                #region Adding Lookup values into ACIG Command Request
                acigCMPQuoteCommand.UserId = 755;
                acigCMPQuoteCommand.UserName = "Wazen";
                acigCMPQuoteCommand.QuoteRequestRefNo = "UTTest";
                acigCMPQuoteCommand.Product = productType.ValueEng /*"COMP"*/;
                acigCMPQuoteCommand.PolicyEffectiveDate = DateTime.Now.AddDays(1).ToString();

                //Customer OR InsuredInfo
                acigCMPQuoteCommand.InsuredInfo.IdTypeCode = int.Parse(cardIdType.ValueEng) /*2*/;
                acigCMPQuoteCommand.InsuredInfo.IdNo = "2065564035";
                acigCMPQuoteCommand.InsuredInfo.NameEng = tempCustomerResponse.Data.EnglishFirstName + " " + tempCustomerResponse.Data.EnglishMiddleName + " " + tempCustomerResponse.Data.EnglishLastName /*"Ameen Al rafie"*/;
                acigCMPQuoteCommand.InsuredInfo.NameAr = "أمين الرافعي";
                acigCMPQuoteCommand.InsuredInfo.IdExpiryDate = "01-1442";
                acigCMPQuoteCommand.InsuredInfo.IdRegistrationCityCode = "7";
                acigCMPQuoteCommand.InsuredInfo.BirthDateG = tempCustomerResponse.Data.DateOfBirth.ToString() /*"01-01-1983"*/;
                acigCMPQuoteCommand.InsuredInfo.BirthDateH = "01-01-1420";
                acigCMPQuoteCommand.InsuredInfo.GenderCode = int.Parse(gender.ValueEng) /*2*/;
                acigCMPQuoteCommand.InsuredInfo.MaritalStatusCode = int.Parse(maritalStatus.ValueEng) /*2*/;
                acigCMPQuoteCommand.InsuredInfo.OccupationCode = int.Parse(occupation.ValueEng) /*1*/;
                acigCMPQuoteCommand.InsuredInfo.EducationCode = int.Parse(education.ValueEng) /*1*/;
                acigCMPQuoteCommand.InsuredInfo.NationalityCode = int.Parse(nationality.ValueEng) /*90*/;
                acigCMPQuoteCommand.InsuredInfo.ChildrenBelow16 = 0;
                acigCMPQuoteCommand.InsuredInfo.MobileNo = tempCustomerResponse.Data.Mobile /*"580235141"*/;
                acigCMPQuoteCommand.InsuredInfo.EmailId = tempCustomerResponse.Data.Email /*"gajula.suresh@amtpl.com"*/;
                acigCMPQuoteCommand.InsuredInfo.NcdYears = nCDEligibilityResponse.ncdFreeYears /*int.Parse(ncdFreeYear.ValueEng)*/ /*5*/;
                acigCMPQuoteCommand.InsuredInfo.NcdReference = nCDEligibilityResponse.ncdReference /*"NCD12589"*/;
                acigCMPQuoteCommand.InsuredInfo.NoOfAccidents = 0;
                acigCMPQuoteCommand.InsuredInfo.AccidentsLiability = 0;
                acigCMPQuoteCommand.InsuredInfo.IsTransferOfOwnership = false;
                acigCMPQuoteCommand.InsuredInfo.OwnerId = null;

                //Address
                acigCMPQuoteCommand.InsuredInfo.Address.Street = "Makkah";
                acigCMPQuoteCommand.InsuredInfo.Address.District = "Jeddah";
                acigCMPQuoteCommand.InsuredInfo.Address.City = city.Description/*"Riyadh"*/;
                acigCMPQuoteCommand.InsuredInfo.Address.CityCode = int.Parse(city.ValueEng)/*34330*/;
                acigCMPQuoteCommand.InsuredInfo.Address.PostalCode = 58266;
                acigCMPQuoteCommand.InsuredInfo.Address.BuildingNumber = 2569;
                acigCMPQuoteCommand.InsuredInfo.Address.AdditionalNumber = 5269;
                acigCMPQuoteCommand.InsuredInfo.Address.UnitNumber = 1;
                acigCMPQuoteCommand.InsuredInfo.Address.LanguageCode = null;

                //AccidentDetails
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails = new WazenPolicy.Application.Features.ACIG.Command.ACIGCMPQuote.AccidentDetail();
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.accidentDate = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.carModel = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.carType = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.caseNumber = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.causeOfAccident = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.cityName = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.damageParts = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.driverAge = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.driverIdNumber = null;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.estimatedAmount = 0.0M;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.liability = 0;
                acigCMPQuoteCommand.InsuredInfo.AccidentDetails.sequenceNumber = tempVehicleResponse.Data.SequenceNumber /*null*/;

                //VehicleInformation
                acigCMPQuoteCommand.VehicleInfo.VehicleIdTypeCode = int.Parse(vehicleIdType.ValueEng)/*1*/;
                acigCMPQuoteCommand.VehicleInfo.RepairTypeCode = int.Parse(repairType.ValueEng) /*2*/;
                acigCMPQuoteCommand.VehicleInfo.BodyTypeCode = 0;
                acigCMPQuoteCommand.VehicleInfo.ChassisNumber = "MALC741B0LM177285";
                acigCMPQuoteCommand.VehicleInfo.ColorCode = int.Parse(vehicleColor.ValueEng) /*1*/;
                acigCMPQuoteCommand.VehicleInfo.ColorDesc = vehicleColor.Description /*"White"*/;
                acigCMPQuoteCommand.VehicleInfo.SequenceNumber = tempVehicleResponse.Data.SequenceNumber /*"256968468"*/;
                acigCMPQuoteCommand.VehicleInfo.CustomNumber = tempVehicleResponse.Data.SequenceNumberCustomID /*null*/;
                acigCMPQuoteCommand.VehicleInfo.Cylinders = 0;
                acigCMPQuoteCommand.VehicleInfo.DrivingCityCode = int.Parse(city.ValueEng) /*0*/;
                acigCMPQuoteCommand.VehicleInfo.EngineSize = null;
                acigCMPQuoteCommand.VehicleInfo.ExpectedAnnualMileage = 0;
                acigCMPQuoteCommand.VehicleInfo.VehicleValue = 52565;
                acigCMPQuoteCommand.VehicleInfo.MakeCode = "11";
                acigCMPQuoteCommand.VehicleInfo.MakeCodeELM = "11";
                acigCMPQuoteCommand.VehicleInfo.MakeDesc = tempVehicleResponse.Data.VehicleMake /*"Toyota"*/;
                acigCMPQuoteCommand.VehicleInfo.ModelCode = "45";
                acigCMPQuoteCommand.VehicleInfo.ModelCodeELM = "45";
                acigCMPQuoteCommand.VehicleInfo.ModelDesc = tempVehicleResponse.Data.VehicleModel /*"Fortuner"*/;
                acigCMPQuoteCommand.VehicleInfo.ManufactureYear = tempVehicleResponse.Data.YearofManufacture /*"2015"*/;
                acigCMPQuoteCommand.VehicleInfo.PlateTypeCode = vehiclePlateType.ValueEng /*"1"*/;
                acigCMPQuoteCommand.VehicleInfo.PlateNumber = "8296";
                acigCMPQuoteCommand.VehicleInfo.FirstPlateLetter = tempVehicleResponse.Data.FirstPlateLetter /*"ص"*/;
                acigCMPQuoteCommand.VehicleInfo.SecondPlateLetter = "ل";
                acigCMPQuoteCommand.VehicleInfo.ThirdPlateLetter = "ك";
                acigCMPQuoteCommand.VehicleInfo.NightParkingCode = int.Parse(parkingLocation.ValueEng) /*1*/;
                acigCMPQuoteCommand.VehicleInfo.RegistrationCityCode = "7";
                acigCMPQuoteCommand.VehicleInfo.RegistrationExpiryDate = "11-01-1445";
                acigCMPQuoteCommand.VehicleInfo.SeatsCapacity = 0;
                acigCMPQuoteCommand.VehicleInfo.TransmissionTypeCode = int.Parse(transmissionType.ValueEng) /*1*/;
                acigCMPQuoteCommand.VehicleInfo.UsagePurposeCode = int.Parse(vehicleUses.ValueEng)/*1*/;
                acigCMPQuoteCommand.VehicleInfo.Weight = 0;
                acigCMPQuoteCommand.VehicleInfo.Automatic_Braking_System = 2;
                acigCMPQuoteCommand.VehicleInfo.Cruise_Control = 2;
                acigCMPQuoteCommand.VehicleInfo.Adaptive_Cruise_Control = 2;
                acigCMPQuoteCommand.VehicleInfo.Rear_Parking_Sensors = 2;
                acigCMPQuoteCommand.VehicleInfo.Front_Sensors = 2;
                acigCMPQuoteCommand.VehicleInfo.Front_Camera = 2;
                acigCMPQuoteCommand.VehicleInfo.Rear_Camera = 2;
                acigCMPQuoteCommand.VehicleInfo.Degree_Camera_360 = 2;
                acigCMPQuoteCommand.VehicleInfo.Fire_Extinguisher = 2;
                acigCMPQuoteCommand.VehicleInfo.Modifications_In_The_car = 1;
                acigCMPQuoteCommand.VehicleInfo.Modifications_In_The_Car_Desc = "vehicle";
                acigCMPQuoteCommand.VehicleInfo.Vehicle_Axle_Weight = null;
                acigCMPQuoteCommand.VehicleInfo.Antilock_Braking_System = 2;

                //Driver Information
                acigCMPQuoteCommand.DriverInfo[0].IsPolicyHolder = true;
                acigCMPQuoteCommand.DriverInfo[0].IsMaindriver = tempDriverResponse.Data.IsMainDriver /*true*/;
                acigCMPQuoteCommand.DriverInfo[0].IdTypeCode = int.Parse(cardIdType.ValueEng) /*1*/;
                acigCMPQuoteCommand.DriverInfo[0].IdNo = "1569854789";
                acigCMPQuoteCommand.DriverInfo[0].NameEng = tempDriverResponse.Data.DriverName /*"Salman bin Nasser bin Hussein Al Sultan"*/;
                acigCMPQuoteCommand.DriverInfo[0].NameAr = "سلمان بن ناصر بن حسين السلطان";
                acigCMPQuoteCommand.DriverInfo[0].BirthDateG = tempDriverResponse.Data.DateOfBirth.ToString() /*null*/;
                acigCMPQuoteCommand.DriverInfo[0].BirthDateH = "01-14-1420";
                acigCMPQuoteCommand.DriverInfo[0].DriverAge = 0;
                acigCMPQuoteCommand.DriverInfo[0].GenderCode = int.Parse(gender.ValueEng) /*1*/;
                acigCMPQuoteCommand.DriverInfo[0].MaritalStatusCode = int.Parse(maritalStatus.ValueEng) /*1*/;
                acigCMPQuoteCommand.DriverInfo[0].OccupationCode = int.Parse(occupation.ValueEng) /*1*/;
                acigCMPQuoteCommand.DriverInfo[0].EducationCode = int.Parse(education.ValueEng) /*1*/;
                acigCMPQuoteCommand.DriverInfo[0].NationalityCode = int.Parse(nationality.ValueEng) /*90*/;
                acigCMPQuoteCommand.DriverInfo[0].ChildrenBelow16 = int.Parse(tempDriverResponse.Data.ChildrenBelow16) /*0*/;
                acigCMPQuoteCommand.DriverInfo[0].RelationWithInsuredCode = 1;
                acigCMPQuoteCommand.DriverInfo[0].HealthConditionsCode = int.Parse(healthCondition.ValueEng) /*1*/;
                acigCMPQuoteCommand.DriverInfo[0].MobileNo = null;
                acigCMPQuoteCommand.DriverInfo[0].EmailId = null;
                acigCMPQuoteCommand.DriverInfo[0].LicenseTypeCode = int.Parse(licenseType.ValueEng) /*0*/;
                acigCMPQuoteCommand.DriverInfo[0].LicenseExpiryDate = "01-01-1442";
                acigCMPQuoteCommand.DriverInfo[0].DrivingExpYears = 5;
                acigCMPQuoteCommand.DriverInfo[0].NoOfYearsSaudiLicenseHeld = 8;
                acigCMPQuoteCommand.DriverInfo[0].NcdYears = nCDEligibilityResponse.ncdFreeYears /*int.Parse(ncdFreeYear.ValueEng)*/ /*0*/;
                acigCMPQuoteCommand.DriverInfo[0].NcdReference = nCDEligibilityResponse.ncdReference /*null*/;
                acigCMPQuoteCommand.DriverInfo[0].VehicleUsagePercentage = int.Parse(tempVehicleResponse.Data.VehicleUsagePercentage) /*100*/;
                acigCMPQuoteCommand.DriverInfo[0].WorkCompanyName = tempDriverResponse.Data.WorkCompanyName /*null*/;
                acigCMPQuoteCommand.DriverInfo[0].TrafficViolationsCode = null;
                acigCMPQuoteCommand.DriverInfo[0].CityCode = int.Parse(city.ValueEng) /*null*/;
                acigCMPQuoteCommand.DriverInfo[0].HomeAddress = null;
                acigCMPQuoteCommand.DriverInfo[0].OfficeAddress = null;
                acigCMPQuoteCommand.DriverInfo[0].CountriesDrivingLicense[0].LicenseCountryCode = int.Parse(country.ValueEng)/*167*/;
                acigCMPQuoteCommand.DriverInfo[0].CountriesDrivingLicense[0].LicenseYears = 8;
                acigCMPQuoteCommand.DriverInfo[0].CountriesDrivingLicense[1].LicenseCountryCode = int.Parse(country.ValueEng) /*167*/;
                acigCMPQuoteCommand.DriverInfo[0].CountriesDrivingLicense[1].LicenseYears = 25;
                #endregion End of ACIGTPL Command Request

                var actualResponseCMPACIG = await _mediator.Send(acigCMPQuoteCommand);
                if (actualResponseCMPACIG.Data == null)
                {
                    goto Walaa;
                }
                else
                {
                    if (actualResponseCMPACIG.Data.Errors != null)
                    {
                        if (actualResponseCMPACIG.Data.Errors.Count >= 1)
                        {
                            _logger.LogInformation(actualResponseCMPACIG.Data.Errors.ToList().ToString());
                            goto Walaa;
                        }
                    }
                }



                var additionalCMPCoverList = new List<WazenPolicy.Application.Features.ACIG.Command.ACIGCMPQuote.AdditionalCover>();

                for (int i = 0; i < actualResponseCMPACIG.Data.Quote.Count; i++)
                {
                    if (actualResponseCMPACIG.Data.Quote[i].AdditionalCovers != null)
                    {
                        for (int j = 0; j < actualResponseCMPACIG.Data.Quote[i].AdditionalCovers.Count; j++)
                        {
                            additionalCMPCoverList.Add(actualResponseCMPACIG.Data.Quote[i].AdditionalCovers[j]);
                        }
                    }
                }

                var premiumBreakdownList = new List<PremiumBreakdown>();

                for (int i = 0; i < actualResponseCMPACIG.Data.Quote.Count; i++)
                {
                    if (actualResponseCMPACIG.Data.Quote[i].PremiumDetails != null)
                    {
                        for (int j = 0; j < actualResponseCMPACIG.Data.Quote[i].PremiumDetails.Count; j++)
                        {
                            if (actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown != null)
                            {
                                for (int k = 0; k < actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown.Count; k++)
                                {
                                    var premiumBreakdownDetail = new PremiumBreakdown()
                                    {
                                        TypeCode = actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown[k].TypeCode.ToString(),
                                        Amount = Double.Parse(actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown[k].Amount.ToString()),
                                        Percentage = Double.Parse(actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].PremiumBreakdown[k].Percentage.ToString())
                                    };
                                    premiumBreakdownList.Add(premiumBreakdownDetail);
                                }
                            }
                        }
                    }
                }

                var discountBreakdownList = new List<DiscountBreakdown>();
                for (int i = 0; i < actualResponseCMPACIG.Data.Quote.Count; i++)
                {
                    if (actualResponseCMPACIG.Data.Quote[i].PremiumDetails != null)
                    {
                        for (int j = 0; j < actualResponseCMPACIG.Data.Quote[i].PremiumDetails.Count; j++)
                        {
                            if (actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown != null)
                            {
                                for (int k = 0; k < actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown.Count; k++)
                                {
                                    var discountBreakdownDetail = new DiscountBreakdown()
                                    {
                                        TypeCode = actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown[k].TypeCode.ToString(),
                                        Amount = Double.Parse(actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown[k].Amount.ToString()),
                                        Percentage = Double.Parse(actualResponseCMPACIG.Data.Quote[i].PremiumDetails[j].DiscountBreakdown[k].Percentage.ToString())
                                    };
                                    discountBreakdownList.Add(discountBreakdownDetail);
                                }
                            }
                        }
                    }
                }

                var additionalCoversList = new List<AdditionalCovers>();

                for (int i = 0; i < additionalCMPCoverList.Count; i++)
                {
                    var addCover = new AdditionalCovers()
                    {
                        FeatureCode = additionalCMPCoverList[i].FeatureCode,
                        FeatureDesc = additionalCMPCoverList[i].FeatureDesc,
                        FeatureAmount = additionalCMPCoverList[i].FeatureAmount,
                        TaxAmount = additionalCMPCoverList[i].TaxAmount
                    };

                    additionalCoversList.Add(addCover);
                }

                var premiumDetailss = new List<PremiumDetails>();
                for (int i = 0; i < actualResponseCMPACIG.Data.Quote[0].PremiumDetails.Count; i++)
                {
                    var premiumDetail = new PremiumDetails()
                    {
                        deductable = actualResponseCMPACIG.Data.Quote[0].PremiumDetails[i].Deductable,
                        GrossPremium = 0.0,
                        TotalDiscount = 0.0,
                        PremiumExcVat = 0.0,
                        TotalTax = 0.0,
                        TotalPremium = Double.Parse(actualResponseCMPACIG.Data.Quote[0].PremiumDetails[i].TotalPremium.ToString()),
                        premiumBreakdown = premiumBreakdownList,
                        discountBreakdowns = discountBreakdownList,
                        additionalCovers = additionalCoversList,
                    };
                    premiumDetailss.Add(premiumDetail);
                }

                var quoteCMP_ACIG = new Quote();
                quoteCMP_ACIG.ICID = insuranceCompanies.Data[0].Id;
                quoteCMP_ACIG.vehicleId = request.VehicleID;
                quoteCMP_ACIG.QuoteRequestRefNo = actualResponseCMPACIG.Data.QuoteRequestRefNo;
                quoteCMP_ACIG.QuotationNo = actualResponseCMPACIG.Data.Quote[0].QuotationNo;
                quoteCMP_ACIG.product = "CMP";
                quoteCMP_ACIG.companyName = insuranceCompanies.Data[0].InsuranceCompanyName; //"ACIG";
                quoteCMP_ACIG.premiumDetails = premiumDetailss;
                listQuotes.Quote.Add(quoteCMP_ACIG);

            #endregion End of call to CMP ACIG
            //CMP ACIG Ends
            #endregion CMP ACIG

                #region CMP Walaa
                //CMP Walaa Starts
                Walaa:

                    ICID = insuranceCompanies.Data[1].Id;
                    //ICID = Guid.Parse("F6C16294-A259-442C-B343-F526BC9DD8CD");//insuranceCompanies.Data[2].Id;

                    _logger.LogInformation("Retrieving matching record from Lists by Passing Value and Walaa ICID Initiated");
                    //addCovers = additionalCoverList.FirstOrDefault<AdditionalCoverr>(x => x.Description == "Natural Perils" && x.ICID == ICID);
                    //bankCode = bankCodeList.FirstOrDefault<BankCode>(x => x.Description == "National Bank of Kuwait" && x.ICID == ICID);
                    //cardIdType = cardIdTypeList.FirstOrDefault<CardIdType>(x => x.Description == "Resident" && x.ICID == ICID);
                    //city = citiesList.FirstOrDefault<Cities>(x => x.Description == "HAWTAT BNEY TAMEEM" && x.ICID == ICID);
                    //country = countriesList.FirstOrDefault<Countries>(x => x.Description == "KOREA (NORTH)" && x.ICID == ICID);
                    //deductable = deductableList.FirstOrDefault<Deductable>(x => x.Description == "0,5000,7500,10000,25000,50000" && x.ICID == ICID);
                    //discount = discountList.FirstOrDefault<Discount>(x => x.Description == "Additional Age Contribution" && x.ICID == ICID);
                    //driverType = driverTypeList.FirstOrDefault<DriverType>(x => x.Description == "Additional Driver" && x.ICID == ICID);
                    //drivingPercent = drivingPercentageList.FirstOrDefault<DrivingPercentage>(x => x.Description == "0.5" && x.ICID == ICID);
                    //education = educationList.FirstOrDefault<ICEducation>(x => x.Description == "High Education" && x.ICID == ICID);
                    //gender = genderList.FirstOrDefault<ICGender>(x => x.Description == "Female" && x.ICID == ICID);
                    //healthCondition = healthConditionList.FirstOrDefault<HealthCondition>(x => x.Description == "Driving Inside KSA Only" && x.ICID == ICID);
                    //imageTitle = imageTitleList.FirstOrDefault<ImageTitle>(x => x.Description == "Image Front" && x.ICID == ICID);
                    //licenseType = licenseTypeList.FirstOrDefault<LicenseType>(x => x.Description == "LIGHT TRANSPORT" && x.ICID == ICID);
                    //maritalStatus = maritalStatusList.FirstOrDefault<ICMaritalStatus>(x => x.Description == "Single Female" && x.ICID == ICID);
                    //mileage = mileageList.FirstOrDefault<Mileages>(x => x.Description == "80000-90000" && x.ICID == ICID);
                    //nationality = nationalitiesList.FirstOrDefault<Nationality>(x => x.Description == "South African" && x.ICID == ICID);
                    //ncdFreeYear = nCDFreeYearList.FirstOrDefault<NCDFreeYear>(x => x.Description == "‘3’ Year Free Claim " && x.ICID == ICID);
                    //occupation = occupationList.FirstOrDefault<ICOccupation>(x => x.Description == "Metal construction engineer" && x.ICID == ICID);
                    //parkingLocation = parkingLocationList.FirstOrDefault<ParkingLocation>(x => x.Description == "Garage" && x.ICID == ICID);
                    //paymentMethod = paymentMethodList.FirstOrDefault<PaymentMethod>(x => x.Description == "MASTER" && x.ICID == ICID);
                    //plateLetter = plateLetterList.FirstOrDefault<PlateLetter>(x => x.Description == "" && x.ICID == ICID);
                    //premium = premiumBreakList.FirstOrDefault<PremiumBreakdownn>(x => x.Description == "Basic Cover " && x.ICID == ICID);
                    //priceType = priceTypeList.FirstOrDefault<PriceType>(x => x.Description == "Image Right" && x.ICID == ICID);
                    //productType = productTypeList.FirstOrDefault<ProductType>(x => x.Description == "TPL" && x.ICID == ICID);
                    //relationship = relationshipList.FirstOrDefault<Relationship>(x => x.Description == "Brother / Sister" && x.ICID == ICID);
                    //repairType = repairTypeList.FirstOrDefault<RepairType>(x => x.Description == "Workshop" && x.ICID == ICID);
                    //transmissionType = transmissionTypeList.FirstOrDefault<TransmissionType>(x => x.Description == "Manual Transmission" && x.ICID == ICID);
                    //vehicleAxlesWeight = vehicleAxlesWeightList.FirstOrDefault<VehicleAxlesWeight>(x => x.Description == "Less than19999 Tons" && x.ICID == ICID);
                    //vehicleColor = vehicleColorList.FirstOrDefault<VehicleColor>(x => x.Description == "Black" && x.ICID == ICID);
                    //vehicleEngineSize = vehicleEngineSizeList.FirstOrDefault<VehicleEngineSize>(x => x.Description == "More than 4001CC" && x.ICID == ICID);
                    //vehicleIdType = vehicleIdTypeList.FirstOrDefault<VehicleIdType>(x => x.Description == "Sequence" && x.ICID == ICID);
                    //vehiclePlateType = vehiclePlateTypeList.FirstOrDefault<VehiclePlateType>(x => x.Description == "Public Bus" && x.ICID == ICID);
                    //vehicleSpecification = vehicleSpecificationList.FirstOrDefault<VehicleSpecificationn>(x => x.Description == "FRONT SENSORS" && x.ICID == ICID);
                    //vehicleUses = vehicleUsesList.FirstOrDefault<VehicleUses>(x => x.Description == "COMMERCIAL" && x.ICID == ICID);
                    //violation = violationList.FirstOrDefault<Violation>(x => x.Description == "Infringing rules by using strong lights" && x.ICID == ICID);

                    addCovers = additionalCoverList.FirstOrDefault<ICAdditionalCoverr>(x => x.Description == "Road Side Assistance" && x.ICID == ICID);
                    bankCode = bankCodeList.FirstOrDefault<ICBankCode>(x => x.Description == "National Bank of Kuwait" && x.ICID == ICID);
                    cardIdType = cardIdTypeList.FirstOrDefault<ICCardIdType>(x => x.Description == "Resident" && x.ICID == ICID);
                    city = citiesList.FirstOrDefault<ICCities>(x => x.Description == "AL-KHATHAM" && x.ICID == ICID);
                    country = countriesList.FirstOrDefault<ICCountries>(x => x.Description == "Armenia" && x.ICID == ICID);
                    deductable = deductableList.FirstOrDefault<ICDeductable>(x => x.Description == "0,5000,7500,10000,25000,50000" && x.ICID == ICID);
                    discount = discountList.FirstOrDefault<ICDiscount>(x => x.Description == "NCD Discount" && x.ICID == ICID);
                    driverType = driverTypeList.FirstOrDefault<ICDriverType>(x => x.Description == "Main Driver" && x.ICID == ICID);
                    drivingPercent = drivingPercentageList.FirstOrDefault<ICDrivingPercentage>(x => x.Description == "1" && x.ICID == ICID);
                    education = educationList.FirstOrDefault<ICEducation>(x => x.Description == "High Education" && x.ICID == ICID);
                    gender = genderList.FirstOrDefault<ICGender>(x => x.Description == "Male" && x.ICID == ICID);
                    healthCondition = healthConditionList.FirstOrDefault<ICHealthCondition>(x => x.Description == "No Restriction" && x.ICID == ICID);
                    imageTitle = imageTitleList.FirstOrDefault<ICImageTitle>(x => x.Description == "Image Front" && x.ICID == ICID);
                    licenseType = licenseTypeList.FirstOrDefault<ICLicenseType>(x => x.Description == "TEMPORARY LICENSE (PERMISSION)" && x.ICID == ICID);
                    maritalStatus = maritalStatusList.FirstOrDefault<ICMaritalStatus>(x => x.Description == "Single Male" && x.ICID == ICID);
                    mileage = mileageList.FirstOrDefault<ICMileages>(x => x.Description == "20000-30000" && x.ICID == ICID);
                    nationality = nationalitiesList.FirstOrDefault<ICNationality>(x => x.Description == "Mauritius" && x.ICID == ICID);
                    ncdFreeYear = nCDFreeYearList.FirstOrDefault<ICNCDFreeYear>(x => x.Description == "‘1’ Claim in Year 1 (Applicable next year)" && x.ICID == ICID);
                    occupation = occupationList.FirstOrDefault<ICOccupation>(x => x.Description == "Employee" && x.ICID == ICID);
                    parkingLocation = parkingLocationList.FirstOrDefault<ICParkingLocation>(x => x.Description == "Road-Side" && x.ICID == ICID);
                    paymentMethod = paymentMethodList.FirstOrDefault<ICPaymentMethod>(x => x.Description == "MASTER" && x.ICID == ICID);
                    plateLetter = plateLetterList.FirstOrDefault<ICPlateLetter>(x => x.Description == "U" && x.ICID == ICID);
                    premium = premiumBreakList.FirstOrDefault<ICPremiumBreakdownn>(x => x.Description == "Basic Cover " && x.ICID == ICID);
                    priceType = priceTypeList.FirstOrDefault<ICPriceType>(x => x.Description == "No Claim Discount" && x.ICID == ICID);
                    productType = productTypeList.FirstOrDefault<ICProductType>(x => x.Description == "Third-Party Vehicle Insurance" && x.ICID == ICID);
                    relationship = relationshipList.FirstOrDefault<ICRelationship>(x => x.Description == "None" && x.ICID == ICID);
                    repairType = repairTypeList.FirstOrDefault<ICRepairType>(x => x.Description == "Workshop" && x.ICID == ICID);
                    transmissionType = transmissionTypeList.FirstOrDefault<ICTransmissionType>(x => x.Description == "Manual" && x.ICID == ICID);
                    vehicleAxlesWeight = vehicleAxlesWeightList.FirstOrDefault<ICVehicleAxlesWeight>(x => x.Description == "Up Tp 20 Tons" && x.ICID == ICID);
                    vehicleColor = vehicleColorList.FirstOrDefault<ICVehicleColor>(x => x.Description == "Black" && x.ICID == ICID);
                    vehicleEngineSize = vehicleEngineSizeList.FirstOrDefault<ICVehicleEngineSize>(x => x.Description == "Up To 2,000 CC" && x.ICID == ICID);
                    vehicleIdType = vehicleIdTypeList.FirstOrDefault<ICVehicleIdType>(x => x.Description == "Sequence Number" && x.ICID == ICID);
                    vehiclePlateType = vehiclePlateTypeList.FirstOrDefault<ICVehiclePlateType>(x => x.Description == "Private Car" && x.ICID == ICID);
                    vehicleSpecification = vehicleSpecificationList.FirstOrDefault<ICVehicleSpecificationn>(x => x.Description == "ANTI THEFT ALARM" && x.ICID == ICID);
                    vehicleUses = vehicleUsesList.FirstOrDefault<ICVehicleUses>(x => x.Description == "Private" && x.ICID == ICID);
                    violation = violationList.FirstOrDefault<ICViolation>(x => x.Description == "Speed Ticket" && x.ICID == ICID);
                    _logger.LogInformation("Retrieving matching record from Lists by Passing Value and Walaa ICID Completed");

                    WalaaComprehensiveQuoteCommand walaaCMPRequest = new WalaaComprehensiveQuoteCommand();

                    walaaCMPRequest.ProviderCompanyCode = "25";
                    walaaCMPRequest.ProviderCompanyName = "WZAN Broker";
                    walaaCMPRequest.ReferenceId = "dab92f1aae87493";
                    walaaCMPRequest.ProductTypeCode = 2;
                    walaaCMPRequest.PolicyEffectiveDate = DateTime.Now.AddDays(1);
                    walaaCMPRequest.PostCode = "13318";
                    walaaCMPRequest.InsuredIdTypeCode = 1;
                    walaaCMPRequest.InsuredId = "2198197184";
                    walaaCMPRequest.InsuredBirthDateH = "23-11-1404";
                    walaaCMPRequest.InsuredBirthDateG = "07-05-1994";
                    walaaCMPRequest.InsuredGenderCode = "M";
                    walaaCMPRequest.InsuredNationalityCode = "113";
                    walaaCMPRequest.InsuredIdIssuePlaceCode = "2";
                    walaaCMPRequest.InsuredIdIssuePlace = "جده";
                    walaaCMPRequest.InsuredFirstNameAr = "سيش";
                    walaaCMPRequest.InsuredMiddleNameAr = "";
                    walaaCMPRequest.InsuredLastNameAr = "سيلادوراي";
                    walaaCMPRequest.InsuredFirstNameEn = tempCustomerResponse.Data.EnglishFirstName /*"SUHESH"*/;
                    walaaCMPRequest.InsuredMiddleNameEn = tempCustomerResponse.Data.EnglishMiddleName /*""*/;
                    walaaCMPRequest.InsuredLastNameEn = tempCustomerResponse.Data.EnglishLastName /*"SELLADURAI"*/;
                    walaaCMPRequest.InsuredSocialStatusCode = /*maritalStatus.ValueEng*/ "2";
                    walaaCMPRequest.InsuredOccupationCode = "G";
                    walaaCMPRequest.InsuredEducationCode = /*int.Parse(education.ValueEng)*/ 5;
                    walaaCMPRequest.InsuredChildrenBelow16Years = 0;
                    walaaCMPRequest.InsuredWorkCityCode = "2";
                    walaaCMPRequest.InsuredWorkCity = "جده";
                    walaaCMPRequest.InsuredCityCode = "2";
                    walaaCMPRequest.InsuredCity = "جده";
                    walaaCMPRequest.VehicleIdTypeCode = 2;
                    walaaCMPRequest.VehicleId = 753406110;
                    walaaCMPRequest.VehiclePlateNumber = 2354;
                    walaaCMPRequest.VehiclePlateText1 = "ر";
                    walaaCMPRequest.VehiclePlateText2 = "ي";
                    walaaCMPRequest.VehiclePlateText3 = "ح";
                    walaaCMPRequest.VehicleChassisNumber = "CASSIS7879754578";
                    walaaCMPRequest.VehicleOwnerName = "";
                    walaaCMPRequest.VehicleOwnerId = "2198197184";
                    walaaCMPRequest.VehiclePlateTypeCode = /*vehiclePlateType.ValueEng*/ null;
                    walaaCMPRequest.VehicleModelYear = /*int.Parse(tempVehicleResponse.Data.YearofManufacture)*/ 2016;
                    walaaCMPRequest.VehicleModelCode = "23";
                    walaaCMPRequest.VehicleModel = "تورس سيدان";
                    walaaCMPRequest.VehicleMakerCode = "21";
                    walaaCMPRequest.VehicleMaker = "فورد";
                    walaaCMPRequest.VehicleMajorColorCode = /*vehicleColor.ValueEng*/ "2";
                    walaaCMPRequest.VehicleMajorColor = "أسود";
                    walaaCMPRequest.VehicleBodyTypeCode = "5";
                    walaaCMPRequest.VehicleRegPlaceCode = "2";
                    walaaCMPRequest.VehicleRegPlace = "جده";
                    walaaCMPRequest.VehicleRegExpiryDate = "20-07-1442";
                    walaaCMPRequest.VehicleCylinders = 6;
                    walaaCMPRequest.VehicleWeight = 1696;
                    walaaCMPRequest.VehicleLoad = 5;
                    walaaCMPRequest.VehicleOwnerTransfer = false;
                    walaaCMPRequest.VehicleValue = 90000;
                    walaaCMPRequest.VehicleEngineSizeCode = 0 /*int.Parse(vehicleEngineSize.ValueEng)*/ /*0*/;
                    walaaCMPRequest.VehicleUseCode = int.Parse(vehicleUses.ValueEng) /*1*/;
                    walaaCMPRequest.VehicleMileage = null;
                    walaaCMPRequest.VehicleTransmissionTypeCode = /*int.Parse(transmissionType.ValueEng)*/ 1;
                    walaaCMPRequest.VehicleMileageExpectedAnnualCode = 1;
                    walaaCMPRequest.VehicleAxleWeightCode = null;
                    walaaCMPRequest.VehicleOvernightParkingLocationCode = /*int.Parse(parkingLocation.ValueEng)*/ 1;
                    walaaCMPRequest.VehicleModificationDetails = "";
                    walaaCMPRequest.NCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*0*/;
                    walaaCMPRequest.NCDReference = nCDEligibilityResponse.ncdReference /*"NCD0403217143"*/;

                    //DriverInformation
                    walaaCMPRequest.Drivers = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.Driver>();
                    var driverr = new WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.Driver()
                    {
                        DriverTypeCode = 1,
                        DriverId = "2198197184",
                        DriverIdTypeCode = 1,
                        DriverNationalityCode = "113",
                        DriverGenderCode = "M",
                        DriverBirthDateH = "23-11-1404",
                        DriverBirthDateG = /*tempDriverResponse.Data.DateOfBirth.ToString("yyyy-MM-dd")*/ "1984-08-20",
                        DriverFirstNameAr = "سيش",
                        DriverMiddleNameAr = "",
                        DriverLastNameAr = "سيلادوراي",
                        DriverFirstNameEn = /*tempDriverResponse.Data.DriverName*/ "SUHESH",
                        DriverMiddleNameEn = "",
                        DriverLastNameEn = "SELLADURAI",
                        DriverSocialStatusCode = "2",
                        DriverOccupationCode = "G",
                        DriverDrivingPercentage = /*int.Parse(drivingPercent.ValueEng)*/ 100,
                        DriverEducationCode = /*int.Parse(education.ValueEng)*/ 5,
                        DriverMedicalConditionCode = /*int.Parse(healthCondition.ValueEng)*/ 1,
                        DriverChildrenBelow16Years = 0,
                        DriverHomeCityCode = "2",
                        DriverHomeCity = "جده",
                        DriverWorkCity = "جده",
                        DriverNCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*0*/,
                        DriverNCDReference = nCDEligibilityResponse.ncdReference /*"NCD0403217143"*/,
                        DriverRelationship = 1
                    };


                    //DriverLicense
                    driverr.DriverLicenses = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.DriverLicense>();
                    var driverLicense = new WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.DriverLicense()
                    {
                        LicenseCountryCode = 113,
                        LicenseNumberYears = 18,
                        DriverLicenseTypeCode = "3",
                        DriverLicenseExpiryDate = "04-06-1449"
                    };
                    driverr.DriverLicenses.Add(driverLicense);


                    //Driver Violation
                    driverr.DriverViolations = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.DriverViolation>();
                    var driverViolation1 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.DriverViolation()
                    {
                        ViolationCode = 1
                    };
                    //driverr.DriverViolations.Add(driverViolation1);
                    var driverViolation2 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.DriverViolation()
                    {
                        ViolationCode = 2
                    };
                    //driverr.DriverViolations.Add(driverViolation2);

                    //Accident
                    driverr.Accidents = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.Accident>();
                    var accident1 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.Accident()
                    {
                        CaseNumber = "ABCD123",
                        AccidentDate = DateTime.Parse("2017-01-15T13:57:13"),
                        Liability = 100
                    };
                    driverr.Accidents.Add(accident1);

                    var accident2 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.Accident()
                    {
                        CaseNumber = "ABCD1234",
                        AccidentDate = DateTime.Parse("2018-01-15T13:57:13"),
                        Liability = 95,
                    };

                    driverr.Accidents.Add(accident2);
                    walaaCMPRequest.Drivers.Add(driverr);
                    walaaCMPRequest.Drivers[0].DriverViolations.Add(driverViolation1);
                    walaaCMPRequest.Drivers[0].DriverViolations.Add(driverViolation2);

                    //VehicleSpecification
                    walaaCMPRequest.VehicleSpecifications = new List<WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.VehicleSpecification>();
                    var vehicleSpec1 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.VehicleSpecification()
                    {
                        VehicleSpecificationCode = "1"
                    };
                    walaaCMPRequest.VehicleSpecifications.Add(vehicleSpec1);
                    var vehicleSpec2 = new WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote.VehicleSpecification()
                    {
                        VehicleSpecificationCode = "2"
                    };
                    walaaCMPRequest.VehicleSpecifications.Add(vehicleSpec2);

                    var responseCMP = await _mediator.Send(walaaCMPRequest);
                    if (responseCMP.Data == null)
                    {
                        goto Malath;
                    }
                    else
                    {
                        if (responseCMP.Data.Errors != null)
                        {
                            if (responseCMP.Data.Errors.Count >= 1)
                            {
                                _logger.LogInformation(responseCMP.Data.Errors.ToList().ToString());
                                goto Malath;
                            }
                        }
                    }


                    Quote quoteCMP_Walaa = new Quote();


                    List<PremiumDetails> premiumDetails = new List<PremiumDetails>();

                    for (int i = 0; i < responseCMP.Data.Products.Count; i++)
                    {

                        List<AdditionalCovers> additionalCovers = new List<AdditionalCovers>();
                        List<PremiumBreakdown> premiumBreakdown = new List<PremiumBreakdown>();
                        List<DiscountBreakdown> discountBreakdowns = new List<DiscountBreakdown>();

                        if (responseCMP.Data.Products[i].Benefits != null)
                        {
                            for (int j = 0; j < responseCMP.Data.Products[i].Benefits.Count; j++)
                            {
                                var additionalCover = new AdditionalCovers()
                                {
                                    FeatureCode = responseCMP.Data.Products[i].Benefits[j].BenefitId,
                                    FeatureDesc = responseCMP.Data.Products[i].Benefits[j].BenefitDescEn,
                                    FeatureAmount = responseCMP.Data.Products[i].Benefits[j].BenefitPrice,
                                    TaxAmount = 0.0
                                };
                                additionalCovers.Add(additionalCover);
                            }
                        }

                        if (responseCMP.Data.Products[i].PriceDetails != null)
                        {
                            for (int j = 0; j < responseCMP.Data.Products[i].PriceDetails.Count; j++)
                            {
                                var premiumBreakdownDetail = new PremiumBreakdown()
                                {
                                    TypeCode = responseCMP.Data.Products[i].PriceDetails[j].PriceTypeCode.ToString(),
                                    Amount = Double.Parse(responseCMP.Data.Products[i].PriceDetails[j].PriceValue),
                                    Percentage = Double.Parse(responseCMP.Data.Products[i].PriceDetails[j].PercentageValue)
                                };
                                premiumBreakdown.Add(premiumBreakdownDetail);
                            }
                        }

                        var premiumDetail = new PremiumDetails()
                        {
                            deductable = responseCMP.Data.Products[i].DeductibleValue,
                            GrossPremium = 0.0,
                            TotalDiscount = 0.0,
                            PremiumExcVat = 0.0,
                            TotalTax = 0.0,
                            TotalPremium = Double.Parse(responseCMP.Data.Products[i].ProductPrice),
                            additionalCovers = additionalCovers,
                            premiumBreakdown = premiumBreakdown,
                            discountBreakdowns = discountBreakdowns
                        };
                        premiumDetails.Add(premiumDetail);
                    }

                    quoteCMP_Walaa.ICID = insuranceCompanies.Data[1].Id;
                    quoteCMP_Walaa.vehicleId = request.VehicleID;
                    quoteCMP_Walaa.QuoteRequestRefNo = responseCMP.Data.ReferenceId;
                    quoteCMP_Walaa.QuotationNo = responseCMP.Data.QuotationNo;
                    quoteCMP_Walaa.product = "CMP";
                    quoteCMP_Walaa.companyName = insuranceCompanies.Data[1].InsuranceCompanyName;  //"Walaa";
                    quoteCMP_Walaa.premiumDetails = premiumDetails;

                    listQuotes.Quote.Add(quoteCMP_Walaa);

                //CMP Walaa Ends
                #endregion CMP Walaa

                #region CMP Malath
                //CMP Malath Starts
                Malath:
                    ICID = insuranceCompanies.Data[2].Id;
                    //ICID = Guid.Parse("F6C16294-A259-442C-B343-F526BC9DD8CD");//insuranceCompanies.Data[2].Id;

                    _logger.LogInformation("Retrieving matching record from Lists by Passing Value and Malath ICID Initiated");
                    addCovers = additionalCoverList.FirstOrDefault<ICAdditionalCoverr>(x => x.Description == "Natural Perils" && x.ICID == ICID);
                    bankCode = bankCodeList.FirstOrDefault<ICBankCode>(x => x.Description == "National Bank of Kuwait" && x.ICID == ICID);
                    cardIdType = cardIdTypeList.FirstOrDefault<ICCardIdType>(x => x.Description == "Resident" && x.ICID == ICID);
                    city = citiesList.FirstOrDefault<ICCities>(x => x.Description == "HAWTAT BNEY TAMEEM" && x.ICID == ICID);
                    country = countriesList.FirstOrDefault<ICCountries>(x => x.Description == "KOREA (NORTH)" && x.ICID == ICID);
                    deductable = deductableList.FirstOrDefault<ICDeductable>(x => x.Description == "0,5000,7500,10000,25000,50000" && x.ICID == ICID);
                    discount = discountList.FirstOrDefault<ICDiscount>(x => x.Description == "Additional Age Contribution" && x.ICID == ICID);
                    driverType = driverTypeList.FirstOrDefault<ICDriverType>(x => x.Description == "Additional Driver" && x.ICID == ICID);
                    drivingPercent = drivingPercentageList.FirstOrDefault<ICDrivingPercentage>(x => x.Description == "0.5" && x.ICID == ICID);
                    education = educationList.FirstOrDefault<ICEducation>(x => x.Description == "High Education" && x.ICID == ICID);
                    gender = genderList.FirstOrDefault<ICGender>(x => x.Description == "Female" && x.ICID == ICID);
                    healthCondition = healthConditionList.FirstOrDefault<ICHealthCondition>(x => x.Description == "Driving Inside KSA Only" && x.ICID == ICID);
                    imageTitle = imageTitleList.FirstOrDefault<ICImageTitle>(x => x.Description == "Image Front" && x.ICID == ICID);
                    licenseType = licenseTypeList.FirstOrDefault<ICLicenseType>(x => x.Description == "LIGHT TRANSPORT" && x.ICID == ICID);
                    maritalStatus = maritalStatusList.FirstOrDefault<ICMaritalStatus>(x => x.Description == "Single Female" && x.ICID == ICID);
                    mileage = mileageList.FirstOrDefault<ICMileages>(x => x.Description == "80000-90000" && x.ICID == ICID);
                    nationality = nationalitiesList.FirstOrDefault<ICNationality>(x => x.Description == "South African" && x.ICID == ICID);
                    ncdFreeYear = nCDFreeYearList.FirstOrDefault<ICNCDFreeYear>(x => x.Description == "‘3’ Year Free Claim " && x.ICID == ICID);
                    occupation = occupationList.FirstOrDefault<ICOccupation>(x => x.Description == "Metal construction engineer" && x.ICID == ICID);
                    parkingLocation = parkingLocationList.FirstOrDefault<ICParkingLocation>(x => x.Description == "Garage" && x.ICID == ICID);
                    paymentMethod = paymentMethodList.FirstOrDefault<ICPaymentMethod>(x => x.Description == "MASTER" && x.ICID == ICID);
                    plateLetter = plateLetterList.FirstOrDefault<ICPlateLetter>(x => x.Description == "" && x.ICID == ICID);
                    premium = premiumBreakList.FirstOrDefault<ICPremiumBreakdownn>(x => x.Description == "Basic Cover " && x.ICID == ICID);
                    priceType = priceTypeList.FirstOrDefault<ICPriceType>(x => x.Description == "Image Right" && x.ICID == ICID);
                    productType = productTypeList.FirstOrDefault<ICProductType>(x => x.Description == "TPL" && x.ICID == ICID);
                    relationship = relationshipList.FirstOrDefault<ICRelationship>(x => x.Description == "Brother / Sister" && x.ICID == ICID);
                    repairType = repairTypeList.FirstOrDefault<ICRepairType>(x => x.Description == "Workshop" && x.ICID == ICID);
                    transmissionType = transmissionTypeList.FirstOrDefault<ICTransmissionType>(x => x.Description == "Manual Transmission" && x.ICID == ICID);
                    vehicleAxlesWeight = vehicleAxlesWeightList.FirstOrDefault<ICVehicleAxlesWeight>(x => x.Description == "Less than19999 Tons" && x.ICID == ICID);
                    vehicleColor = vehicleColorList.FirstOrDefault<ICVehicleColor>(x => x.Description == "Black" && x.ICID == ICID);
                    vehicleEngineSize = vehicleEngineSizeList.FirstOrDefault<ICVehicleEngineSize>(x => x.Description == "More than 4001CC" && x.ICID == ICID);
                    vehicleIdType = vehicleIdTypeList.FirstOrDefault<ICVehicleIdType>(x => x.Description == "Sequence" && x.ICID == ICID);
                    vehiclePlateType = vehiclePlateTypeList.FirstOrDefault<ICVehiclePlateType>(x => x.Description == "Public Bus" && x.ICID == ICID);
                    vehicleSpecification = vehicleSpecificationList.FirstOrDefault<ICVehicleSpecificationn>(x => x.Description == "FRONT SENSORS" && x.ICID == ICID);
                    vehicleUses = vehicleUsesList.FirstOrDefault<ICVehicleUses>(x => x.Description == "COMMERCIAL" && x.ICID == ICID);
                    violation = violationList.FirstOrDefault<ICViolation>(x => x.Description == "Infringing rules by using strong lights" && x.ICID == ICID);
                    _logger.LogInformation("Retrieving matching record from Lists by Passing Value and Malath ICID Completed");

                    MalathComprehensiveQuoteCommand malathCMPRequest = new MalathComprehensiveQuoteCommand();

                    malathCMPRequest.RequestReferenceNo = Guid.NewGuid();
                    malathCMPRequest.ProductTypeCode = 2;
                    malathCMPRequest.VehicleAgencyRepair = "1";
                    malathCMPRequest.PolicyEffectiveDate = Convert.ToDateTime("2022-01-03");
                    malathCMPRequest.InsuredIdTypeCode = 1;
                    malathCMPRequest.InsuredId = 1086517141;
                    malathCMPRequest.InsuredIDExpiryDate = Convert.ToDateTime("2023-10-15");
                    malathCMPRequest.InsuredBirthDate = "01-01-1410";
                    malathCMPRequest.InsuredGenderCode = "M";
                    malathCMPRequest.InsuredNationalityCode = "113";
                    malathCMPRequest.InsuredFirstNameAr = "شهدي";
                    malathCMPRequest.InsuredMiddleNameAr = "محمد";
                    malathCMPRequest.InsuredLastNameAr = "الشيمي";
                    malathCMPRequest.InsuredFirstNameEn = "Shohdy";
                    malathCMPRequest.InsuredMiddleNameEn = "Mohamed";
                    malathCMPRequest.InsuredLastNameEn = "ElSheemy";
                    malathCMPRequest.InsuredSocialStatusCode = "2";
                    malathCMPRequest.InsuredEducationCode = 1 /*"M"*/;
                    malathCMPRequest.InsuredOccupationCode = "2214061";
                    malathCMPRequest.InsuredChildrenBelow16Years = 2;
                    malathCMPRequest.InsuredBusinessCity = "الرياض";
                    malathCMPRequest.InsuredAddressCity = "الرياض";
                    malathCMPRequest.VehicleValue = 39000;
                    malathCMPRequest.VehicleIdTypeCode = 2;
                    malathCMPRequest.VehiclePlateNumber = 5440;
                    malathCMPRequest.VehiclePlateText1 = "ب";
                    malathCMPRequest.VehiclePlateText2 = "ر";
                    malathCMPRequest.VehiclePlateText3 = "ص";
                    malathCMPRequest.VehicleChassisNumber = "9A1ZE5E34AF747397";
                    malathCMPRequest.VehicleId = 289912752;
                    malathCMPRequest.VehicleOwnerTransfer = false;
                    malathCMPRequest.VehicleOwnerId = 1086517141;
                    malathCMPRequest.VehiclePlateTypeCode = "1";
                    malathCMPRequest.VehicleModelYear = 2021;
                    malathCMPRequest.VehicleMaker = "شيفورلية";
                    malathCMPRequest.VehicleModel = "ماليبو";
                    malathCMPRequest.VehicleColor = "ابيض";
                    malathCMPRequest.VehicleRegExpiryDate = "22-11-1437";
                    malathCMPRequest.VehicleCylinders = 6;
                    malathCMPRequest.VehicleWeight = 570;
                    malathCMPRequest.VehicleSeating = 5;
                    malathCMPRequest.VehicleUseCode = 1;
                    malathCMPRequest.VehicleMileage = 10205;
                    malathCMPRequest.VehicleTransmissionTypeCode = "A";
                    malathCMPRequest.VehicleMileageExpectedAnnualCode = 49999;
                    malathCMPRequest.VehicleAxleWeightCode = 19999;
                    malathCMPRequest.VehicleEngineSizeCode = 1999;
                    malathCMPRequest.VehicleOvernightParkingLocationCode = 1 /*"R"*/;
                    malathCMPRequest.VehicleModification = true;
                    malathCMPRequest.VehicleModificationDetails = "مزود سرعة";
                    malathCMPRequest.NCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*3*/;
                    malathCMPRequest.NCDReference = nCDEligibilityResponse.ncdReference /*"NCD24081726802"*/;

                    //VehicleSpecification
                    malathCMPRequest.VehicleSpecifications = new List<WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.VehicleSpecification>();
                    var vehSpec1 = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.VehicleSpecification()
                    {
                        VehicleSpecificationCode = 1
                    };
                    malathCMPRequest.VehicleSpecifications.Add(vehSpec1);
                    var vehSpec2 = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.VehicleSpecification()
                    {
                        VehicleSpecificationCode = 2
                    };
                    malathCMPRequest.VehicleSpecifications.Add(vehSpec2);
                    var vehSpec3 = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.VehicleSpecification()
                    {
                        VehicleSpecificationCode = 3
                    };
                    malathCMPRequest.VehicleSpecifications.Add(vehSpec3);

                    //Driver1
                    malathCMPRequest.Drivers = new List<WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.Driver>();
                    var driver1 = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.Driver()
                    {
                        DriverTypeCode = 1,
                        DriverId = 1086517141,
                        DriverIdTypeCode = 1,
                        DriverBirthDate = "01-01-1410",
                        DriverGenderCode = "M",
                        DriverBirthDateG = Convert.ToDateTime("1982-01-01"),
                        DriverNationalityCode = "113",
                        DriverFirstNameAr = "شهدي",
                        DriverMiddleNameAr = "محمد",
                        DriverLastNameAr = "الشيمي",
                        DriverFirstNameEn = "Shohdy",
                        DriverMiddleNameEn = "Mohamed",
                        DriverLastNameEn = "ElSheemy",
                        DriverSocialStatusCode = "2",
                        DriverDrivingPercentage = 50,
                        DriverEducationCode = "M",
                        DriverOccupationCode = "2214061",
                        DriverChildrenBelow16Years = 2,
                        DriverAddressCity = "الرياض",
                        DriverBusinessCity = "الرياض",
                        DriverNOALast5Years = 0,
                        DriverNOCLast5Years = 0,
                        DriverNCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*3*/,
                        DriverNCDReference = nCDEligibilityResponse.ncdReference /*"NCD24081726802"*/,
                        DriverRelationship = null
                    };

                    //DriverMedicalCondition
                    driver1.DriverMedicalConditionCode = new List<int>();
                    driver1.DriverMedicalConditionCode.Add(2);
                    driver1.DriverMedicalConditionCode.Add(4);

                    //DriverLicense
                    driver1.DriverLicenses = new List<WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.DriverLicense>();
                    string[] strDate = "22-05-1446".Split("-");
                    string stringDate = strDate[0] + "-" + strDate[1] + "-" + strDate[2];

                    var driverLic = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.DriverLicense()
                    {
                        LicenseCountryCode = 113,
                        LicenseNumberYears = 7,
                        DriverLicenseTypeCode = "1",
                        //DriverLicenseExpiryDate = Convert.ToDateTime("22-05-1446");
                        //DriverLicenseExpiryDate = Convert.ToDateTime(stringDate)
                        DriverLicenseExpiryDate = "22-05-1446"
                    };

                    driver1.DriverLicenses.Add(driverLic);

                    driverLic.LicenseCountryCode = 102;
                    driverLic.LicenseNumberYears = 7;
                    driverLic.DriverLicenseTypeCode = "1";
                    //driverLic.DriverLicenseExpiryDate = Convert.ToDateTime("22-05-1446");
                    //driverLic.DriverLicenseExpiryDate = Convert.ToDateTime(stringDate);
                    driverLic.DriverLicenseExpiryDate = "22-05-1446";
                    driver1.DriverLicenses.Add(driverLic);

                    //DriverViolation
                    driver1.DriverViolations = new List<WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.DriverViolation>();
                    var driverViolations = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.DriverViolation()
                    { ViolationCode = 1 };
                    driver1.DriverViolations.Add(driverViolations);

                    driverViolations.ViolationCode = 2;
                    driver1.DriverViolations.Add(driverViolations);

                    malathCMPRequest.Drivers.Add(driver1);

                    //Driver2
                    var driver2 = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.Driver()
                    {
                        DriverTypeCode = 1,
                        DriverId = 1086517141,
                        DriverIdTypeCode = 1,
                        DriverBirthDate = "01-01-1410",
                        DriverGenderCode = "M",
                        DriverBirthDateG = Convert.ToDateTime("1982-01-01"),
                        DriverNationalityCode = "113",
                        DriverFirstNameAr = "شهدي",
                        DriverMiddleNameAr = "محمد",
                        DriverLastNameAr = "الشيمي",
                        DriverFirstNameEn = "Shohdy",
                        DriverMiddleNameEn = "Mohamed",
                        DriverLastNameEn = "ElSheemy",
                        DriverSocialStatusCode = "2",
                        DriverDrivingPercentage = 50,
                        DriverEducationCode = "M",
                        DriverOccupationCode = "2214061",
                        DriverChildrenBelow16Years = 2,
                        DriverAddressCity = "الرياض",
                        DriverBusinessCity = "الرياض",
                        DriverNOALast5Years = 0,
                        DriverNOCLast5Years = 0,
                        DriverNCDFreeYears = nCDEligibilityResponse.ncdFreeYears /*3*/,
                        DriverNCDReference = nCDEligibilityResponse.ncdReference /*"NCD24081726802"*/,
                        DriverRelationship = "WIFE"
                    };

                    //DriverMedicalCondition
                    driver2.DriverMedicalConditionCode = new List<int>();
                    driver2.DriverMedicalConditionCode.Add(2);
                    driver2.DriverMedicalConditionCode.Add(4);

                    //DriverLicense
                    driver2.DriverLicenses = new List<WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.DriverLicense>();
                    var driverL = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.DriverLicense()
                    {
                        LicenseCountryCode = 113,
                        LicenseNumberYears = 7,
                        DriverLicenseTypeCode = "1",
                        //DriverLicenseExpiryDate = Convert.ToDateTime("22-05-1446")
                        //DriverLicenseExpiryDate = Convert.ToDateTime(stringDate)
                        DriverLicenseExpiryDate = "22-05-1446"
                    };
                    driver1.DriverLicenses.Add(driverLic);

                    driverL.LicenseCountryCode = 102;
                    driverL.LicenseNumberYears = 7;
                    driverL.DriverLicenseTypeCode = "1";
                    //driverL.DriverLicenseExpiryDate = Convert.ToDateTime("22-05-1446");
                    //driverL.DriverLicenseExpiryDate = Convert.ToDateTime(stringDate);
                    driverL.DriverLicenseExpiryDate = "22-05-1446";
                    driver2.DriverLicenses.Add(driverLic);

                    //DriverViolation
                    driver2.DriverViolations = new List<WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.DriverViolation>();
                    var driverViol = new WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote.DriverViolation()
                    { ViolationCode = 1 };
                    driver2.DriverViolations.Add(driverViol);

                    driverViol.ViolationCode = 2;
                    driver2.DriverViolations.Add(driverViol);

                    malathCMPRequest.Drivers.Add(driver2);


                    var responseMalathCMP = await _mediator.Send(malathCMPRequest);
                    if (responseMalathCMP.Data == null)
                    {
                        goto ListQuotes;
                    }
                    else
                    {
                        if (responseMalathCMP.Data.Error != null)
                        {
                            if (responseMalathCMP.Data.Error.Count >= 1)
                            {
                                _logger.LogInformation(responseMalathCMP.Data.Error.ToList().ToString());
                                goto ListQuotes;
                            }
                        }
                    }


                    Quote quoteCMP_Malath = new Quote();
                    var premiumDetailsList = new List<PremiumDetails>();
                    for (int i = 0; i < responseMalathCMP.Data.Products.Count; i++)
                    {
                        List<AdditionalCovers> additionalMalathCMPCovers = new List<AdditionalCovers>();
                        List<PremiumBreakdown> premiumBreakdownsList = new List<PremiumBreakdown>();
                        List<DiscountBreakdown> discountBreakdownsList = new List<DiscountBreakdown>();
                        for (int j = 0; j < responseMalathCMP.Data.Products[i].PriceDetails.Count; j++)
                        {
                            decimal percetage = responseMalathCMP.Data.Products[i].PriceDetails[j].PercentageValue ?? 0;
                            var premiumBreakdownDetail = new PremiumBreakdown()
                            {
                                TypeCode = responseMalathCMP.Data.Products[i].PriceDetails[j].PriceTypeCode,
                                Amount = Double.Parse(responseMalathCMP.Data.Products[i].PriceDetails[j].PriceValue.ToString()),
                                Percentage = Double.Parse(percetage.ToString())
                            };
                            premiumBreakdownsList.Add(premiumBreakdownDetail);
                        }

                        for (int k = 0; k < responseMalathCMP.Data.Products[i].Covers.Count; k++)
                        {
                            var cover = new AdditionalCovers()
                            {
                                FeatureCode = responseMalathCMP.Data.Products[i].Covers[k].CoverCode.ToString(),
                                FeatureDesc = responseMalathCMP.Data.Products[i].Covers[k].CoverNameEn,
                                FeatureAmount = Double.Parse(responseMalathCMP.Data.Products[i].Covers[k].CoverPrice.ToString()),
                                TaxAmount = 0.0,
                            };
                            additionalMalathCMPCovers.Add(cover);
                        }

                        var premiumDetail = new PremiumDetails()
                        {
                            deductable = 0,
                            GrossPremium = 0.00,
                            TotalDiscount = 0.00,
                            PremiumExcVat = 0.00,
                            TotalTax = 0.00,
                            TotalPremium = Double.Parse(responseMalathCMP.Data.Products[i].ProductPrice.ToString()),
                            additionalCovers = additionalMalathCMPCovers,
                            discountBreakdowns = discountBreakdownsList,
                            premiumBreakdown = premiumBreakdownsList
                        };
                        premiumDetailsList.Add(premiumDetail);
                    }

                    quoteCMP_Malath.ICID = insuranceCompanies.Data[2].Id;
                    quoteCMP_Malath.vehicleId = request.VehicleID;
                    quoteCMP_Malath.QuoteRequestRefNo = responseMalathCMP.Data.RequestReferenceNo.ToString();
                    quoteCMP_Malath.QuotationNo = responseMalathCMP.Data.QuotationNo;
                    quoteCMP_Malath.product = "CMP";
                    quoteCMP_Malath.companyName = insuranceCompanies.Data[2].InsuranceCompanyName; //"Malath";
                    quoteCMP_Malath.premiumDetails = premiumDetailsList;

                    listQuotes.Quote.Add(quoteCMP_Malath);
                    _logger.LogInformation("Comprehensive Quote  Completed");
                    //CMP Malath Ends
                    #endregion CMP Malath
            }
            _logger.LogInformation("QuoteResponse Handle Completed");
        ListQuotes:
            return new Response<RedisQuoteResponse>(listQuotes);
        }
    }
}
