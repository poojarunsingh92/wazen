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

namespace WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationById
{
    public class GetTempVehicleViolationByIdQueryHandler : IRequestHandler<GetTempVehicleViolationByIdQuery, Response<GetTempVehicleViolationListVm>>
    {
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempVehicleViolationByIdQueryHandler(IMapper mapper, ITempVehicleViolationRepository tempVehicleViolationRepository, ILogger<GetTempVehicleViolationByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
            _logger = logger;
        }

        public async Task<Response<GetTempVehicleViolationListVm>> Handle(GetTempVehicleViolationByIdQuery request, CancellationToken cancellationToken)
        {
            var tempVehicleViolation = await _tempVehicleViolationRepository.GetByIdAsync(request.Id);
            if (tempVehicleViolation == null)
            {
                var resposeObject = new Response<GetTempVehicleViolationListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var vehicleViolationDto = _mapper.Map<GetTempVehicleViolationListVm>(tempVehicleViolation);
            var response = new Response<GetTempVehicleViolationListVm>(vehicleViolationDto, "success");
            return response;
        }
    }
}
