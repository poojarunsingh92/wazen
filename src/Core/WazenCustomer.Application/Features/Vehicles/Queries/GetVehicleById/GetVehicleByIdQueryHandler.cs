using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleById
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Response<VehicleVm>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public GetVehicleByIdQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }
        public async System.Threading.Tasks.Task<Response<VehicleVm>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
            if (vehicle == null)
            {
                var resposeObject = new Response<VehicleVm>(request.Id + " is not available");
                return resposeObject;
            }

            var vehicleDto = _mapper.Map<VehicleVm>(vehicle);
            var response = new Response<VehicleVm>(vehicleDto, "success");
            return response;
        }
    }
}
