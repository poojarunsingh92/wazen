using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempDrivers.Queries.GetAllTempDrivers
{
    public class GetAllTempDriverListQuery : IRequest<Response<IEnumerable<TempDriverListVm>>>
    {
    }
}
