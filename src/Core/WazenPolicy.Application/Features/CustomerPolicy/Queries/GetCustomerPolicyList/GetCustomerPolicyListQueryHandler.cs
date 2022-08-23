using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerPolicyList
{
    public class GetCustomerPolicyListQueryHandler : IRequestHandler<GetCustomerPolicyListQuery, Response<IEnumerable<CustomerPolicyListVm>>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCustomerPolicyListQueryHandler> _logger;

        public GetCustomerPolicyListQueryHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<GetCustomerPolicyListQueryHandler> logger)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CustomerPolicyListVm>>> Handle(GetCustomerPolicyListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allCustomerPolicies = (await _customerPolicyRepository.ListAllAsync()).OrderBy(x => x.ID);

            var customerPolicies = _mapper.Map<IEnumerable<CustomerPolicyListVm>>(allCustomerPolicies);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<CustomerPolicyListVm>>(customerPolicies, "success");
        }
    }
}
