using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Commands.DeleteTempVehicleViolation
{
   public class DeleteTempVehicleViolationCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
