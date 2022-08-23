using MediatR;
using System;

namespace WazenPolicy.Application.Features.CancellationRequest.Commands.DeleteCancellationRequest
{
    public class DeleteCancellationRequestCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
