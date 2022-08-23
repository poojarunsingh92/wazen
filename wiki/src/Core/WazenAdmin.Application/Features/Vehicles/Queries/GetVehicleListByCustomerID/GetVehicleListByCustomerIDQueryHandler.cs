using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID
{
    public class GetVehicleListByCustomerIDQueryHandler : IRequestHandler<GetVehicleListByCustomerIDQuery, Response<IEnumerable<VehicleListByCustomerIDVm>>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetVehicleListByCustomerIDQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository, ILogger<GetVehicleListByCustomerIDQueryHandler> logger)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<VehicleListByCustomerIDVm>>> Handle(GetVehicleListByCustomerIDQuery request, CancellationToken cancellationToken)
        {            
            var Vehicles = await _vehicleRepository.GetVehicleListByCustomerID(request.CustomerID);

            var vehicleyList = _mapper.Map<List<VehicleListByCustomerIDVm>>(Vehicles);
            var response = new Response<IEnumerable<VehicleListByCustomerIDVm>>(vehicleyList);
            return response;
        }
    }
}
