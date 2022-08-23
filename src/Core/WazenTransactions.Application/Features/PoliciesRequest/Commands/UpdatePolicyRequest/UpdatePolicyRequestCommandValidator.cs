using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.PoliciesRequest.Commands.UpdatePolicyRequest
{
   public class UpdatePolicyRequestCommandValidator : AbstractValidator<UpdatePolicyRequestCommand>
    {
        public UpdatePolicyRequestCommandValidator()
        {

        }
    }
}
