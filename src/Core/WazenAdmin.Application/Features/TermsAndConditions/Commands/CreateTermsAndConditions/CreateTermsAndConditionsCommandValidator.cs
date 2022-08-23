using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.TermsAndConditions.Commands.CreateTermsAndConditions
{
    public class CreateTermsAndConditionsCommandValidator : AbstractValidator<CreateTermsAndConditionsCommand>
    {
        public CreateTermsAndConditionsCommandValidator()
        {

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


        }
    }

}