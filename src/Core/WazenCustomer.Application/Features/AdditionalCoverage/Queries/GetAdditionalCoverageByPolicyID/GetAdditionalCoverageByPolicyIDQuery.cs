using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAdditionalCoverageByPolicyID
{
    public class GetAdditionalCoverageByPolicyIDQuery : IRequest<Response<AdditionalCoverageByPolicyIDVm>>
    {
        public Guid CustomerPolicyId { get; set; }
    }
}
