using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetAllTempVehicles
{
    public class GetAllTempVehicleListQuery : IRequest<Response<IEnumerable<TempVehicleListVm>>>
    {
    }
}
