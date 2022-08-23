using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Malath.Commands.MalathComprehensiveQuote
{
    public class MalathComprehensiveQuoteCommand : IRequest<Response<MalathComprehensiveQuoteResponse>>
    {
        public Guid RequestReferenceNo { get; set; }
        public int ProductTypeCode { get; set; }
        public string VehicleAgencyRepair { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public int InsuredIdTypeCode { get; set; }
        public int InsuredId { get; set; }
        public DateTime InsuredIDExpiryDate { get; set; }
        public string InsuredBirthDate { get; set; }
        public string InsuredGenderCode { get; set; }
        public string InsuredNationalityCode { get; set; }
        public string InsuredFirstNameAr { get; set; }
        public string InsuredMiddleNameAr { get; set; }
        public string InsuredLastNameAr { get; set; }
        public string InsuredFirstNameEn { get; set; }
        public string InsuredMiddleNameEn { get; set; }
        public string InsuredLastNameEn { get; set; }
        public string InsuredSocialStatusCode { get; set; }
        public int InsuredEducationCode { get; set; }
        public string InsuredOccupationCode { get; set; }
        public int InsuredChildrenBelow16Years { get; set; }
        public string InsuredBusinessCity { get; set; }
        public string InsuredAddressCity { get; set; }
        public int VehicleValue { get; set; }
        public int VehicleIdTypeCode { get; set; }
        public int VehiclePlateNumber { get; set; }
        public string VehiclePlateText1 { get; set; }
        public string VehiclePlateText2 { get; set; }
        public string VehiclePlateText3 { get; set; }
        public string VehicleChassisNumber { get; set; }
        public int VehicleId { get; set; }
        public Boolean VehicleOwnerTransfer { get; set; }
        public string VehicleOwnerName { get; set; }
        public int VehicleOwnerId { get; set; }
        public string VehiclePlateTypeCode { get; set; }
        public int VehicleModelYear { get; set; }
        public string VehicleMaker { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleRegExpiryDate { get; set; }
        public int VehicleCylinders { get; set; }
        public int VehicleWeight { get; set; }
        public int VehicleSeating { get; set; }
        public int VehicleUseCode { get; set; }
        public int VehicleMileage { get; set; }
        public string VehicleTransmissionTypeCode { get; set; }
        public int VehicleMileageExpectedAnnualCode { get; set; }
        public int VehicleAxleWeightCode { get; set; }
        public int VehicleEngineSizeCode { get; set; }
        public int VehicleOvernightParkingLocationCode { get; set; }
        public Boolean VehicleModification { get; set; }
        public string VehicleModificationDetails { get; set; }
        public List<VehicleSpecification> VehicleSpecifications { get; set; }
        public int NCDFreeYears { get; set; }
        public string NCDReference { get; set; }
        public List<Driver> Drivers { get; set; }
    }

    public class VehicleSpecification
    {
        public int VehicleSpecificationCode { get; set; }
    }

    public class Driver
    {
        public int DriverTypeCode { get; set; }
        public int DriverId { get; set; }
        public int DriverIdTypeCode { get; set; }
        public string DriverBirthDate { get; set; }
        public string DriverGenderCode { get; set; }
        public DateTime DriverBirthDateG { get; set; }
        public string DriverNationalityCode { get; set; }
        public string DriverFirstNameAr { get; set; }
        public string DriverMiddleNameAr { get; set; }
        public string DriverLastNameAr { get; set; }
        public string DriverFirstNameEn { get; set; }
        public string DriverMiddleNameEn { get; set; }
        public string DriverLastNameEn { get; set; }
        public string DriverSocialStatusCode { get; set; }
        public int DriverDrivingPercentage { get; set; }
        public string DriverEducationCode { get; set; }
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
        public string DriverRelationship { get; set; }
    }
    public class DriverLicense
    {
        public int LicenseCountryCode { get; set; }
        public int LicenseNumberYears { get; set; }
        public string DriverLicenseTypeCode { get; set; }
        public /*DateTime*/string DriverLicenseExpiryDate { get; set; }

    }

    public class DriverViolation
    {
        public int ViolationCode { get; set; }
    }
}

