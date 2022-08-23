using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.AddtionalCoverages.Commands.AddAdditionalCoverage
{
    public class AdditionalCoverageDto
    {
        public Guid Id { get; set; }
        public Guid CustomerPolicyId { get; set; }
        public string AdditionalCoverage { get; set; }
    }
}
