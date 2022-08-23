using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.CustomerVehicles.Commands.CreateCustomerVehicle
{
   public class CreateCustomerVehicleCommand : IRequest<Response<CustomerVehicleDto>>
    {
        public Guid CustomerID { get; set; }
        public Guid VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
