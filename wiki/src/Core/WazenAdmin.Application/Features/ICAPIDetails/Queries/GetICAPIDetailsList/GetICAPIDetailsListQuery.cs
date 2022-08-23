using WazenAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsList
{
    public class GetICAPIDetailsListQuery : IRequest<Response<IEnumerable<ICAPIDetailsListVm>>>
    {
    }
}
