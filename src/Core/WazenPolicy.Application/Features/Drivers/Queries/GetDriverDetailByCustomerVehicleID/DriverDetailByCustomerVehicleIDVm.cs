using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.Drivers.Queries.GetDriverDetailByCustomerVehicleID
{
    public class DriverDetailByCustomerVehicleIDVm
    {
        public Guid ID { get; set; }
        public Guid? CustomerVehicleId { get; set; }
        public string DriverName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Relation { get; set; }
        public int? GenderId { get; set; } 
        public int? EducationId { get; set; } 
        public int? OccupationId { get; set; } 
        public int? MaritalStatusId { get; set; } 
        public string ChildrenBelow16 { get; set; }
        public string WorkCity { get; set; }
        public string HomeAddressCity { get; set; }
        public string WorkCompanyName { get; set; }
        public string LicenseType { get; set; }
        public string TrafficViolations { get; set; }
        public string HealthConditions { get; set; }
        public string LicenseOwnYears { get; set; }
        public int? MedicalIssueId { get; set; } 
        public Boolean IsMainDriver { get; set; }
        public string DNID { get; set; }
    }
}
