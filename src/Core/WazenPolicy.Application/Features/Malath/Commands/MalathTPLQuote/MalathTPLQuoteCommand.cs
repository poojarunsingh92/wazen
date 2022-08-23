using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Malath.Commands.MalathTPLQuote
{
    public class MalathTPLQuoteCommand : IRequest<Response<MalathTPLQuoteResponse>>
    {
        public string RequestReferenceNo { get; set; } = "";
        public int ProductTypeCode { get; set; } = 1;
        public DateTime PolicyEffectiveDate { get; set; } = DateTime.Now.AddDays(1);
        public int InsuredIdTypeCode { get; set; } = 1;
        public /*int*/ string InsuredId { get; set; } = "1086517141";
        public DateTime InsuredIDExpiryDate { get; set; } = DateTime.Now.AddYears(1);
        public string InsuredBirthDate { get; set; } = "01-01-1410";
        public string InsuredGenderCode { get; set; } = "M";
        public string InsuredNationalityCode { get; set; } = "90";
        public string InsuredFirstNameAr { get; set; } = "شهدي";
        public string InsuredMiddleNameAr { get; set; } = "محمد";
        public string InsuredLastNameAr { get; set; } = "الشيمي";
        public string InsuredFirstNameEn { get; set; } = "Shohdy";
        public string InsuredMiddleNameEn { get; set; } = "Mohamed";
        public string InsuredLastNameEn { get; set; } = "ElSheemy";
        public string InsuredSocialStatusCode { get; set; } = "2";
        public /*int*/ string InsuredEducationCode { get; set; } = "M";
        public string InsuredOccupationCode { get; set; } = "2214061";
        public int InsuredChildrenBelow16Years { get; set; } = 2;
        public string InsuredBusinessCity { get; set; } = "الرياض";
        public string InsuredAddressCity { get; set; } = "الرياض";
        public int VehicleIdTypeCode { get; set; } = 2;
        public int VehiclePlateNumber { get; set; } = 5440;
        public string VehiclePlateText1 { get; set; } = "ب";
        public string VehiclePlateText2 { get; set; } = "ر";
        public string VehiclePlateText3 { get; set; } = "ص";
        public string VehicleChassisNumber { get; set; } = "9A1ZE5E34AF747397";
        public /*int*/ string VehicleId { get; set; } = "289912752";
        public Boolean VehicleOwnerTransfer { get; set; } = false;
        public string VehicleOwnerName { get; set; } = "شهدي محمد الشيمي";
        public int VehicleOwnerId { get; set; } = 1086517141;
        public string VehiclePlateTypeCode { get; set; } = "1";
        public int VehicleModelYear { get; set; } = 2021;
        public string VehicleMaker { get; set; } = "شيفورلية";
        public string VehicleModel { get; set; } = "ماليبو";
        public string VehicleColor { get; set; } = "ابيض";
        public string VehicleRegExpiryDate { get; set; } = "22-11-1437";
        public int VehicleCylinders { get; set; } = 6;
        public int VehicleWeight { get; set; } = 1570;
        public int VehicleSeating { get; set; } = 5;
        public int VehicleUseCode { get; set; } = 1;
        public int VehicleMileage { get; set; } = 10205;
        public string VehicleTransmissionTypeCode { get; set; } = "A";
        public int VehicleMileageExpectedAnnualCode { get; set; } = 49999;
        public int VehicleAxleWeightCode { get; set; } = 19999;
        public int VehicleEngineSizeCode { get; set; } = 1999;
        public /*int*/ string VehicleOvernightParkingLocationCode { get; set; } = "R";
        public Boolean VehicleModification { get; set; } = true;
        public string VehicleModificationDetails { get; set; } = "مزود سرعة";
        public List<VehicleSpecification> VehicleSpecifications { get; set; } = new List<VehicleSpecification>() { new VehicleSpecification() { VehicleSpecificationCode = 1 }, new VehicleSpecification() { VehicleSpecificationCode = 2 }, new VehicleSpecification() { VehicleSpecificationCode = 3 } };
        public int NCDFreeYears { get; set; } = 3;
        public string NCDReference { get; set; } = "NCD24081726802";
        public List<Drivers> Drivers { get; set; } = new List<Drivers>() {
            new Drivers()
            {
                DriverTypeCode=1,
                DriverId=1086517141,
                DriverIdTypeCode=1,
                DriverBirthDate="01-01-1410",
                DriverGenderCode="M",
                DriverBirthDateG= "1982-01-01",
                DriverNationalityCode="113",
                DriverFirstNameAr="شهدي",
                DriverMiddleNameAr="محمد",
                DriverLastNameAr="الشيمي",
                DriverFirstNameEn="Shohdy",
                DriverMiddleNameEn="Mohamed",
                DriverLastNameEn="ElSheemy",
                DriverSocialStatusCode="2",
                DriverDrivingPercentage=50,
                DriverEducationCode="M",
                DriverOccupationCode="2214061",
                DriverMedicalConditionCode = new List<int>(){2,4 },
                DriverChildrenBelow16Years=2,
                DriverAddressCity="الرياض",
                DriverBusinessCity="الرياض",
                DriverNOALast5Years=0,
                DriverNOCLast5Years=0,
                DriverNCDFreeYears=3,
                DriverNCDReference="NCD24081726802",
                DriverLicenses= new List<DriverLicense>() {
                    new DriverLicense()
                    {
                        LicenseCountryCode=113,
                        LicenseNumberYears=7,
                        DriverLicenseTypeCode="1",
                        DriverLicenseExpiryDate="22-05-1446"
                    },
                    new DriverLicense()
                    {
                        LicenseCountryCode=102,
                        LicenseNumberYears=7,
                        DriverLicenseTypeCode="1",
                        DriverLicenseExpiryDate="22-05-1446"
                    }
                },
                DriverViolations= new List<DriverViolation>() {
                    new DriverViolation() { ViolationCode = 1 },
                    new DriverViolation() { ViolationCode = 2 }
                },
                DriverRelationship=null
            },
            new Drivers()
            {
                DriverTypeCode=2,
                DriverId=1086517142,
                DriverIdTypeCode=1,
                DriverBirthDate="01-01-1410",
                DriverGenderCode="F",
                DriverBirthDateG="1982-01-01",
                DriverNationalityCode="113",
                DriverFirstNameAr="مي",
                DriverMiddleNameAr="شهدي",
                DriverLastNameAr="الشيمي",
                DriverFirstNameEn="Mai",
                DriverMiddleNameEn="Shohdy",
                DriverLastNameEn="ElSheemy",
                DriverSocialStatusCode="2",
                DriverDrivingPercentage=50,
                DriverEducationCode="B",
                DriverOccupationCode="2214061",
                DriverMedicalConditionCode = new List<int>{2,4 },
                DriverChildrenBelow16Years=2,
                DriverAddressCity="الرياض",
                DriverBusinessCity="الرياض",
                DriverNOALast5Years=0,
                DriverNOCLast5Years=0,
                DriverNCDFreeYears=3,
                DriverNCDReference="NCD24081726802",
                DriverLicenses= new List<DriverLicense>() {
                    new DriverLicense()
                    {
                        LicenseCountryCode=113,
                        LicenseNumberYears=7,
                        DriverLicenseTypeCode="1",
                        DriverLicenseExpiryDate="22-05-1446"
                    },
                    new DriverLicense()
                    {
                        LicenseCountryCode=102,
                        LicenseNumberYears=7,
                        DriverLicenseTypeCode="1",
                        DriverLicenseExpiryDate="22-05-1446"
                    }
                },
                DriverViolations= new List<DriverViolation>() {
                    new DriverViolation() { ViolationCode = 1 },
                    new DriverViolation() { ViolationCode = 2 }
                },
                DriverRelationship="WIFE"
            }
        };
    }

    public class VehicleSpecification
    {
        public int VehicleSpecificationCode { get; set; }
    }

    public class Drivers
    {
        public int DriverTypeCode { get; set; }
        public int DriverId { get; set; }
        public int DriverIdTypeCode { get; set; }
        public string DriverBirthDate { get; set; }
        public string DriverGenderCode { get; set; }
        public /*DateTime*/string DriverBirthDateG { get; set; }
        public string DriverNationalityCode { get; set; }
        public string DriverFirstNameAr { get; set; }
        public string DriverMiddleNameAr { get; set; }
        public string DriverLastNameAr { get; set; }
        public string DriverFirstNameEn { get; set; }
        public string DriverMiddleNameEn { get; set; }
        public string DriverLastNameEn { get; set; }
        public string DriverSocialStatusCode { get; set; }
        public int DriverDrivingPercentage { get; set; }
        public /*int*/ string DriverEducationCode { get; set; }
        public string DriverOccupationCode { get; set; }
        public List<int> DriverMedicalConditionCode { get; set; }
        public int DriverChildrenBelow16Years { get; set; }
        public string DriverAddressCity { get; set; }
        public string DriverBusinessCity { get; set; }
        public int DriverNOALast5Years { get; set; }
        public int DriverNOCLast5Years { get; set; }
        public int DriverNCDFreeYears { get; set; }
        public string DriverNCDReference { get; set; }
        public List<DriverLicense> DriverLicenses { get; set; }
        public List<DriverViolation> DriverViolations { get; set; }
        public /*int*/ string DriverRelationship { get; set; }
    }

    public class DriverLicense
    {
        public int LicenseCountryCode { get; set; }
        public int LicenseNumberYears { get; set; }
        public string DriverLicenseTypeCode { get; set; }
        public string DriverLicenseExpiryDate { get; set; }
    }

    public class DriverViolation
    {
        public int ViolationCode { get; set; }
    }
}