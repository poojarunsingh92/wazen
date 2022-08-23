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
using WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationListByVehicleID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationListByVehicleID
{
    public class GetTempVehicleViolationListByVehicleIDQueryHandler : IRequestHandler<GetTempVehicleViolationListByVehicleIDQuery, Response<List<VehicleViolationListVm>>>
    {
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempVehicleViolationListByVehicleIDQueryHandler(IMapper mapper, ITempVehicleViolationRepository tempVehicleViolationRepository, ILogger<GetTempVehicleViolationListByVehicleIDQueryHandler> logger)
        {
            _mapper = mapper;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
            _logger = logger;
        }

        public async Task<Response<List<VehicleViolationListVm>>> Handle(GetTempVehicleViolationListByVehicleIDQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var tempVehicleViolations = (await _tempVehicleViolationRepository.GetTempVehicleViolationListByVehicleID(request.VehicleID)).OrderBy(x => x.ID);

            var violations = _mapper.Map<List<VehicleViolationListVm>>(tempVehicleViolations);
            _logger.LogInformation("Hanlde Completed");
            return new Response<List<VehicleViolationListVm>>(violations, "success");
        }
    }
}
