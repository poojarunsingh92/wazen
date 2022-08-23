using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Exceptions;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.VehicleViolations.Commands.DeleteVehicleViolation
{
    public class DeleteVehicleViolationCommandHandler : IRequestHandler<DeleteVehicleViolationCommand, Response<bool>>
    {
        private readonly IVehicleViolationRepository _vehicleViolationRepsitory;

        public DeleteVehicleViolationCommandHandler(IVehicleViolationRepository vehicleViolationRepsitory)
        {
            _vehicleViolationRepsitory = vehicleViolationRepsitory;
        }

        public async Task<Response<bool>> Handle(DeleteVehicleViolationCommand request, CancellationToken cancellationToken)
        {
            var vehicleViolationToDelete = await _vehicleViolationRepsitory.GetByIdAsync(request.Id);

            if (vehicleViolationToDelete == null)
            {
                var resposeObject = new Response<bool>(request.Id + " is not available");
                return resposeObject;
            }
            await _vehicleViolationRepsitory.DeleteAsync(vehicleViolationToDelete);
            return new Response<bool>(true, "Record deleted");
        }
    }

}
