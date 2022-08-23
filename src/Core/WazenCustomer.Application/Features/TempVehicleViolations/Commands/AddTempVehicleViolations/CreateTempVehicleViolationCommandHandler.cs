using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Helper;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Commands.AddTempVehicleViolations
{
    public class CreateTempVehicleViolationCommandHandler : IRequestHandler<CreateTempVehicleViolationCommand, Response<CreateTempVehicleViolationDto>>
    {
        private readonly IQueueService _queueService;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTempVehicleViolationCommandHandler> _logger;

        public CreateTempVehicleViolationCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository, ITempVehicleRepository tempVehicleRepository, IVehicleViolationRepository vehicleViolationRepository, ITempVehicleViolationRepository tempVehicleViolationRepository, ILogger<CreateTempVehicleViolationCommandHandler> logger, IQueueService queueService)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _tempVehicleRepository = tempVehicleRepository;
            _vehicleViolationRepository = vehicleViolationRepository;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
            _logger = logger;
            _queueService = queueService;
        }
        public async Task<Response<CreateTempVehicleViolationDto>> Handle(CreateTempVehicleViolationCommand request, CancellationToken cancellationToken)
        {
            var tempVehicleViolationResponse = new Response<CreateTempVehicleViolationDto>();
            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleID);

            if (vehicle != null)
            {
                var vehicleViolation = _mapper.Map<VehicleViolation>(request);
                vehicleViolation = await _vehicleViolationRepository.AddAsync(vehicleViolation);
                await _queueService.SendMessageAsync<VehicleViolation>(vehicleViolation, "VehicleViolation");
                tempVehicleViolationResponse.Data = _mapper.Map<CreateTempVehicleViolationDto>(vehicleViolation);
                tempVehicleViolationResponse.Succeeded = true;
                tempVehicleViolationResponse.Message = "Success";
            }
            else
            {
                var tempVehicle = await _tempVehicleRepository.GetByIdAsync(request.VehicleID);
                if(tempVehicle!=null)
                {
                    var tempVehicleViolation = _mapper.Map<TempVehicleViolation>(request);
                    tempVehicleViolation = await _tempVehicleViolationRepository.AddAsync(tempVehicleViolation);
                    await _queueService.SendMessageAsync<TempVehicleViolation>(tempVehicleViolation, "TempVehicleViolation");
                    tempVehicleViolationResponse.Data = _mapper.Map<CreateTempVehicleViolationDto>(tempVehicleViolation);
                    tempVehicleViolationResponse.Succeeded = true;
                    tempVehicleViolationResponse.Message = "Success";
                }                
            }
            return tempVehicleViolationResponse;
        }
    }
}