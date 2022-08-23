using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetRenewCustomerPolicyListByCustomerID
{
    public class RenewCustomerPolicyListByCustomerIDVm
    {
       public VehicleInformation VehicleInformationData { get; set; }
    }

    public class VehicleInformation
    {
        //Vehicle
        public Guid Id { get; set; }
        public DateTime VehicleRegistrationExpiryDate { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }

        public PolicyInformation PolicyInformationData { get; set; }
    }

    public class PolicyInformation
    {
        //Policy
        public Guid PolicyId { get; set; }
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
        public string ServiceChargeAmount { get; set; }
        public string AdditionalCoverageAmount { get; set; }
        public string VAT { get; set; }
        public string PremiumAmount { get; set; }
        public string GroundTotal { get; set; }
        public Boolean IsUpgraded { get; set; }
        public Boolean IsCancelled { get; set; }
    }
}
