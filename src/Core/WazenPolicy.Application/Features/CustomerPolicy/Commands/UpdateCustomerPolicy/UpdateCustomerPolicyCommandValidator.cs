using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateCustomerPolicy
{
    public class UpdateCustomerPolicyCommandValidator : AbstractValidator<UpdateCustomerPolicyCommand>
    {
        public UpdateCustomerPolicyCommandValidator()
        {
        }
    }
}
