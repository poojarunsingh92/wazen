using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList
{
    public class GetAllListVM
    {
        public GetAllvehicleList vehicleData { get; set; }
    }
    public class GetAllvehicleList
    {
        public Guid vehicleId { get; set; }
        public string vehicleMake { get; set; }
        public string vehicleModel { get; set; }
        public string vehicleNumber { get; set; }
        public string sequenceNumber { get; set; }
        public int? vehiclePurposeId { get; set; }
        public string averageDailyMileage { get; set; }
        public bool parkingGarage { get; set; }
        public string estimateValue { get; set; }
        public Boolean isSelected { get; set; }

        //public IEnumerable<TempDriverData> TempDrivers { get; set; }

        // public  DriverDetails DriverDetails { get; set; }
        public IEnumerable<VehicleViolationData> VehicleViolations { get; set; }

        public DriverDetails driverDetails { get; set; }
        public CustomerData customer { get; set; }
        public PolicyData PolicyDetails { get; set; }
    }
    public class CustomerData
    {
        public int? nationalId { get; set; }
    }
    public class DriverDetails
    {
       public Guid driverId { get; set; }
        public string driverName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int? educationId { get; set; }
        public int? medicalIssueId { get; set; }
        public Boolean isMainDriver { get; set; }

    }

    public class VehicleViolationData
    {
        public Guid id { get; set; }
        public Guid? vehicleId { get; set; }
        public DateTime violationDate { get; set; }
        public int? violationTypeId { get; set; }

    }
    public class PolicyData
    {
        public int? PolicyTypeId { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
