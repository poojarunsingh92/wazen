using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID
{
    public class GetVehicleListByCustomerIDQuery : IRequest<Response<IEnumerable<VehicleListByCustomerIDVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
