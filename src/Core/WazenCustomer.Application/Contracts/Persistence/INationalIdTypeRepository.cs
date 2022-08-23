using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface INationalIdTypeRepository: IAsyncRepository<NationalIdType>
    {
    }
}