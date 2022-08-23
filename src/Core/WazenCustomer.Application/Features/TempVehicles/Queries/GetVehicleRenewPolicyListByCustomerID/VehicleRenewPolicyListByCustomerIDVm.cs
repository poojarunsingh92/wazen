using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleRenewPolicyListByCustomerID
{
    public class VehicleRenewPolicyListByCustomerIDVm
    {
        public VehicleInformationss VehicleData { get; set; }
    }

    public class VehicleInformationss
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public string VehiclePlateType { get; set; }
        public string VehiclePlateNumber { get; set; }
        public string FirstPlateLetter { get; set; }
        public string SecondPlateLetter { get; set; }
        public string ThirdPlateLetter { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleColor { get; set; }
        public string RegistrationType { get; set; }
        public CustomerPoliciesss CustomerPolicies { get; set; } // With ICollection
        //public CustomerPolicies1 CustomerPolicies { get; set; }  // without ICollection
    }
    public class CustomerPoliciesss
    {
        public Guid Id { get; set; }
        public string PolicyRequestRefNo { get; set; }
        public Guid VehicleId { get; set; }
        public Guid TransactionId { get; set; }
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

        public List<AdditionalCoverageInformationss> CustomerPolicyAdditionalCoverage { get; set; }
    }
    public class AdditionalCoverageInformationss
    {
        public Guid Id { get; set; }
        public Guid CustomerPolicyId { get; set; }
        public string AdditionalCoverage { get; set; }

        //public int FeatureCode { get; set; }
        //public string FeatureDesc { get; set; }
        //public int FeatureAmount { get; set; }
        //public int TaxAmount { get; set; }
    }
}
