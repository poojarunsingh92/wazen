using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.CancellationRequests.Queries.GetCancellationRequestByPolicyID
{
    public class GetCancellationRequestByPolicyIDQuery : IRequest<Response<CancellationRequestByPolicyIDVm>>
    {
        public Guid PolicyID { get; set; }
    }
}
