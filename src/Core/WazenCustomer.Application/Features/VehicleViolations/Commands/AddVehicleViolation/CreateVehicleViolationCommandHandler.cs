using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Helper;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.VehicleViolations.Commands.AddVehicleViolation
{
    public class CreateVehicleViolationCommandHandler : IRequestHandler<CreateVehicleViolationCommand, Response<CreateVehicleViolationDto>>
    {
        private readonly IQueueService _queueService;
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateVehicleViolationCommandHandler> _logger;

        public CreateVehicleViolationCommandHandler(IMapper mapper, IVehicleViolationRepository vehicleViolationRepository, ILogger<CreateVehicleViolationCommandHandler> logger, IQueueService queueService)
        {
            _mapper = mapper;
            _vehicleViolationRepository = vehicleViolationRepository;
            _logger = logger;
            _queueService = queueService;
        }
        public async Task<Response<CreateVehicleViolationDto>> Handle(CreateVehicleViolationCommand request, CancellationToken cancellationToken)
        {
           
            var vehicleViolationResponse = new Response<CreateVehicleViolationDto>();
            var vehicleViolation = _mapper.Map<VehicleViolation>(request);
            vehicleViolation = await _vehicleViolationRepository.AddAsync(vehicleViolation);
            await _queueService.SendMessageAsync<VehicleViolation>(vehicleViolation, "VehicleViolation");
            vehicleViolationResponse.Data = _mapper.Map<CreateVehicleViolationDto>(vehicleViolation);
            vehicleViolationResponse.Succeeded = true;
            vehicleViolationResponse.Message = "Success";
            return vehicleViolationResponse;
        }
    }
}