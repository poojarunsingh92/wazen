using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.CancellationRequests.Commands.CreateCancellationRequest
{
 public   class CreateCancellationRequestCommandValidator : AbstractValidator<CreateCancellationRequestCommand>
    {

        public CreateCancellationRequestCommandValidator()
        {

        }

    }
}
