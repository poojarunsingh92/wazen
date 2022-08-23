using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Commands.UpdateTempVehicleViolation
{
    public class UpdateTempVehicleViolationCommand : IRequest<Response<UpdateTempVehicleViolationDto>>
    {
        public Guid ID { get; set; }
        public Guid VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int ViolationTypeId { get; set; }
    }
}
