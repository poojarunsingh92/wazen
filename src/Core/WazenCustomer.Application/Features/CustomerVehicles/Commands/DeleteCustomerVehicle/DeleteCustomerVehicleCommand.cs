using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.CustomerVehicles.Commands.DeleteCustomerVehicle
{
   public class DeleteCustomerVehicleCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
