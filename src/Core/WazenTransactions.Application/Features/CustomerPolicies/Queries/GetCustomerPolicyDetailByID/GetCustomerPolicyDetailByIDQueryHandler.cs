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

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyDetailByID
{
    public class GetCustomerPolicyDetailByIDQueryHandler : IRequestHandler<GetCustomerPolicyDetailByIDQuery, Response<CustomerPolicyDetailVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICustomerPolicyRepository _customerPolicyRepository;

        public GetCustomerPolicyDetailByIDQueryHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<GetCustomerPolicyDetailByIDQueryHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _customerPolicyRepository = customerPolicyRepository;
        }

        public async Task<Response<CustomerPolicyDetailVm>> Handle(GetCustomerPolicyDetailByIDQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var customerPolicy =  await _customerPolicyRepository.GetByIdAsync(request.ID);
            if(customerPolicy==null)
            {
                var resposeObject = new Response<CustomerPolicyDetailVm>(request.ID + " is not available");
                return resposeObject;
            }
            var customerPolicyDetailDto = _mapper.Map<CustomerPolicyDetailVm>(customerPolicy);
            var response = new Response<CustomerPolicyDetailVm>(customerPolicyDetailDto, "success");
            _logger.LogInformation("Handle Completed");
            return response;
        }
    }
}
