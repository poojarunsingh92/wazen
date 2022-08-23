using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.AddtionalCoverages.Commands.DeleteAdditionalCoverage
{
    public class DeleteAdditionalCoverageCommand : IRequest<Response<bool>>
    {
        public Guid ID { get; set; }
    }
}
