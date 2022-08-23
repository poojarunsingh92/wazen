using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAdditionalCoverageByVehicleID
{
    public class GetAdditionalCoverageByPolicyIDQuery : IRequest<Response<AdditionalCoverageByPolicyIDVm>>
    {
        public Guid PolicyID { get; set; }
    }
}
