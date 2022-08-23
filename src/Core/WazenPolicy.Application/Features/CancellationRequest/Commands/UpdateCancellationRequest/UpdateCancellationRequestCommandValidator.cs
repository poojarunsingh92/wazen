using FluentValidation;

namespace WazenPolicy.Application.Features.CancellationRequest.Commands.UpdateCancellationRequest
{
    public class UpdateCancellationRequestCommandValidator : AbstractValidator<UpdateCancellationRequestCommand>
    {
        public UpdateCancellationRequestCommandValidator()
        {
        }
    }
}
