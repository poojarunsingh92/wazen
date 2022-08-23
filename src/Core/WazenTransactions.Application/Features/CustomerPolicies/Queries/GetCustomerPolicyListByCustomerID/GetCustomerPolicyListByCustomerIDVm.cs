using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID
{
    public class GetCustomerPolicyListByCustomerIDVm
    {
        public Guid ID { get; set; }
        public Guid? CustomerVehicleId { get; set; }         //FK
        public Guid? TransactionId { get; set; }
       // public Guid? ICID { get; set; }                      //FK
        public int? PolicyTypeId { get; set; }               //FK
        public string PremiumDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime IssuedDate { get; set; }
        public string PolicyNumber { get; set; }
        //public string Status { get; set; }
        public List<CustomerPolicyAdditionalCoverageVM> CustomerPolicyAdditionalCoverage { get; set; }
    }
    public class CustomerPolicyAdditionalCoverageVM
    {
        public Guid Id { get; set; }
        public Guid? CustomerPolicyId { get; set; }         //FK
        public string AdditionalCoverage { get; set; }
    }

}
