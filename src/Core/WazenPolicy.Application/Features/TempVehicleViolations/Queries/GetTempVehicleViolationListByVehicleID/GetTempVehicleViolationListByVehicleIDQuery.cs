using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationListByVehicleID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationListByVehicleID
{
    public class GetTempVehicleViolationListByVehicleIDQuery : IRequest<Response<List<VehicleViolationListVm>>>
    {
        public Guid VehicleID { get; set; }
    }
}
