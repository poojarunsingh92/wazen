using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Commands.UpgradeCustomerPolicy
{
    public class UpgradeCustomerPolicyCommand : IRequest<Response<bool>>
    {
        public List<UpgradePolicy> UpgradePolicies { get; set; }        
    }
    public class UpgradePolicy
    {
        public Guid ID { get; set; }
    }
}
