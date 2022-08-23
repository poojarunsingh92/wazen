using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationDetailByVehicleID
{
    public class GetVehicleViolationDetailByVehicleIDQuery : IRequest<Response<VehicleViolationDetailVm>>
    {
        public Guid VehicleID { get; set; }
    }
}
