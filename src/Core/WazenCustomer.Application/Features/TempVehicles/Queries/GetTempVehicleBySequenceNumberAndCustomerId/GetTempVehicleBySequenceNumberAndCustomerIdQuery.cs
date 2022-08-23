using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleBySequenceNumberAndCustomerId
{
    public class GetTempVehicleBySequenceNumberAndCustomerIdQuery : IRequest<Response<TempVehicleBySeqNumAndCustomerIdVm>>
    {
        public string SequenceNumber { get; set; }
        public Guid CustomerID { get; set; }
    }
}