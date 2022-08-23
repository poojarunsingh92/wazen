using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Features.Drivers.Queries.GetDriverDetailByCustomerVehicleID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempDrivers.Queries.GetTempDriverDetailByCustomerVehicleID
{
    public class GetTempDriverDetailByCustomerVehicleIDQuery : IRequest<Response<DriverDetailByCustomerVehicleIDVm>>
    {
        public Guid CustomerVehicleId { get; set; }
    }
}
