using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.CancellationRequests.Commands.UpdateCancellationRequest
{
   public class UpdateCancellationRequestCommandValidator : AbstractValidator<UpdateCancellationRequestCommand>
    {
        public UpdateCancellationRequestCommandValidator()
        {
        }
    }
}
