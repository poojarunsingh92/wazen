using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Features.Vehicles.Queries.GetVehicleDetailByID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempVehicles.Queries.GetTempVehicleDetailByID
{
    public class GetTempVehicleDetailByIDQueryHandler : IRequestHandler<GetTempVehicleDetailByIDQuery, Response<VehicleDetailVm>>
    {
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempVehicleDetailByIDQueryHandler(IMapper mapper, ITempVehicleRepository tempVehicleRepository, ILogger<GetTempVehicleDetailByIDQueryHandler> logger)
        {
            _mapper = mapper;
            _tempVehicleRepository = tempVehicleRepository;
            _logger = logger;
        }
        public async Task<Response<VehicleDetailVm>> Handle(GetTempVehicleDetailByIDQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _tempVehicleRepository.GetByIdAsync(request.ID);
            if (vehicle == null)
            {
                var resposeObject = new Response<VehicleDetailVm>(request.ID + " is not available");
                return resposeObject;
            }

            var vehicleDto = _mapper.Map<VehicleDetailVm>(vehicle);
            var response = new Response<VehicleDetailVm>(vehicleDto, "success");
            return response;

        }
    }
}
