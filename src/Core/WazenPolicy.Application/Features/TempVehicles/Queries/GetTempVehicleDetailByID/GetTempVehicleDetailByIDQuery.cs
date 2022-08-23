using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Features.Vehicles.Queries.GetVehicleDetailByID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempVehicles.Queries.GetTempVehicleDetailByID
{
    public class GetTempVehicleDetailByIDQuery : IRequest<Response<VehicleDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
