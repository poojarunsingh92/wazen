using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CancellationRequest.Queries.GetCancellationRequestDetail
{
   public  class GetCancellationRequestDetailQuery : IRequest<Response<CancellationRequestDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
