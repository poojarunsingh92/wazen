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

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleUpgradePolicyListByCustomerID
{
    public class GetVehicleUpgradePolicyListByCustomerIDQueryHandler : IRequestHandler<GetVehicleUpgradePolicyListByCustomerIDQuery, Response<List<VehicleInformations>>>
    {
        private readonly ILogger<GetVehicleUpgradePolicyListByCustomerIDQueryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITempVehicleRepository _tempVehicleRepository;


        public GetVehicleUpgradePolicyListByCustomerIDQueryHandler(ILogger<GetVehicleUpgradePolicyListByCustomerIDQueryHandler> logger, IMediator mediator, IMapper mapper,ITempVehicleRepository tempVehicleRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _tempVehicleRepository = tempVehicleRepository;
        }

        public async Task<Response<List<VehicleInformations>>> Handle(GetVehicleUpgradePolicyListByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<VehicleInformations>>();

            var vehicles = await _tempVehicleRepository.GetVehicleUpgradePolicyCoverByCustomerID(request.CustomerID);
            response = new Response<List<VehicleInformations>>(vehicles, "success");
            return response;
        }
    }
}
