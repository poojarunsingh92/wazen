using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleRenewPolicyListByCustomerID
{
    public class GetVehicleRenewPolicyListByCustomerIDQuery : IRequest<Response<List<VehicleInformationss>>>
    {
        public Guid CustomerID { get; set; }
    }
}
