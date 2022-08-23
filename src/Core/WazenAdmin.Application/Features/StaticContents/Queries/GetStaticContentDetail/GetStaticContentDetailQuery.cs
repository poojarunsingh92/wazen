using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentDetail
{
    public class GetStaticContentDetailQuery : IRequest<Response<StaticContentDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
