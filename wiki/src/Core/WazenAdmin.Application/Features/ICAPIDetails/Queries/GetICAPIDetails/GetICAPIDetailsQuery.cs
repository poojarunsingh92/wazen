using WazenAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries
{
    public class GetICAPIDetailsQuery : IRequest<Response<ICAPIDetailsVm>>
    {
        public Guid ID { get; set; }
    }
}
