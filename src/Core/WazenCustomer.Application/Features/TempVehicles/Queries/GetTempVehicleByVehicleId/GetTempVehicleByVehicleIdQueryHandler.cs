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

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByVehicleId
{
    public class GetTempVehicleByVehicleIdQueryHandler : IRequestHandler<GetTempVehicleByVehicleIdQuery, Response<TempVehicleByVehicleIdVm>>
    {

        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempVehicleByVehicleIdQueryHandler(IMapper mapper, ITempVehicleRepository tempVehicleRepository, ILogger<GetTempVehicleByVehicleIdQueryHandler> logger)
        {
            _mapper = mapper;
            _tempVehicleRepository = tempVehicleRepository;
            _logger = logger;
        }

        public async Task<Response<TempVehicleByVehicleIdVm>> Handle(GetTempVehicleByVehicleIdQuery request, CancellationToken cancellationToken)
        {
            var tempVehicle = await _tempVehicleRepository.GetByIdAsync(request.Id);
            if (tempVehicle == null)
            {
                var resposeObject = new Response<TempVehicleByVehicleIdVm>(request.Id + " is not available");
                return resposeObject;
            }

            var tempVehicleDetailDto = _mapper.Map<TempVehicleByVehicleIdVm>(tempVehicle);
            var response = new Response<TempVehicleByVehicleIdVm>(tempVehicleDetailDto, "success");
            return response;
        }
    }
}
