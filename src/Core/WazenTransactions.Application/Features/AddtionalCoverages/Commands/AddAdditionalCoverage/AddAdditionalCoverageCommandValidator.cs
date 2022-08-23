using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.AddtionalCoverages.Commands.AddAdditionalCoverage
{
    public class AddAdditionalCoverageCommandValidator : AbstractValidator<AddAdditionalCoverageCommand>
    {
        public AddAdditionalCoverageCommandValidator()
        {
        }
    }
}
