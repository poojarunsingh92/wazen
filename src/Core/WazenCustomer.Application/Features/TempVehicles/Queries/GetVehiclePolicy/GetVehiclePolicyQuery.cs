using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicy
{
    public class GetVehiclePolicyQuery : IRequest<Response<VehicleInfo>>
    {
        public Guid CustomerID { get; set; }
        public string SequenceNumber { get; set; }
        public string PolicyNumber { get; set; }
        public string InsuranceCompanyName { get; set; }
    }
}
