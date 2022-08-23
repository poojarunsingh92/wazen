using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAdditionalCoverageByPolicyID
{
    public class AdditionalCoverageByPolicyIDVm
    {
        public Guid Id { get; set; }
        public Guid? CustomerPolicyId { get; set; }
        public List<AdditionalCoverage> AdditionalCoverage { get; set; }
    }

    public class AdditionalCoverage
    {
        public string featureCode { get; set; }
        public string featureDesc { get; set; }
        public double featureAmount { get; set; }
        public double taxAmount { get; set; }
        public Boolean checkedd { get; set; }
    }
}
