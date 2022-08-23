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

namespace WazenAdmin.Application.Features.TempVehicles.Queries.GetTempVehicleListByTempCustomerID
{
    public class GetTempVehicleListByTempCustomerIDQueryHandler : IRequestHandler<GetTempVehicleListByTempCustomerIDQuery, Response<IEnumerable<TempVehicleListByTempCustomerIDVm>>>
    {
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetTempVehicleListByTempCustomerIDQueryHandler(IMapper mapper, ITempVehicleRepository tempVehicleRepository, ILogger<GetTempVehicleListByTempCustomerIDQueryHandler> logger)
        {
            _mapper = mapper;
            _tempVehicleRepository = tempVehicleRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<TempVehicleListByTempCustomerIDVm>>> Handle(GetTempVehicleListByTempCustomerIDQuery request, CancellationToken cancellationToken)
        {        
            var Vehicles = await _tempVehicleRepository.GetTempVehicleListByTempCustomerID(request.CustomerID);

            var vehicleyList = _mapper.Map<List<TempVehicleListByTempCustomerIDVm>>(Vehicles);
            var response = new Response<IEnumerable<TempVehicleListByTempCustomerIDVm>>(vehicleyList);
            return response;
        }
    }
}
