using FluentValidation;
using System;

namespace WazenAdmin.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Username)
           .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ContactNo)
            .NotEmpty().WithMessage("{PropertyName} is required.");


            RuleFor(p => p.Designation)
               .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p.Password);
        }
    }
}
