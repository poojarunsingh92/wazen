using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.ContactUs.Commands.CreateContactUs
{
    public class CreateContactUsCommandValidator : AbstractValidator<CreateContactUsCommand>
    {
        public CreateContactUsCommandValidator()
        {

        }
    }
}
