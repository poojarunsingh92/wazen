using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.CancellationRequests.Queries.GetCancellationRequestList
{
    public class GetCancellationRequestListQuery : IRequest<Response<IEnumerable<CancellationRequestListVm>>>
    {
    }
}
