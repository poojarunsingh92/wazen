using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.CustomerPolicies.Commands.UpgradeCustomerPolicy
{
    public class UpgradeCustomerPolicyCommandValidator : AbstractValidator<UpgradeCustomerPolicyCommand>
    {
        public UpgradeCustomerPolicyCommandValidator()
        {

        }
    }
}
