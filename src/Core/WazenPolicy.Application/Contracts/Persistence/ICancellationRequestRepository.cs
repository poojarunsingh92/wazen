using System;
using System.Collections.Generic;
using System.Text;
using Wazen.Domain.Entities;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Contracts.Persistence
{
    public interface ICancellationRequestRepository : IAsyncRepository<CancellationRequest>
    {
    }
}
