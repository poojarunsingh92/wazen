using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.PoliciesRequest.Commands.CreatePolicyRequest
{
   public class CreatePolicyRequestCommandValidator : AbstractValidator<CreatePolicyRequestCommand>
    {
        public CreatePolicyRequestCommandValidator()
        {

        }
    }
}
