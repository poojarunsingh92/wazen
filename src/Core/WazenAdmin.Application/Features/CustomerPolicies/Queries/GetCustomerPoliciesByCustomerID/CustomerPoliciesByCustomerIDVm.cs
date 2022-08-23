using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPoliciesByCustomerID
{
    public class CustomerPoliciesByCustomerIDVm
    {
        public Guid Id { get; set; }
        public string PolicyRequestRefNo { get; set; }
        public Guid VehicleId { get; set; }
        public Guid CustomerId { get; set; }
        public int PolicyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyResponse { get; set; }
        public string ServiceChargeAmount { get; set; } //Here onwards below newly added fields
        public string AdditionalCoverageAmount { get; set; }
        public string VAT { get; set; }
        public string PremiumAmount { get; set; } //PremiumDetail Renamed to PremiumAmount
        public string GroundTotal { get; set; }
        public Boolean IsUpgraded { get; set; }
        public Boolean IsCancelled { get; set; }
    }
}
