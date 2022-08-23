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

namespace WazenCustomer.Application.Features.TempVehicles.Commands.CreateTempVehicle
{
    public class CreateTempVehicleCommandHandler : IRequestHandler<CreateTempVehicleCommand, Response<CreateTempVehicleDto>>
    {
        private readonly IQueueService _queueService;
        private readonly IMapper _mapper;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly ILogger<CreateTempVehicleCommandHandler> _logger;

        public CreateTempVehicleCommandHandler(IMapper mapper, ITempVehicleRepository tempVehicleRepository, ILogger<CreateTempVehicleCommandHandler> logger , IQueueService queueService)
        {
            _mapper = mapper;
            _tempVehicleRepository = tempVehicleRepository;
            _logger = logger;
            _queueService = queueService;
        }

        public async Task<Response<CreateTempVehicleDto>> Handle(CreateTempVehicleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var tempVehicleResponse = new Response<CreateTempVehicleDto>();
            var tempVehicle = _mapper.Map<TempVehicle>(request);
            tempVehicle.VehiclePurposeId = 1;
            tempVehicle.VehiclePlateType = "PlateType";
            int percent = 100;
            tempVehicle.VehicleUsagePercentage = percent.ToString();
            tempVehicle.ParkingGarage = true;
            tempVehicle.IsSelected = true;
            tempVehicle = await _tempVehicleRepository.AddAsync(tempVehicle);
            await _queueService.SendMessageAsync<TempVehicle>(tempVehicle, "TempVehicle");

            tempVehicleResponse.Data = _mapper.Map<CreateTempVehicleDto>(tempVehicle);
            tempVehicleResponse.Succeeded = true;
            tempVehicleResponse.Message = "Success";
            _logger.LogInformation("Handle Completed");
            return tempVehicleResponse;
        }
    }
}