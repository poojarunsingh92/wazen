using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehiclePurposes.Queries.GetAllVehiclePurposes
{
    public class GetAllVehiclePurposeListQuery : IRequest<Response<IEnumerable<VehiclePurposeListVm>>>
    {
    }
}
