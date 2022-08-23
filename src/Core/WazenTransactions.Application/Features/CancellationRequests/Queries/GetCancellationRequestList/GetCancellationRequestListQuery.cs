using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CancellationRequests.Queries.GetCancellationRequestList
{
    public class GetCancellationRequestListQuery : IRequest<Response<IEnumerable<CancellationRequestListVm>>>
    {
    }
}
