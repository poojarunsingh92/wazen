using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerCancelPolicyQuote
{
    public class CustomerCancelPolicyQuoteVm
    {
        public Guid Id { get; set; }
        public Guid CustomerVehicleID { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string PolicyType { get; set; }
        public string PolicyName { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
