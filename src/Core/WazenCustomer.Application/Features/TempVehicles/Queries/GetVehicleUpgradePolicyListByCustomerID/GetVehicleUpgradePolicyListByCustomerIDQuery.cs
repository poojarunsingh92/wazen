using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleUpgradePolicyListByCustomerID
{
    public class GetVehicleUpgradePolicyListByCustomerIDQuery : IRequest<Response<List<VehicleInformations>>>
    {
        public Guid CustomerID { get; set; }
    }
}
