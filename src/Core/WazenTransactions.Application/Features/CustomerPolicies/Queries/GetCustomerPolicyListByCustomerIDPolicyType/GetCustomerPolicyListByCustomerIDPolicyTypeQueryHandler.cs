using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerIDPolicyType
{
    public class GetCustomerPolicyListByCustomerIDPolicyTypeQueryHandler : IRequestHandler<GetCustomerPolicyListByCustomerIDPolicyTypeQuery, Response<IEnumerable<CustomerPolicyListByCustomerIDPolicyTypeVm>>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerPolicyRepository _customerPolicyRepository;

        public GetCustomerPolicyListByCustomerIDPolicyTypeQueryHandler(ILogger<GetCustomerPolicyListByCustomerIDPolicyTypeQueryHandler> logger, IMapper mapper, ICustomerPolicyRepository customerPolicyRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
        }

        public async Task<Response<IEnumerable<CustomerPolicyListByCustomerIDPolicyTypeVm>>> Handle(GetCustomerPolicyListByCustomerIDPolicyTypeQuery request, CancellationToken cancellationToken)
        {
            var allCustomerPolicies = await _customerPolicyRepository.GetCustomerPolicyListByCustomerIDPolicyType(request.CustomerID, request.PolicyType);
            var customerPolicies = _mapper.Map<IEnumerable<CustomerPolicyListByCustomerIDPolicyTypeVm>>(allCustomerPolicies);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<CustomerPolicyListByCustomerIDPolicyTypeVm>>(customerPolicies, "success");
        }
    }
}
