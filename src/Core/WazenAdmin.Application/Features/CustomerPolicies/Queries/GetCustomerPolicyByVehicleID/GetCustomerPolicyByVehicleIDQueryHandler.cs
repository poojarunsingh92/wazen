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

namespace WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyByVehicleID
{
    public class GetCustomerPolicyByVehicleIDQueryHandler : IRequestHandler<GetCustomerPolicyByVehicleIDQuery, Response<CustomerPolicyByVehicleIDVm>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCustomerPolicyByVehicleIDQueryHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<GetCustomerPolicyByVehicleIDQueryHandler> logger)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;
        }
        public async Task<Response<CustomerPolicyByVehicleIDVm>> Handle(GetCustomerPolicyByVehicleIDQuery request, CancellationToken cancellationToken)
        {

            var customerPolicy = await _customerPolicyRepository.GetCustomerPolicyByVehicleID(request.VehicleID);
            if (customerPolicy == null)
            {
                var resposeObject = new Response<CustomerPolicyByVehicleIDVm>(request.VehicleID + " is not available");
                return resposeObject;
            }

            var customerPolicyDto = _mapper.Map<CustomerPolicyByVehicleIDVm>(customerPolicy);
            var response = new Response<CustomerPolicyByVehicleIDVm>(customerPolicyDto, "success");
            return response;
        }
    }
}
