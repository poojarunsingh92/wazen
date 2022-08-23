using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationDetailByVehicleID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationDetailByVehicleID
{
    public class GetTempVehicleViolationDetailByVehicleIDQuery : IRequest<Response<VehicleViolationDetailVm>>
    {
        public Guid VehicleID { get; set; }
    }
}
