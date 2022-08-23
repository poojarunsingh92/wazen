using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByCustomerId
{
    public class GetTempVehicleByCustomerIdQuery : IRequest<Response<List<TempVehicleByCustomerIdVm>>>
    {
        public Guid CustomerId { get; set; }
    }
}
