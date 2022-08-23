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

namespace WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPoliciesByCustomerID
{
    public class GetCustomerPoliciesByCustomerIDQueryHandler : IRequestHandler<GetCustomerPoliciesByCustomerIDQuery, Response<IEnumerable<CustomerPoliciesByCustomerIDVm>>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerPolicyRepository _customerPolicyRepository;

        public GetCustomerPoliciesByCustomerIDQueryHandler(ILogger<GetCustomerPoliciesByCustomerIDQueryHandler> logger, IMapper mapper, ICustomerPolicyRepository customerPolicyRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
        }

        public async Task<Response<IEnumerable<CustomerPoliciesByCustomerIDVm>>> Handle(GetCustomerPoliciesByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var allPolicies = await _customerPolicyRepository.GetCustomerPolicyListByCustomerID(request.CustomerID);

            var customerPolicyList = _mapper.Map<List<CustomerPoliciesByCustomerIDVm>>(allPolicies);
            var response = new Response<IEnumerable<CustomerPoliciesByCustomerIDVm>>(customerPolicyList);
            return response;
        }
    }
}
