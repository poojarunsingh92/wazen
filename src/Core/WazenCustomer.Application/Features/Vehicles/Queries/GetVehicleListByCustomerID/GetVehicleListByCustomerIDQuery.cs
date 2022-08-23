using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID
{
    public class GetVehicleListByCustomerIDQuery : IRequest<Response<IEnumerable<VehicleListByCustomerIDVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
