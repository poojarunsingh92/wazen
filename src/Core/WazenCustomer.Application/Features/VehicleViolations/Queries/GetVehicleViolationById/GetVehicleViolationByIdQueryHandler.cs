using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehicleViolations.Queries.GetVehicleViolationById
{
    public class GetVehicleViolationByIdQueryHandler : IRequestHandler<GetVehicleViolationByIdQuery, Response<GetVehicleViolationListVm>>
    {
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetVehicleViolationByIdQueryHandler(IMapper mapper, IVehicleViolationRepository vehicleViolationRepository, ILogger<GetVehicleViolationByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _vehicleViolationRepository = vehicleViolationRepository;
            _logger = logger;
        }

        public async Task<Response<GetVehicleViolationListVm>> Handle(GetVehicleViolationByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicleViolation = await _vehicleViolationRepository.GetByIdAsync(request.Id);
            if (vehicleViolation == null)
            {
                var resposeObject = new Response<GetVehicleViolationListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var vehicleViolationDto = _mapper.Map<GetVehicleViolationListVm>(vehicleViolation);
            var response = new Response<GetVehicleViolationListVm>(vehicleViolationDto, "success");
            return response;
        }
    }
}
