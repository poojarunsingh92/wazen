using WazenAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System;

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsListByICID
{
    public class GetICAPIDetailsListByICIDQuery : IRequest<Response<List<ICAPIDetailsListByICIDVm>>>
    {
        public Guid ICID { get; set; }
    }
}
