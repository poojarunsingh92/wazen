using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetAllTempVehicleViolations
{
   public class GetAllTempVehicleViolationListQuery : IRequest<Response<IEnumerable<TempVehicleViolationListVm>>>
    {
    }
}
