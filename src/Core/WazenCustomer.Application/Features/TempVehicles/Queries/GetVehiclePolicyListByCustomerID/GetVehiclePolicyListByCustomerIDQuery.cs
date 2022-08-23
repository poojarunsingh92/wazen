using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicyListByCustomerID
{
    public class GetVehiclePolicyListByCustomerIDQuery : IRequest<Response<List<VehicleInformation>>>
    {
        public Guid CustomerID { get; set; }
    }
}
