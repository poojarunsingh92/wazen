using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.VehicleImages.Commands.CreateVehicleImage
{
    public class CreateVehicleImageDto
    {
        public Guid ID { get; set; }
        public Guid VehicleID { get; set; }
        public string VehicleImages { get; set; }
    }
}
