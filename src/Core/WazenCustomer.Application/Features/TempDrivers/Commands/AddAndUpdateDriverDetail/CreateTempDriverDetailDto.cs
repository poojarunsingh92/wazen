using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.TempDrivers.Commands.AddAndUpdateDriverDetail
{
    public class CreateTempDriverDetailDto
    {
        public Guid VId { get; set; }
        public int? VehiclePurposeId { get; set; }
        public string AverageDailyMileage { get; set; }
        public bool ParkingGarage { get; set; }
        public string EstimateValue { get; set; }
        public Boolean IsSelected { get; set; }
        public Guid DriverId { get; set; }
        public string DriverName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Relation { get; set; }
        public int? GenderId { get; set; }           //FK
        public int? EducationId { get; set; }
        public int? MedicalIssueId { get; set; }
        public Boolean IsMainDriver { get; set; }

       // public Guid CustomerID { get; set; }

        public string DriverNationalId { get; set; }
    }
}
