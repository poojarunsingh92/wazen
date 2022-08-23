using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.CustomerVehicles.Commands.CreateCustomerVehicle
{
    public class CustomerVehicleDto
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }            
        public Guid VehicleID { get; set; }             
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }

}
