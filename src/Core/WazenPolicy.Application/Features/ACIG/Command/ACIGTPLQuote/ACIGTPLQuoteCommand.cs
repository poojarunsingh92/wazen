using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.ACIG.Command.ACIGTPLQuote
{
    public class ACIGTPLQuoteCommand : IRequest<Response<ACIGTPLQuoteResponse>>
    {
        public int UserId { get; set; } = 755;
        public string UserName { get; set; } = "Wazen";
        public string QuoteRequestRefNo { get; set; } = "UTTest";
        public string Product { get; set; } = "TPL";
        public string PolicyEffectiveDate { get; set; } = DateTime.Now.AddDays(1).ToString();
        public string PromoCode { get; set; } = null;
        public InsuredInfo InsuredInfo { get; set; } = new InsuredInfo();
        public VehicleInformation VehicleInfo { get; set; } = new VehicleInformation();
        public List<DriverInformation> DriverInfo { get; set; } = new List<DriverInformation>() { new DriverInformation() };
        public string Source { get; set; }
    }
    public class InsuredInfo
    {
        public int IdTypeCode { get; set; } = 2;
        public string IdNo { get; set; } = "2065564035";
        public string NameEng { get; set; } = "Ameen Al rafie";
        public string NameAr { get; set; } = "أمين الرافعي";
        public string IdExpiryDate { get; set; } = "01-1442";
        public string IdRegistrationCityCode { get; set; } = "7";
        public string BirthDateG { get; set; } = "01-01-1983";
        public string BirthDateH { get; set; } = "01-01-1420";
        public int GenderCode { get; set; } = 2;
        public int MaritalStatusCode { get; set; } = 2;
        public int OccupationCode { get; set; } = 1;
        public int EducationCode { get; set; } = 1;
        public int NationalityCode { get; set; } = 90;
        public int ChildrenBelow16 { get; set; } = 0;
        public string MobileNo { get; set; } = "580235141";
        public string EmailId { get; set; } = "gajula.suresh@amtpl.com";
        public int NcdYears { get; set; } = 5;
        public string NcdReference { get; set; } = "NCD12589";
        public int NoOfAccidents { get; set; } = 0;
        public int AccidentsLiability { get; set; } = 0;
        public Boolean IsTransferOfOwnership { get; set; } = false;
        public /*int*/ string OwnerId { get; set; } = null;
        public Address Address { get; set; } = new Address();
        public AccidentDetail AccidentDetails { get; set; }

    }

    public class Address
    {
        public string Street { get; set; } = "Makkah";
        public string District { get; set; } = "Jeddah";
        public string City { get; set; } = "Riyadh";
        public int CityCode { get; set; } = 34330;
        public int PostalCode { get; set; } = 58266;
        public int BuildingNumber { get; set; } = 2569;
        public int AdditionalNumber { get; set; } = 5269;
        public int UnitNumber { get; set; } = 1;
        public string LanguageCode { get; set; } = null;
    }

    public class AccidentDetail
    {
        public string? accidentDate { get; set; } = null;
        public string? carModel { get; set; } = null;
        public string? carType { get; set; } = null;
        public string? caseNumber { get; set; } = null;
        public string? causeOfAccident { get; set; } = null;
        public string? cityName { get; set; } = null;
        public string? damageParts { get; set; } = null;
        public int? driverAge { get; set; } = null;
        public string? driverIdNumber { get; set; } = null;
        public decimal? estimatedAmount { get; set; } = 0.0M;
        public int liability { get; set; } = 0;
        public string? sequenceNumber { get; set; } = null;
    }

    public class VehicleInformation
    {
        public int VehicleIdTypeCode { get; set; } = 1;
        public int RepairTypeCode { get; set; } = 2;
        public int BodyTypeCode { get; set; } = 0;
        public string ChassisNumber { get; set; } = "MALC741B0LM177285";
        public int ColorCode { get; set; } = 1;
        public string ColorDesc { get; set; } = "White";
        public string SequenceNumber { get; set; } = "256968468";
        public string CustomNumber { get; set; } = null;
        public int? Cylinders { get; set; } = 0;
        public int? DrivingCityCode { get; set; } = 0;
        public string? EngineSize { get; set; } = null;
        public int? ExpectedAnnualMileage { get; set; } = 0;
        public int VehicleValue { get; set; } = 52565;
        public string MakeCode { get; set; } = "11";
        public string MakeCodeELM { get; set; } = "11";
        public string MakeDesc { get; set; } = "Toyota";
        public string ModelCode { get; set; } = "45";
        public string ModelCodeELM { get; set; } = "45";
        public string ModelDesc { get; set; } = "Fortuner";
        public string ManufactureYear { get; set; } = "2015";
        public string PlateTypeCode { get; set; } = "1";
        public string PlateNumber { get; set; } = "8296";
        public string FirstPlateLetter { get; set; } = "ص";
        public string SecondPlateLetter { get; set; } = "ل";
        public string ThirdPlateLetter { get; set; } = "ك";
        public int NightParkingCode { get; set; } = 1;
        public string RegistrationCityCode { get; set; } = "7";
        public string RegistrationExpiryDate { get; set; } = "11-01-1445";
        public int SeatsCapacity { get; set; } = 0;
        public int TransmissionTypeCode { get; set; } = 1;
        public int UsagePurposeCode { get; set; } = 1;
        public int Weight { get; set; } = 0;
        public int Automatic_Braking_System { get; set; } = 2;
        public int Cruise_Control { get; set; } = 2;
        public int Adaptive_Cruise_Control { get; set; } = 2;
        public int Rear_Parking_Sensors { get; set; } = 2;
        public int Front_Sensors { get; set; } = 2;
        public int Front_Camera { get; set; } = 2;
        public int Rear_Camera { get; set; } = 2;
        public int Degree_Camera_360 { get; set; } = 2;
        public int Fire_Extinguisher { get; set; } = 2;
        public int Modifications_In_The_car { get; set; } = 1;
        public string Modifications_In_The_Car_Desc { get; set; } = "vehicle";
        public int? Vehicle_Axle_Weight { get; set; } = null;
        public int Antilock_Braking_System { get; set; } = 2;
    }
    public class DriverInformation
    {
        public Boolean IsPolicyHolder { get; set; } = true;
        public Boolean IsMaindriver { get; set; } = true;
        public int IdTypeCode { get; set; } = 1;
        public string IdNo { get; set; } = "1569854789";
        public string NameEng { get; set; } = "Salman bin Nasser bin Hussein Al Sultan";
        public string NameAr { get; set; } = "سلمان بن ناصر بن حسين السلطان";
        public string? BirthDateG { get; set; } = null;
        public string BirthDateH { get; set; } = "01-14-1420";
        public int DriverAge { get; set; } = 0;
        public int GenderCode { get; set; } = 1;
        public int MaritalStatusCode { get; set; } = 1;
        public int OccupationCode { get; set; } = 1;
        public int EducationCode { get; set; } = 1;
        public int NationalityCode { get; set; } = 90;
        public int ChildrenBelow16 { get; set; } = 0;
        public int RelationWithInsuredCode { get; set; } = 1;
        public int HealthConditionsCode { get; set; } = 1;
        public string? MobileNo { get; set; } = null;
        public string? EmailId { get; set; } = null;
        public int LicenseTypeCode { get; set; } = 0;
        public string LicenseExpiryDate { get; set; } = "01-01-1442";
        public int DrivingExpYears { get; set; } = 5;
        public int NoOfYearsSaudiLicenseHeld { get; set; } = 8;
        public int NcdYears { get; set; } = 0;
        public string? NcdReference { get; set; } = null;
        public int VehicleUsagePercentage { get; set; } = 100;
        public string? WorkCompanyName { get; set; } = null;
        public int? TrafficViolationsCode { get; set; } = null;
        public int? CityCode { get; set; } = null;
        public string? HomeAddress { get; set; } = null;
        public string? OfficeAddress { get; set; } = null;
        public List<CountriesDrivingLicenses> CountriesDrivingLicense { get; set; } = new List<CountriesDrivingLicenses>() { new CountriesDrivingLicenses(){ LicenseCountryCode=167, LicenseYears=8 }, new CountriesDrivingLicenses(){ LicenseCountryCode=171, LicenseYears=25 } };
    }
    public class CountriesDrivingLicenses
    {
        public int LicenseCountryCode { get; set; }
        public int LicenseYears { get; set; }
    }
}
