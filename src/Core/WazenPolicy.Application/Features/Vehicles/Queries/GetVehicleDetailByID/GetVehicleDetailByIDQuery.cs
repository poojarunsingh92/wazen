using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Vehicles.Queries.GetVehicleDetailByID
{
    public class GetVehicleDetailByIDQuery : IRequest<Response<VehicleDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
