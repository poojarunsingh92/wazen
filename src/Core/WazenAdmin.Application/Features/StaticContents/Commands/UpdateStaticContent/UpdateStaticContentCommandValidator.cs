using FluentValidation;

namespace WazenAdmin.Application.Features.StaticContents.Commands.UpdateStaticContent
{
    public class UpdateStaticContentCommandValidator : AbstractValidator<UpdateStaticContentCommand>
    {
        public UpdateStaticContentCommandValidator()
        {
            RuleFor(p => p.AboutUs)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
