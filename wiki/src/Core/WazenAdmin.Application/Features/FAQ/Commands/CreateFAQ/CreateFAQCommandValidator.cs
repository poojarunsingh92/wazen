using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.FAQ.Commands.CreateFAQ
{
    public class CreateFAQCommandValidator : AbstractValidator<CreateFAQCommand>
    {
        public CreateFAQCommandValidator()
        {

            RuleFor(p => p.Question)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


            RuleFor(p => p.Answer)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();


            RuleFor(p => p.Module)
                .NotEmpty().WithMessage("{PropertyName} is required.");
             

        }
    }

}
