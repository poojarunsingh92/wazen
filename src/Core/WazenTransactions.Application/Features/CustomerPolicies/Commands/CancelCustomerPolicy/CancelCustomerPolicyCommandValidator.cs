using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.CustomerPolicies.Commands.CancelCustomerPolicy
{
    public class CancelCustomerPolicyCommandValidator : AbstractValidator<CancelCustomerPolicyCommand>
    {
        public CancelCustomerPolicyCommandValidator()
        {

        }
    }
}
