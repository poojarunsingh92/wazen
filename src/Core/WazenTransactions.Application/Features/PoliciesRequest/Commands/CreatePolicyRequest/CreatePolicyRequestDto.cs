using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.PoliciesRequest.Commands.CreatePolicyRequest
{
   public class CreatePolicyRequestDto 
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
