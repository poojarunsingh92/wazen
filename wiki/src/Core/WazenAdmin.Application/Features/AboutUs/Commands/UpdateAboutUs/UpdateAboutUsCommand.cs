using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.AboutUs.Commands.UpdateAboutUs
{
    public class UpdateAboutUsCommand : IRequest<Response<Guid>>
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
    }
}
