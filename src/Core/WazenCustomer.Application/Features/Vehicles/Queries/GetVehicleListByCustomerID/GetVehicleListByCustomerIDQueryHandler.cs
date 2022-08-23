using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID
{
    public class GetVehicleListByCustomerIDQueryHandler : IRequestHandler<GetVehicleListByCustomerIDQuery, Response<IEnumerable<VehicleListByCustomerIDVm>>>
    {        
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehicleListByCustomerIDQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }
        public async Task<Response<IEnumerable<VehicleListByCustomerIDVm>>> Handle(GetVehicleListByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var allVehicles = await _vehicleRepository.GetVehicleListByCustomerID(request.CustomerID);
            var VehicleList = _mapper.Map<List<VehicleListByCustomerIDVm>>(allVehicles);
            var response = new Response<IEnumerable<VehicleListByCustomerIDVm>>(VehicleList);
            return response;
        }
    }
}
