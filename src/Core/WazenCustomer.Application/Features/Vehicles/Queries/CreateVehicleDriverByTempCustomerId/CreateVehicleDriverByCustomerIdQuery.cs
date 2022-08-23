using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Vehicles.Queries.CreateVehicleDriverByTempCustomerId
{
    public class CreateVehicleDriverByCustomerIdQuery : IRequest<Response<string>>
    {
        public Guid TempCustomerID { get; set; }
        public Guid CustomerId { get; set; }
    }
}
