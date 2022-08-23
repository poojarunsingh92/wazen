using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Drivers.Queries.GetDriverDetailByCustomerVehicleID
{
    public class GetDriverDetailByCustomerVehicleIDQuery : IRequest<Response<DriverDetailByCustomerVehicleIDVm>>
    {
        public Guid CustomerVehicleId { get; set; }
    }
}
