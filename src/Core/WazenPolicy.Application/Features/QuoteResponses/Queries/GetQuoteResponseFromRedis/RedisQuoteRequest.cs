using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseFromRedis
{

    public class RedisQuoteRequest
    {
        public int UserId { get; set; }
        public string Source { get; set; }
        public string QuoteRequestRefNo { get; set; }//aggregator se
        public string Product { get; set; }
        public string PolicyEffectiveDate { get; set; } //date when policy will start as per customer request
        public string PromoCode { get; set; }//not mandatory

        public InsuredInfo InsuredInfo { get; set; }
        public Address Address { get; set; }
        public VehicleInfo VehicleInfo { get; set; }
        //public DriverInfo DriverInfo { get; set; }
    }

    public class InsuredInfo
    {
        public int IdTypeCode { get; set; }
        public string IdNo { get; set; }
        public string NameEng { get; set; }
        public string NameAr { get; set; }
        public string IdExpiryDate { get; set; }
        public string IdRegistrationCityCode { get; set; }
        public string BirthDateG { get; set; }
        public string BirthDateH { get; set; }
        public int GenderCode { get; set; }
        public int MaritalStatusCode { get; set; }
        public int OccupationCode { get; set; }
        public int EducationCode { get; set; }
        public int NationalityCode { get; set; }
        public int ChildrenBelow16 { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int NcdYears { get; set; }
        public string NcdReference { get; set; }
        public int NoOfAccidents { get; set; }
        public int AccidentsLiability { get; set; }
        public int IsTransferOfOwnership { get; set; }
        public int OwnerId { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int CityCode { get; set; }
        public int PostalCode { get; set; }
        public int BuildingNumber { get; set; }
        public int AdditionalNumber { get; set; }
        public int UnitNumber { get; set; }
    }

    public class AccidentDetails
    {
        public string accidentDate { get; set; }
        public string? carModel { get; set; }
        public string? carType { get; set; }
        public string caseNumber { get; set; }
        public string? causeOfAccident { get; set; }
        public string cityName { get; set; }
        public string? damageParts { get; set; }
        public int? driverAge { get; set; }
        public string driverIdNumber { get; set; }
        public decimal? estimatedAmount { get; set; }
        public int liability { get; set; }
        public string? sequenceNumber { get; set; }
    }

    public class VehicleInfo
    {
        public int VehicleIdTypeCode { get; set; }
        public int RepairTypeCode { get; set; }
        public int BodyTypeCode { get; set; }
        public string ChassisNumber { get; set; }
        public int ColorCode { get; set; }
        public string ColorDesc { get; set; }
        public string SequenceNumber { get; set; }
        public string CustomNumber { get; set; }
        public int? Cylinders { get; set; }
        public int? DrivingCityCode { get; set; }
        public string? EngineSize { get; set; }
        public int? ExpectedAnnualMileage { get; set; }
        public int VehicleValue { get; set; }
    }
}
