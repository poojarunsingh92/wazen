using FluentValidation;
using System;

namespace WazenAdmin.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Date);
            //.NotEmpty().WithMessage("{PropertyName} is required.")
            //.NotNull()
            //.GreaterThan(DateTime.Now);


            RuleFor(p => p.CreatedOn);
                //.NotEmpty().WithMessage("{PropertyName} is required.")
                //.NotNull()
                //.GreaterThan(DateTime.Now);



            RuleFor(p => p.ContactNo)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Designation)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ModifiedOn);
                
            RuleFor(p => p.IsActive);

            RuleFor(p => p.CreatedBy);


            RuleFor(p => p.ModifiedBy);

            RuleFor(p => p.RoleType);


        }
    }
}
