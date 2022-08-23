using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehicleViolations.Commands.DeleteVehicleViolation
{
    public class DeleteVehicleViolationCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
