using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.CancellationRequests.Commands.DeleteCancellationRequest
{
    public class DeleteCancellationRequestCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
