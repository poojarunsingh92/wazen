using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.CreateCustomerPolicy
{
    public class CreateCustomerPolicyCommandValidator : AbstractValidator<CreateCustomerPolicyCommand>
    {
        public CreateCustomerPolicyCommandValidator()
        {
        }
    }
}
