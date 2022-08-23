using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Complaints.Commands.CreateComplaint
{
    public class CreateComplaintCommandValidator : AbstractValidator<CreateComplaintCommand>
    {
        public CreateComplaintCommandValidator()
        {

        }
    }
}
