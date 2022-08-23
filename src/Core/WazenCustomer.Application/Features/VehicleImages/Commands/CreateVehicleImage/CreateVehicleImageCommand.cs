using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehicleImages.Commands.CreateVehicleImage
{
    public class CreateVehicleImageCommand : IRequest<Response<CreateVehicleImageDto>>
    {
        // public Guid ID { get; set; }
        public Guid VehicleID { get; set; }
        public string VehicleImages { get; set; }
    }
}
