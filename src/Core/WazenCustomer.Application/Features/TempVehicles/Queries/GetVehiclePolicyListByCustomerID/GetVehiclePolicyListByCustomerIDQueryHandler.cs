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

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicyListByCustomerID
{
    public class GetVehiclePolicyListByCustomerIDQueryHandler : IRequestHandler<GetVehiclePolicyListByCustomerIDQuery, Response<List<VehicleInformation>>>
    {
        private readonly ILogger<GetVehiclePolicyListByCustomerIDQueryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        //private readonly ICustomerRepository _customerRepository;
        //private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        //private readonly ICustomerPolicyRepository _customerPolicyRepository;
        //private readonly IAdditionalCoverageRepository _additionalCoverageRepository;


        public GetVehiclePolicyListByCustomerIDQueryHandler(ILogger<GetVehiclePolicyListByCustomerIDQueryHandler> logger, IMediator mediator, IMapper mapper, /*ICustomerRepository customerRepository,*/ ITempCustomerRepository tempCustomerRepository, ITempVehicleRepository tempVehicleRepository, ICustomerPolicyRepository customerPolicyRepository, IAdditionalCoverageRepository additionalCoverageRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            //_customerRepository = customerRepository;
            _tempVehicleRepository = tempVehicleRepository;
            //_customerPolicyRepository = customerPolicyRepository;
            //_tempCustomerRepository = tempCustomerRepository;
            //_additionalCoverageRepository = additionalCoverageRepository;
        }

        public async Task<Response<List<VehicleInformation>>> Handle(GetVehiclePolicyListByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<VehicleInformation>>();

            var vehicles = _tempVehicleRepository.GetVehiclePolicyCoverByCustomerID(request.CustomerID);
            response = new Response<List<VehicleInformation>>(vehicles, "success");
            return response;
        }
    }
}
