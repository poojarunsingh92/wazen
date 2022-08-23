using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.FAQ.Commands.UpdateFAQ
{
    public class UpdateFAQCommandValidator : AbstractValidator<UpdateFAQCommand>
    {
        public UpdateFAQCommandValidator()
        {
            RuleFor(p => p.Question)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();



            RuleFor(p => p.Answer)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();


            RuleFor(p => p.Module)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
               
        }

    }

}
