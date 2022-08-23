using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.PolicyRequests.Queries.GetPolicyRequestList
{
    public class GetPolicyRequestListQuery : IRequest<Response<IEnumerable<PolicyRequestListVm>>>
    {
    }
}
