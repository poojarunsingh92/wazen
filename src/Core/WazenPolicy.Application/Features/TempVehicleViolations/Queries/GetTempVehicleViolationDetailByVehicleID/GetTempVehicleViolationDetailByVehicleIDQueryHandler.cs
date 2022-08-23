using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationDetailByVehicleID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationDetailByVehicleID
{
    public class GetTempVehicleViolationDetailByVehicleIDQueryHandler : IRequestHandler<GetTempVehicleViolationDetailByVehicleIDQuery, Response<VehicleViolationDetailVm>>
    {
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempVehicleViolationDetailByVehicleIDQueryHandler(IMapper mapper, ITempVehicleViolationRepository tempVehicleViolationRepository, ILogger<GetTempVehicleViolationDetailByVehicleIDQueryHandler> logger)
        {
            _mapper = mapper;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
            _logger = logger;
        }
        public async Task<Response<VehicleViolationDetailVm>> Handle(GetTempVehicleViolationDetailByVehicleIDQuery request, CancellationToken cancellationToken)
        {
            var vehicleViolation = await _tempVehicleViolationRepository.GetTempVehicleViolationDetailByVehicleID(request.VehicleID);
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
