using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.AboutUs.Commands.CreateAboutUs
{
    public class CreateAboutUsCommandValidator : AbstractValidator<CreateAboutUsCommand>
    {
        public CreateAboutUsCommandValidator()
        {

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


        }
    }

}

