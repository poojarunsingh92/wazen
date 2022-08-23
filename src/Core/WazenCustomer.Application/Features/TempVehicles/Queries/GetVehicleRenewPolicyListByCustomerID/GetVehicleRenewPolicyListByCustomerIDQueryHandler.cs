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

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleRenewPolicyListByCustomerID
{
    public class GetVehicleRenewPolicyListByCustomerIDQueryHandler : IRequestHandler<GetVehicleRenewPolicyListByCustomerIDQuery, Response<List<VehicleInformationss>>>
    {
        private readonly ILogger<GetVehicleRenewPolicyListByCustomerIDQueryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITempVehicleRepository _tempVehicleRepository;


        public GetVehicleRenewPolicyListByCustomerIDQueryHandler(ILogger<GetVehicleRenewPolicyListByCustomerIDQueryHandler> logger, IMediator mediator, IMapper mapper, ITempVehicleRepository tempVehicleRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _tempVehicleRepository = tempVehicleRepository;
        }

        public async Task<Response<List<VehicleInformationss>>> Handle(GetVehicleRenewPolicyListByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<VehicleInformationss>>();

            var vehicles = await _tempVehicleRepository.GetVehicleRenewPolicyCoverByCustomerID(request.CustomerID);
            response = new Response<List<VehicleInformationss>>(vehicles, "success");
            return response;
        }
    }
}
