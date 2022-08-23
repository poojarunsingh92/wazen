using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByVehicleId
{
    public class GetTempVehicleByVehicleIdQuery : IRequest<Response<TempVehicleByVehicleIdVm>>
    {
        public Guid Id { get; set; }
    }
}
