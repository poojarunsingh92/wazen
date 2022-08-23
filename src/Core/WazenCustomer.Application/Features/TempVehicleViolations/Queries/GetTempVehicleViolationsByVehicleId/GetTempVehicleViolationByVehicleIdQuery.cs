using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationsByVehicleId
{
   public class GetTempVehicleViolationByVehicleIdQuery :IRequest<Response<IEnumerable<GetTempVehicleViolationByVehicleIdListVm>>>
    {
        public Guid VehicleId { get; set; }
    }
}
