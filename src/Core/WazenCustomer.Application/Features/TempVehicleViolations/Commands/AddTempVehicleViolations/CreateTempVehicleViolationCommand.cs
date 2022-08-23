using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Commands.AddTempVehicleViolations
{
    public class CreateTempVehicleViolationCommand : IRequest<Response<CreateTempVehicleViolationDto>>
    {
        public Guid VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int ViolationTypeId { get; set; }

    }
}