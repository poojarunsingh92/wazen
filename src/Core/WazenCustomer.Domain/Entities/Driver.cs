using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class Driver : AuditableEntity
    {
        public Guid ID { get; set; }
        public Guid? CustomerVehicleId { get; set; }    //FK
        public string DriverName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Relation { get; set; }
        public int? GenderId { get; set; }           //FK
        public int? EducationId { get; set; }        //FK
        public int? OccupationId { get; set; }       //FK
        public int? MaritalStatusId { get; set; }    //FK
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

        [ForeignKey("CustomerVehicleId")]
        public Vehicle Vehicle { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
        [ForeignKey("OccupationId")]
        public Occupation Occupation { get; set; }
        [ForeignKey("EducationId")]
        public Education Education { get; set; }
        [ForeignKey("MaritalStatusId")]
        public MaritalStatus MaritalStatus { get; set; }
        [ForeignKey("MedicalIssueId")]
        public MedicalIssue MedicalIssue { get; set; }
    }
}