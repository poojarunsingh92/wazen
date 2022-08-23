using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByCustomerId
{
    public class VehicleByCustomerIdVm
    {
        public Guid? CustomerID { get; set; }
        public Guid VehicleID { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }
        public string SequenceNumber { get; set; }

        public string DriverNationalId { get; set; }
        //public string PolicyType { get; set; }
        //public DateTime ExpiryDate { get; set; }
    }
}
