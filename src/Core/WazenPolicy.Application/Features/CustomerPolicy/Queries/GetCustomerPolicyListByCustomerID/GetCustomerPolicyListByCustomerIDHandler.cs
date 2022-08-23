using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerPolicyListByCustomerID
{
    public class GetCustomerPolicyListByCustomerIDHandler : IRequestHandler<GetCustomerPolicyListByCustomerIDQuery, Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>>
    {
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;

        public GetCustomerPolicyListByCustomerIDHandler(IMapper mapper, ICustomerVehicleRepository customerVehicleRepository, ICustomerPolicyRepository customerPolicyRepository, ILogger<GetCustomerPolicyListByCustomerIDHandler> logger)
        {
            _mapper = mapper;
            _customerVehicleRepository = customerVehicleRepository;
            _customerPolicyRepository = customerPolicyRepository;
        }
        public async Task<Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>> Handle(GetCustomerPolicyListByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var customerVehicles = await _customerVehicleRepository.GetCustomerVehicleListByCustomerID(request.CustomerID);
            if (customerVehicles == null)
            {
                var resposeObject = new Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>(request.CustomerID + " is not available");
                return resposeObject;
            }
            var customerPolicies = new List<GetCustomerPolicyListByCustomerIDVm>();
            foreach (var vehicle in customerVehicles)
            {
                var customerPolicy = await _customerPolicyRepository.GetCustomerPolicyByCustomerVehicleID(vehicle.ID);
                var policy = _mapper.Map<GetCustomerPolicyListByCustomerIDVm>(customerPolicy);
                if(policy==null)
                {
                    continue;
                }
                customerPolicies.Add(policy);
            }
                
            var response = new Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>(customerPolicies);
            return response;
        }
    }
}
