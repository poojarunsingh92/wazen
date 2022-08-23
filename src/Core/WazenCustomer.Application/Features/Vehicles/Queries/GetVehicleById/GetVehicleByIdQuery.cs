using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleById
{
    public class GetVehicleByIdQuery : IRequest<Response<VehicleVm>>
    {
        public Guid Id { get; set; }
    }
}
