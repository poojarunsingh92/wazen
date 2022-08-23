using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.AboutUs.Commands.DeleteAboutUs
{
    public class DeleteAboutUsCommand : IRequest<Response<bool>>
    {
        public Guid ID { get; set; }
    }
}
