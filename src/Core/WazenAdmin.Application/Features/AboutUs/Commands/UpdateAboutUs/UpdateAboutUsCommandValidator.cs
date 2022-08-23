using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.AboutUs.Commands.UpdateAboutUs
{
    public class UpdateAboutUsCommandValidator : AbstractValidator<UpdateAboutUsCommand>
    {
        public UpdateAboutUsCommandValidator()
        {
            RuleFor(p => p.Content)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }

    }

}

