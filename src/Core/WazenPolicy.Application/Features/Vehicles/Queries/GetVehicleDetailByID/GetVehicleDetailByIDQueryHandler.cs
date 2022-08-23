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

namespace WazenPolicy.Application.Features.Vehicles.Queries.GetVehicleDetailByID
{
    public class GetVehicleDetailByIDQueryHandler : IRequestHandler<GetVehicleDetailByIDQuery, Response<VehicleDetailVm>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetVehicleDetailByIDQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository, ILogger<GetVehicleDetailByIDQueryHandler> logger)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }
        public async Task<Response<VehicleDetailVm>> Handle(GetVehicleDetailByIDQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.ID);
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
