using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleById
{
   public class VehicleVm
    {
        public Guid ID { get; set; }
        public Guid? CustomerID { get; set; }       //FK
        public string VehiclePlateType { get; set; }
        public string VehiclePlateNumber { get; set; }
        public string FirstPlateLetter { get; set; }
        public string SecondPlateLetter { get; set; }
        public string ThirdPlateLetter { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleColor { get; set; }
        public string RegistrationType { get; set; }
        public string SequenceNumber { get; set; }
        public DateTime VehicleRegistrationExpiryDate { get; set; }
        public string RegistrationCard { get; set; }
        public string SequenceNumberCustomID { get; set; }
        public string OwnershipTransfer { get; set; }
        public string IncaseofTransfer { get; set; }
        public string VehicleUsagePercentage { get; set; }
        public string YearofManufacture { get; set; }
        public string InsuredIDExpiry { get; set; }
        public int? VehiclePurposeId { get; set; }       //FK
        public string VehicleNumber { get; set; }
        public string AverageDailyMileage { get; set; }
        public string TransferOwnership { get; set; }
        public string ParkingGarage { get; set; }
        public string EstimateValue { get; set; }
        public Boolean IsSelected { get; set; }

    }
}
