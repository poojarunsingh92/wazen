using WazenAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentsList
{
    public class GetStaticContentsListQuery : IRequest<Response<IEnumerable<StaticContentListVm>>>
    {
    }
}
