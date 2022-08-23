using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Exceptions;
using WazenCustomer.Application.Helper;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.VehicleViolations.Commands.UpdateVehicleViolation
{
    public class UpdateVehicleViolationCommandHandler : IRequestHandler<UpdateVehicleViolationCommand, Response<Guid>>
    {
        private readonly IQueueService _queueService;
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ProducerService _producerService;

        public UpdateVehicleViolationCommandHandler(IMapper mapper, IVehicleViolationRepository vehicleViolationRepository, IQueueService queueService)
        {
            _mapper = mapper;
            _vehicleViolationRepository = vehicleViolationRepository;
            _queueService = queueService;
        }
        public async Task<Response<Guid>> Handle(UpdateVehicleViolationCommand request, CancellationToken cancellationToken)
        {
            var vehicleViolationToUpdate = await _vehicleViolationRepository.GetByIdAsync(request.ID);

            if (vehicleViolationToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            _mapper.Map(request, vehicleViolationToUpdate, typeof(UpdateVehicleViolationCommand), typeof(VehicleViolation));
            await _vehicleViolationRepository.UpdateAsync(vehicleViolationToUpdate);
            await _queueService.SendMessageAsync<VehicleViolation>(vehicleViolationToUpdate, "VehicleViolation");
            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
