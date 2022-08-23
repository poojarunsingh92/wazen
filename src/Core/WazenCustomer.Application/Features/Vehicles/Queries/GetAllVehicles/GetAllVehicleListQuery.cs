using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetAllVehicles
{
    public class GetAllVehicleListQuery : IRequest<Response<IEnumerable<VehicleListVm>>>
    {
    }
}
