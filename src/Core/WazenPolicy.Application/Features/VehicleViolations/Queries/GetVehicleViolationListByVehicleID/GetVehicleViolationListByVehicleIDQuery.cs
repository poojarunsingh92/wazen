using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationListByVehicleID
{
    public class GetVehicleViolationListByVehicleIDQuery : IRequest<Response<List<VehicleViolationListVm>>>
    {
        public Guid VehicleID { get; set; }
    }
}
