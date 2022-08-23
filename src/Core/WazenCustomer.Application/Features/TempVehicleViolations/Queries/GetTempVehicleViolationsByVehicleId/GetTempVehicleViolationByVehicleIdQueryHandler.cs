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

namespace WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationsByVehicleId
{
    public class GetTempVehicleViolationByVehicleIdQueryHandler : IRequestHandler<GetTempVehicleViolationByVehicleIdQuery, Response<IEnumerable<GetTempVehicleViolationByVehicleIdListVm>>>
    {
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempVehicleViolationByVehicleIdQueryHandler(IMapper mapper, ITempVehicleViolationRepository tempVehicleViolationRepository, ILogger<GetTempVehicleViolationByVehicleIdQueryHandler> logger)
        {
            _mapper = mapper;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetTempVehicleViolationByVehicleIdListVm>>> Handle(GetTempVehicleViolationByVehicleIdQuery request, CancellationToken cancellationToken)
        {
            var allTempVehicleViolations = await _tempVehicleViolationRepository.GetTempVehicleViolationsByVehicleID(request.VehicleId);
            var TempVehicleViolationList = _mapper.Map<List<GetTempVehicleViolationByVehicleIdListVm>>(allTempVehicleViolations);
            var response = new Response<IEnumerable<GetTempVehicleViolationByVehicleIdListVm>>(TempVehicleViolationList);
            return response;
        }
    }
}
