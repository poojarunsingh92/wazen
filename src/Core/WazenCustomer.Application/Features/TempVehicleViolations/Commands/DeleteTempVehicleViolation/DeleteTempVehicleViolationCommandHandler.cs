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

namespace WazenCustomer.Application.Features.TempVehicleViolations.Commands.DeleteTempVehicleViolation
{
    public class DeleteTempVehicleViolationCommandHandler : IRequestHandler<DeleteTempVehicleViolationCommand>
    {
        private readonly IVehicleViolationRepository _vehicleViolationRepsitory;
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly ILogger<DeleteTempVehicleViolationCommandHandler> _logger;

        public DeleteTempVehicleViolationCommandHandler(IVehicleViolationRepository vehicleViolationRepsitory, ITempVehicleViolationRepository tempVehicleViolationRepository, ILogger<DeleteTempVehicleViolationCommandHandler> logger)
        {
            _vehicleViolationRepsitory = vehicleViolationRepsitory;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteTempVehicleViolationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var vehicleViolationToDelete = await _vehicleViolationRepsitory.GetByIdAsync(request.Id);

            if (vehicleViolationToDelete != null)
            {
                await _vehicleViolationRepsitory.DeleteAsync(vehicleViolationToDelete);
            }
            else
            {
                var tempVehicleViolationToDelete = await _tempVehicleViolationRepository.GetByIdAsync(request.Id);

                if (tempVehicleViolationToDelete == null)
                {
                    throw new NotFoundException(nameof(TempVehicleViolation), request.Id);
                }
                await _tempVehicleViolationRepository.DeleteAsync(tempVehicleViolationToDelete);
            } 
            _logger.LogInformation("Handle Completed");
            return Unit.Value;
        }
    }
}