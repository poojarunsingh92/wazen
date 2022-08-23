using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationListByVehicleID
{
    class GetVehicleViolationListByVehicleIDQueryHandler : IRequestHandler<GetVehicleViolationListByVehicleIDQuery, Response<List<VehicleViolationListVm>>>
    {
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetVehicleViolationListByVehicleIDQueryHandler(IMapper mapper, IVehicleViolationRepository vehicleViolationRepository, ILogger<GetVehicleViolationListByVehicleIDQueryHandler> logger)
        {
            _mapper = mapper;
            _vehicleViolationRepository = vehicleViolationRepository;
            _logger = logger;
        }

        public async Task<Response<List<VehicleViolationListVm>>> Handle(GetVehicleViolationListByVehicleIDQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var tempVehicleViolations = (await _vehicleViolationRepository.GetVehicleViolationListByVehicleID(request.VehicleID)).OrderBy(x => x.ID);

            var violations = _mapper.Map<List<VehicleViolationListVm>>(tempVehicleViolations);
            _logger.LogInformation("Hanlde Completed");
            return new Response<List<VehicleViolationListVm>>(violations, "success");
        }
    }
}
