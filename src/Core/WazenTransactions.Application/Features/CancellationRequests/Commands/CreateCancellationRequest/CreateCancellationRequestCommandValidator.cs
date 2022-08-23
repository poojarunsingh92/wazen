using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.CancellationRequests.Commands.CreateCancellationRequest
{
 public   class CreateCancellationRequestCommandValidator : AbstractValidator<CreateCancellationRequestCommand>
    {

        public CreateCancellationRequestCommandValidator()
        {

        }

    }
}
