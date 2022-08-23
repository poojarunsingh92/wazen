using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.AddtionalCoverages.Commands.AddAdditionalCoverage
{
    public class AddAdditionalCoverageCommand : IRequest<Response<AdditionalCoverageDto>>
    {
        public Guid CustomerPolicyId { get; set; }
        public string AdditionalCoverage { get; set; }
    }
}
