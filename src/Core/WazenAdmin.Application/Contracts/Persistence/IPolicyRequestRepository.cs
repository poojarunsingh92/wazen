using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Contracts.Persistence
{
   public interface IPolicyRequestRepository : IAsyncRepository<PolicyRequest>
    {

    }
}
