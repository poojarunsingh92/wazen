using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAdditionalCoverageByVehicleID
{
    public class AdditionalCoverageByPolicyIDVm
    {
        public Guid Id { get; set; }
        public Guid? CustomerPolicyId { get; set; }         //FK
        public string AdditionalCoverage { get; set; }
    }
}
