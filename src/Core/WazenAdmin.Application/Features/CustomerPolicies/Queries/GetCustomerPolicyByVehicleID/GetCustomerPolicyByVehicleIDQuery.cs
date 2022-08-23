using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyByVehicleID
{
    public class GetCustomerPolicyByVehicleIDQuery : IRequest<Response<CustomerPolicyByVehicleIDVm>>
    {
        public Guid VehicleID { get; set; }
    }
}
