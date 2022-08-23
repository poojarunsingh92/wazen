using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationDetailByVehicleID
{
    public class GetVehicleViolationDetailByVehicleIDQueryHandler : IRequestHandler<GetVehicleViolationDetailByVehicleIDQuery, Response<VehicleViolationDetailVm>>
    {
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetVehicleViolationDetailByVehicleIDQueryHandler(IMapper mapper, IVehicleViolationRepository vehicleViolationRepository, ILogger<GetVehicleViolationDetailByVehicleIDQueryHandler> logger)
        {
            _mapper = mapper;
            _vehicleViolationRepository = vehicleViolationRepository;
            _logger = logger;
        }
        public async Task<Response<VehicleViolationDetailVm>> Handle(GetVehicleViolationDetailByVehicleIDQuery request, CancellationToken cancellationToken)
        {
            var vehicleViolation = await _vehicleViolationRepository.GetVehicleViolationDetailByVehicleID(request.VehicleID);
            if (vehicleViolation == null)
            {
                var resposeObject = new Response<VehicleViolationDetailVm>(request.VehicleID + " is not available");
                return resposeObject;
            }

            var vehicleViolationDto = _mapper.Map<VehicleViolationDetailVm>(vehicleViolation);
            var response = new Response<VehicleViolationDetailVm>(vehicleViolationDto, "success");
            return response;
        }
    }
}
