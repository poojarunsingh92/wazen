using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateExistingCustomerPolicyCommand
{
    public class UpdateExistingCustomerPolicyCommand : IRequest<Response<Guid>>
    {
        public Guid CustomerVehicleID { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string PolicyType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string PremiumAmount { get; set; }
        public string AdditionalCoverageAmount { get; set; }
        public string AdditionalCoverage { get; set; }
        public string ServiceChargeAmount { get; set; }
        public string VAT { get; set; }
        public Boolean isUpgraded { get; set; }
        public Boolean isCancelled { get; set; }
    }
}
