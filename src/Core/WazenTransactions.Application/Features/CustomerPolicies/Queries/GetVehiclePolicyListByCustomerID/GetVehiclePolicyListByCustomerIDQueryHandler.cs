using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetVehiclePolicyListByCustomerID
{
    public class GetVehiclePolicyListByCustomerIDQueryHandler : IRequestHandler<GetVehiclePolicyListByCustomerIDQuery, Response<List<VehicleInformations>>>
    {
        private readonly ILogger<GetVehiclePolicyListByCustomerIDQueryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        //private readonly ICustomerRepository _customerRepository;
        //private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        //private readonly ICustomerPolicyRepository _customerPolicyRepository;
        //private readonly IAdditionalCoverageRepository _additionalCoverageRepository;


        public GetVehiclePolicyListByCustomerIDQueryHandler(ILogger<GetVehiclePolicyListByCustomerIDQueryHandler> logger, IMediator mediator, IMapper mapper, /*ICustomerRepository customerRepository,*/ ICustomerRepository customerRepository, IVehicleRepository vehicleRepository, ICustomerPolicyRepository customerPolicyRepository, IAdditionalCoverageRepository additionalCoverageRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            //_customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            //_customerPolicyRepository = customerPolicyRepository;
            //_tempCustomerRepository = tempCustomerRepository;
            //_additionalCoverageRepository = additionalCoverageRepository;
        }

        public async Task<Response<List<VehicleInformations>>> Handle(GetVehiclePolicyListByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<VehicleInformations>>();

            var vehicles = _vehicleRepository.GetVehiclePolicyCoverByCustomerID(request.CustomerID);
            response = new Response<List<VehicleInformations>>(vehicles, "success");
            return response;
        }
    }
}
