using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Commands.UpdateAdditionalCoverage
{
    public class UpdateAdditionalCoverageCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public Guid CustomerPolicyId { get; set; }         
        public string AdditionalCoverage { get; set; }
    }
}
