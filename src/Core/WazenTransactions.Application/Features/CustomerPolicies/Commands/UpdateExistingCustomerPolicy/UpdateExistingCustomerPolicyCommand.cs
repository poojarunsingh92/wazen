using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Commands.UpdateExistingCustomerPolicy
{
    public class UpdateExistingCustomerPolicyCommand : IRequest<Response<Guid>>
    {
        public Guid CustomerVehicleID { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string PolicyType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid VehicleID { get; set; }
        public string PremiumAmount { get; set; }
        public string AdditionalCoverageAmount { get; set; }
        public string AdditionalCoverage { get; set; }
        public string ServiceChargeAmount { get; set; }
        public string VAT { get; set; }
        //public Boolean isUpgraded { get; set; }
        //public Boolean isRenewed { get; set; }
    }
}
