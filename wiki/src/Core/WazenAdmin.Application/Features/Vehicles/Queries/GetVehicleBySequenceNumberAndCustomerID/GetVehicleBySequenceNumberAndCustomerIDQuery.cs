using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerID
{
    public class GetVehicleBySequenceNumberAndCustomerIDQuery : IRequest<Response<VehicleBySeqNumAndCustomerIdVm>>
    {
        public Guid CustomerID { get; set; }
        public string SequenceNumber { get; set; }
    }
}
