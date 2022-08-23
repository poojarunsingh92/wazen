using MediatR;
using System;

namespace WazenAdmin.Application.Features.StaticContents.Commands.DeleteStaticContent
{
    public class DeleteStaticContentCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
