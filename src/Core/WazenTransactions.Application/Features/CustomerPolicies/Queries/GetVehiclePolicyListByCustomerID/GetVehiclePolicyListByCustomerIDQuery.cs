using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetVehiclePolicyListByCustomerID
{
    public class GetVehiclePolicyListByCustomerIDQuery : IRequest<Response<List<VehicleInformations>>>
    {
        public Guid CustomerID { get; set; }
    }
}
