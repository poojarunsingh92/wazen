using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Walaa.Commands.WalaaComprehensiveQuote
{
    public class WalaaComprehensiveQuoteCommand : IRequest<Response<WalaaComprehensiveQuoteResponse>>
    {
        //Comprehensive
        public string ProviderCompanyCode { get; set; } = "25";
        public string ProviderCompanyName { get; set; } = "WZAN Broker";
        public string ReferenceId { get; set; } = "dab92f1aae87493";
        public int ProductTypeCode { get; set; } = 2;
        public DateTime PolicyEffectiveDate { get; set; } = DateTime.Now.AddDays(1);
        public string PostCode { get; set; } = "13318";
        public int InsuredIdTypeCode { get; set; } = 1;
        public /*int*/ string InsuredId { get; set; } = "2198197184";
        public string InsuredBirthDateH { get; set; } = "23-11-1404";
        public string InsuredBirthDateG { get; set; } = "07-05-1994";
        public string InsuredGenderCode { get; set; } = "M";
        public string InsuredNationalityCode { get; set; } = "113";
        public string InsuredIdIssuePlaceCode { get; set; } = "2";
        public string InsuredIdIssuePlace { get; set; } = "جده";
        public string InsuredFirstNameAr { get; set; } = "سيش";
        public string InsuredMiddleNameAr { get; set; } = "";
        public string InsuredLastNameAr { get; set; } = "سيلادوراي";
        public string InsuredFirstNameEn { get; set; } = "SUHESH";
        public string InsuredMiddleNameEn { get; set; } = "";
        public string InsuredLastNameEn { get; set; } = "SELLADURAI";
        public string InsuredSocialStatusCode { get; set; } = "2";
        public string InsuredOccupationCode { get; set; } = "G";
        public int InsuredEducationCode { get; set; } = 5;
        public int InsuredChildrenBelow16Years { get; set; } = 0;
        public string InsuredWorkCityCode { get; set; } = "2";
        public string InsuredWorkCity { get; set; } = "جده";
        public string InsuredCityCode { get; set; } = "2";
        public string InsuredCity { get; set; } = "جده";
        public int VehicleIdTypeCode { get; set; } = 2;
        public int VehicleId { get; set; } = 753406110;
        public int VehiclePlateNumber { get; set; } = 2354;
        public string VehiclePlateText1 { get; set; } = "ر";
        public string VehiclePlateText2 { get; set; } = "ي";
        public string VehiclePlateText3 { get; set; } = "ح";
        public string VehicleChassisNumber { get; set; } = "CASSIS7879754578";
        public string VehicleOwnerName { get; set; } = "";
        public /*int*/ string VehicleOwnerId { get; set; } = "2198197184";
        public string VehiclePlateTypeCode { get; set; } = null;
        public int VehicleModelYear { get; set; } = 2016;
        public string VehicleModelCode { get; set; } = "23";
        public string VehicleModel { get; set; } = "تورس سيدان";
        public string VehicleMakerCode { get; set; } = "21";
        public string VehicleMaker { get; set; } = "فورد";
        public string VehicleMajorColorCode { get; set; } = "2";
        public string VehicleMajorColor { get; set; } = "أسود";
        public string VehicleBodyTypeCode { get; set; } = "5";
        public string VehicleRegPlaceCode { get; set; } = "2";
        public string VehicleRegPlace { get; set; } = "جده";
        public string VehicleRegExpiryDate { get; set; } = "20-07-1442";
        public int VehicleCylinders { get; set; } = 6;
        public int VehicleWeight { get; set; } = 1696;
        public int VehicleLoad { get; set; } = 5;
        public Boolean VehicleOwnerTransfer { get; set; } = false;
        public int VehicleValue { get; set; } = 90000;
        public int VehicleEngineSizeCode { get; set; } = 0;
        public int VehicleUseCode { get; set; } = 1;
        public /*int*/string VehicleMileage { get; set; } = null;
        public int VehicleTransmissionTypeCode { get; set; } = 1;
        public int VehicleMileageExpectedAnnualCode { get; set; } = 1;
        public /*int*/string VehicleAxleWeightCode { get; set; } = null;
        public int VehicleOvernightParkingLocationCode { get; set; } = 1;
        public string VehicleModificationDetails { get; set; } = "";
        public int NCDFreeYears { get; set; } = 0;
        public string NCDReference { get; set; } = "NCD0403217143";
        public List<Driver> Drivers { get; set; } = new List<Driver>() { new Driver() };
        public List<VehicleSpecification> VehicleSpecifications { get; set; } = new List<VehicleSpecification>() { new VehicleSpecification() { VehicleSpecificationCode = "1" }, new VehicleSpecification() { VehicleSpecificationCode = "2" } };
    }

    public class Driver
    {
        public int DriverTypeCode { get; set; } = 1;
        public /*int*/string DriverId { get; set; } = "2198197184";
        public int DriverIdTypeCode { get; set; } = 1;
        public string DriverNationalityCode { get; set; } = "113";
        public string DriverGenderCode { get; set; } = "M";
        public /*DateTime*/ string DriverBirthDateH { get; set; } = "23-11-1404"; //= new DateTime("15-04-1394");
        public /*DateTime*/ string DriverBirthDateG { get; set; } = "1984-08-20"; //= new DateTime("1974-05-07");
        public string DriverFirstNameAr { get; set; } = "سيش";
        public string DriverMiddleNameAr { get; set; } = "";
        public string DriverLastNameAr { get; set; } = "سيلادوراي";
        public string DriverFirstNameEn { get; set; } = "SUHESH";
        public string DriverMiddleNameEn { get; set; } = "";
        public string DriverLastNameEn { get; set; } = "SELLADURAI";
        public string DriverSocialStatusCode { get; set; } = "2";
        public string DriverOccupationCode { get; set; } = "G";
        public int DriverDrivingPercentage { get; set; } = 100;
        public int DriverEducationCode { get; set; } = 5;
        public int DriverMedicalConditionCode { get; set; } = 1;
        public int DriverChildrenBelow16Years { get; set; } = 0;
        public string DriverHomeCityCode { get; set; } = "2";
        public string DriverHomeCity { get; set; } = "جده";
        public string DriverWorkCityCode { get; set; } = "2";
        public string DriverWorkCity { get; set; } = "جده";
        public int DriverNCDFreeYears { get; set; } = 0;
        public string DriverNCDReference { get; set; } = "NCD0403217143";
        public int DriverRelationship { get; set; } = 1;
        public List<DriverLicense> DriverLicenses { get; set; } = new List<DriverLicense>() { new DriverLicense() };
        public List<DriverViolation> DriverViolations { get; set; } = new List<DriverViolation>() { new DriverViolation() { ViolationCode = 1 }, new DriverViolation() { ViolationCode = 2 } };
        public List<Accident> Accidents { get; set; } = new List<Accident>() { new Accident() { CaseNumber = "ABCD123", AccidentDate = DateTime.Parse("2017-01-15T13:57:13"), Liability = 100 }, new Accident() { CaseNumber = "ABCD1234", AccidentDate = DateTime.Parse("2018-01-15T13:57:13"), Liability = 95 } };
    }

    public class DriverLicense
    {
        public int LicenseCountryCode { get; set; } = 113;
        public int LicenseNumberYears { get; set; } = 18;
        public string DriverLicenseTypeCode { get; set; } = "3";
        public string DriverLicenseExpiryDate { get; set; } = "04-06-1449";
    }

    public class DriverViolation
    {
        public int ViolationCode { get; set; }
    }

    public class Accident
    {
        public string CaseNumber { get; set; } = null;
        public DateTime AccidentDate { get; set; }
        public int Liability { get; set; } = 0;
    }

    public class VehicleSpecification
    {
        public string VehicleSpecificationCode { get; set; }
    }
}
