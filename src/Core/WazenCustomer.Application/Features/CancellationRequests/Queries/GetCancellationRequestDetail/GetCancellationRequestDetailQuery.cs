using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.CancellationRequests.Queries.GetCancellationRequestDetail
{
   public class GetCancellationRequestDetailQuery : IRequest<Response<CancellationRequestDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
