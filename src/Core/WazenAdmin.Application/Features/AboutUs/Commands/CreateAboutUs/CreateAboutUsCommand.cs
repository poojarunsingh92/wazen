using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.AboutUs.Commands.CreateAboutUs
{
    public class CreateAboutUsCommand : IRequest<Response<CreateAboutUsDto>>
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
    }
}
