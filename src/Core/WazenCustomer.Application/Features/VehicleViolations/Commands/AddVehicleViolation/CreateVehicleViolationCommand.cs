using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehicleViolations.Commands.AddVehicleViolation
{
    public class CreateVehicleViolationCommand : IRequest<Response<CreateVehicleViolationDto>>
    {
        public Guid VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int ViolationTypeId { get; set; }

    }
}
