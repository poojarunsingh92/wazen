using MediatR;
using WazenPolicy.Application.Responses;
using System.Collections.Generic;
using System;

namespace WazenPolicy.Application.Features.CancellationRequest.Queries.GetCancellationRequestList
{
    public class GetCancellationRequestListQuery : IRequest<Response<IEnumerable<CancellationRequestListVm>>>
    {
        
    }
}
