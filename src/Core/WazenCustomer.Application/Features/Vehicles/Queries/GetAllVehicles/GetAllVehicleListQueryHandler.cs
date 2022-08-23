using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetAllVehicles
{
    public class GetAllVehicleListQueryHandler : IRequestHandler<GetAllVehicleListQuery, Response<IEnumerable<VehicleListVm>>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public GetAllVehicleListQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }
        public async Task<Response<IEnumerable<VehicleListVm>>> Handle(GetAllVehicleListQuery request, CancellationToken cancellationToken)
        {
            var allVehicles = await _vehicleRepository.ListAllAsync();
            var VehicleList = _mapper.Map<List<VehicleListVm>>(allVehicles);
            var response = new Response<IEnumerable<VehicleListVm>>(VehicleList);
            return response;
        }
    }
}
