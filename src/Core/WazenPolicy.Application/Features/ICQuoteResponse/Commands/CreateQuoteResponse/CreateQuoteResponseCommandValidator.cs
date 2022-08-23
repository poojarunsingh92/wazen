using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.ICQuoteResponses.Commands.CreateQuoteResponse
{
    public class CreateQuoteResponseCommandValidator : AbstractValidator<CreateQuoteResponseCommand>
    {
        public CreateQuoteResponseCommandValidator()
        {

        }
    }
}
