using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.TempDrivers.Queries.GetDriverVehicleViolationDetailsByVehicleId
{
    public class GetDriverVehicleViolationDetailsByVehicleIdVm
    {
        public Guid ID { get; set; }
        //Vehicle parameter        
        public int? VehiclePurposeId { get; set; }
        public string AverageDailyMileage { get; set; }
        public bool ParkingGarage { get; set; }
        public string EstimateValue { get; set; }
        public Boolean IsSelected { get; set; }

        //Driver parameter
        public Guid DriverId { get; set; }

        public string DriverNationalId { get; set; }
        public string DriverName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? EducationId { get; set; }
        public int? MedicalIssueId { get; set; }
        public Boolean IsMainDriver { get; set; }
        //Violation parameter
        public List<TempVViolation> TempVehicleViolation { get; set; }
        public List<VViolation> VViolationData { get; set; }

    }

    public class TempVViolation
    {
        public Guid ID { get; set; }
        public Guid? VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int? ViolationTypeId { get; set; }

    }

    public class VViolation
    {
        public Guid ID { get; set; }
        public Guid? VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int? ViolationTypeId { get; set; }
    }
}