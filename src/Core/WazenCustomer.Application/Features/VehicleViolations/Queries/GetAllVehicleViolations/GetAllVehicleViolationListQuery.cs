using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehicleViolations.Queries.GetAllVehicleViolations
{
   public class GetAllVehicleViolationListQuery: IRequest<Response<IEnumerable<VehicleViolationListVm>>>
    {
    }
}
