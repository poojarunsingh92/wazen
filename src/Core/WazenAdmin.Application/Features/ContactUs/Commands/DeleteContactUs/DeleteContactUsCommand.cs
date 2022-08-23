using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.ContactUs.Commands.DeleteContactUs
{
    public class DeleteContactUsCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
