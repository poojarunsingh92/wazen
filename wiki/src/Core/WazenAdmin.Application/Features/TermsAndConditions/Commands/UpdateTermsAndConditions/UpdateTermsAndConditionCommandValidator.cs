using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.TermsAndConditions.Commands.UpdateTermsAndConditions
{
    public class UpdateTermsAndConditionCommandValidator : AbstractValidator<UpdateTermsAndConditionsCommand>
    {
        public UpdateTermsAndConditionCommandValidator()
        {
            RuleFor(p => p.Content)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }

    }

}