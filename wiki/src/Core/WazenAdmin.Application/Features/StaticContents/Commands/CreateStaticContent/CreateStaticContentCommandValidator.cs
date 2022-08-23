using FluentValidation;

namespace WazenAdmin.Application.Features.StaticContents.Commands.CreateStaticContent
{
    public class CreateStaticContentCommandValidator : AbstractValidator<CreateStaticContentCommand>
    {
        public CreateStaticContentCommandValidator()
        {
            RuleFor(p => p.AboutUs)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
