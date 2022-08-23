using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempDrivers.Queries.GetDriverVehicleViolationDetailsByVehicleId
{
    public class GetDriverVehicleViolationDetailsByVehicleIdQuery : IRequest<Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>>
    {
        public Guid VehicleId { get; set; }
    }
}
