using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Walaa.Commands.WalaaTPLQuote
{
    public class WalaaTPLQuoteCommand : IRequest<Response<WalaaTPLQuoteResponse>>
    {
        //TPL
        public string ProviderCompanyCode { get; set; } = "25";
        public string ProviderCompanyName { get; set; } = "WZAN Broker";
        public string ReferenceId { get; set; } = "12453";
        public int ProductTypeCode { get; set; } = 1;
        public DateTime PolicyEffectiveDate { get; set; } = DateTime.Now.AddDays(1);
        public string PostCode { get; set; } = "13318";
        public int InsuredIdTypeCode { get; set; } = 1;
        public int InsuredId { get; set; } = 1026055705;
        public string InsuredBirthDateH { get; set; } = "15-04-1394";
        public string InsuredBirthDateG { get; set; } = "07-05-1994";
        public string InsuredGenderCode { get; set; } = "M";
        public string InsuredNationalityCode { get; set; } = "113";
        public string InsuredIdIssuePlaceCode { get; set; } = "1";
        public string InsuredIdIssuePlace { get; set; } = "";
        public string InsuredFirstNameAr { get; set; } = "سيش";
        public string InsuredMiddleNameAr { get; set; } = "";
        public string InsuredLastNameAr { get; set; } = "سيلادوراي";
        public string InsuredFirstNameEn { get; set; } = "SUHESH";
        public string InsuredMiddleNameEn { get; set; } = "";
        public string InsuredLastNameEn { get; set; } = "SELLADURAI";
        public string InsuredSocialStatusCode { get; set; } = "2";
        public string InsuredOccupationCode { get; set; } = "G";
        public string InsuredOccupation { get; set; } = "قطاع حكومي";
        public int InsuredEducationCode { get; set; } = 5;
        public int InsuredChildrenBelow16Years { get; set; } = 0;
        public string InsuredWorkCityCode { get; set; } = "1";
        public string InsuredWorkCity { get; set; } = "الرياض";
        public string InsuredCityCode { get; set; } = "1";
        public string InsuredCity { get; set; } = "الرياض";
        public int VehicleIdTypeCode { get; set; } = 1;
        public int VehicleId { get; set; } = 535634510;
        public int VehiclePlateNumber { get; set; } = 3037;
        public string VehiclePlateText1 { get; set; } = "ر";
        public string VehiclePlateText2 { get; set; } = "ي";
        public string VehiclePlateText3 { get; set; } = "ح";
        public string VehicleChassisNumber { get; set; } = "2FMGK5B82FBA12551";
        public string VehicleOwnerName { get; set; } = "فهد عبدالعزيز محمد  الداود";
        public int VehicleOwnerId { get; set; } = 1026055705;
        public string VehiclePlateTypeCode { get; set; } = "1";
        public int VehicleModelYear { get; set; } = 2015;
        public string VehicleModelCode { get; set; } = "55";
        public string VehicleModel { get; set; } = "فليكس";
        public string VehicleMakerCode { get; set; } = "21";
        public string VehicleMaker { get; set; } = "فورد";
        public string VehicleMajorColorCode { get; set; } = "2";
        public string VehicleMajorColor { get; set; } = "أسود";
        public string VehicleBodyTypeCode { get; set; } = "5";
        public string VehicleRegPlaceCode { get; set; } = "1";
        public string VehicleRegPlace { get; set; } = "الرياض";
        public string VehicleRegExpiryDate { get; set; } = "09-10-1443";
        public int VehicleCylinders { get; set; } = 6;
        public int VehicleWeight { get; set; } = 2248;
        public int VehicleLoad { get; set; } = 7;
        public Boolean VehicleOwnerTransfer { get; set; } = false;
        public int VehicleValue { get; set; } = 5000;
        public int? DeductibleValue { get; set; } = 0;
        public Boolean VehicleAgencyRepair { get; set; } = false;
        public int VehicleEngineSizeCode { get; set; } = 1;
        public int VehicleUseCode { get; set; } = 1;
        public int VehicleMileage { get; set; } = 0;
        public int VehicleTransmissionTypeCode { get; set; } = 2;
        public int VehicleMileageExpectedAnnualCode { get; set; } = 1;
        public int VehicleAxleWeightCode { get; set; } = 0;
        public string Accidents { get; set; } = null;
        public int VehicleOvernightParkingLocationCode { get; set; } = 1;
        public string VehicleModificationDetails { get; set; } = "";
        public int NCDFreeYears { get; set; } = 11;
        public string NCDReference { get; set; } = "NCD1102217343";
        public List<Driver> Drivers { get; set; } = new List<Driver>() { new Driver() };
        public List<VehicleSpecification> VehicleSpecifications { get; set; } = new List<VehicleSpecification>() { new VehicleSpecification() { VehicleSpecificationCode = "1" }, new VehicleSpecification() { VehicleSpecificationCode = "2" } };
    }

    public class Driver
    {
        public int DriverTypeCode { get; set; } = 1;
        public int DriverId { get; set; } = 1026055705;
        public int DriverIdTypeCode { get; set; } = 1;
        public string DriverNationalityCode { get; set; } = "113";
        public string DriverGenderCode { get; set; } = "M";
        public /*DateTime*/ string DriverBirthDateH { get; set; } = "15-04-1394"; //= new DateTime("15-04-1394");
        public /*DateTime*/ string DriverBirthDateG { get; set; } = "1974-05-07"; //= new DateTime("1974-05-07");
        public string DriverFirstNameAr { get; set; } = "فهد";
        public string DriverMiddleNameAr { get; set; } = "عبدالعزيز";
        public string DriverLastNameAr { get; set; } = "محمد الداود";
        public string DriverFirstNameEn { get; set; } = "FAHAD";
        public string DriverMiddleNameEn { get; set; } = "ABDULAZIZ";
        public string DriverLastNameEn { get; set; } = "MOHAMMED ALDAWOOD";
        public string DriverSocialStatusCode { get; set; } = "2";
        public string DriverOccupationCode { get; set; } = "G";
        public string DriverOccupation { get; set; } = "قطاع حكومي";
        public int DriverDrivingPercentage { get; set; } = 100;
        public int DriverEducationCode { get; set; } = 5;
        public int DriverMedicalConditionCode { get; set; } = 1;
        public int DriverChildrenBelow16Years { get; set; } = 0;
        public string DriverHomeCityCode { get; set; } = "1";
        public string DriverHomeCity { get; set; } = "الرياض";
        public string DriverWorkCityCode { get; set; } = "1";
        public string DriverWorkCity { get; set; } = "الرياض";
        public int DriverNCDFreeYears { get; set; } = 11;
        public string DriverNCDReference { get; set; } = "NCD1102217343";
        public int DriverRelationship { get; set; } = 0;
        public List<DriverLicense> DriverLicenses { get; set; }
        public List<DriverViolation>? DriverViolations { get; set; }
        public List<Accident> Accidents { get; set; }

    }

    public class DriverLicense
    {
        public int LicenseCountryCode { get; set; } = 11;
        public int LicenseNumberYears { get; set; } = 2;
        public string DriverLicenseTypeCode { get; set; } = "3";
        public string DriverLicenseExpiryDate { get; set; } = "01-01-1449";
    }

    public class DriverViolation
    {
        public string/*?*/ ViolationCode { get; set; }/* = null;*/
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