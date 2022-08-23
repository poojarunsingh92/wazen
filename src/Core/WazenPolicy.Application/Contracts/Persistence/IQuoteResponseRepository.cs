using System;
using System.Collections.Generic;
using System.Text;
using Wazen.Domain.Entities;
using WazenPolicy.Application.Features.ICQuoteResponses.Commands.CreateQuoteResponse;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Contracts.Persistence
{
    public interface IQuoteResponseRepository : IAsyncRepository<InsuranceCompanyQuoteResponse>
    {
    }
}
