using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.PolicyRequests.Queries.GetPolicyRequestList
{
   public class PolicyRequestListVm
    {
        public Guid ID { get; set; }
        public string InsurancePolicy_ProductName { get; set; }
        public string NationalID { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public string PolicyDuration { get; set; }
        public string PolicyAmount { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }
    }
}
