using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Drivers.Queries.GetDriverByVehicleID
{
    public class DriverByVehicleIDVm
    {
        public Guid ID { get; set; }
        public Guid? CustomerVehicleId { get; set; }    //FK
        public string DriverName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Relation { get; set; }
        public int GenderId { get; set; }           //FK
        public int EducationId { get; set; }        //FK
        public int OccupationId { get; set; }       //FK
        public int MaritalStatusId { get; set; }    //FK
        public string ChildrenBelow16 { get; set; }
        public string WorkCity { get; set; }
        public string HomeAddressCity { get; set; }
        public string WorkCompanyName { get; set; }
        public string LicenseType { get; set; }
        public bool TrafficViolations { get; set; }
        public string HealthConditions { get; set; }
        public string LicenseOwnYears { get; set; }
        public int? MedicalIssueId { get; set; }         //FK
        public Boolean IsMainDriver { get; set; }
        public string DNID { get; set; }
    }
}
