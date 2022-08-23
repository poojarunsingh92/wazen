using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateExistingCustomerPolicyCommand
{
    public class UpdateExistingCustomerPolicyCommandValidator : AbstractValidator<UpdateExistingCustomerPolicyCommand>
    {
        public UpdateExistingCustomerPolicyCommandValidator()
        {
        }
    }
}
