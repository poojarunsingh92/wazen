using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerID
{
    public class GetVehicleBySequenceNumberAndCustomerIDQuery : IRequest<Response<VehicleBySequenceNumberAndCustomerIDVm>>
    {
        public string SequenceNumber { get; set; }
        public Guid CustomerID { get; set; }
    }
}
