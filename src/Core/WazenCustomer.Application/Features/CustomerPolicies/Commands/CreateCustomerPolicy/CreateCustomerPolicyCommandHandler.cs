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
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.CustomerPolicies.Commands.CreateCustomerPolicy
{
    public class CreateCustomerPolicyCommandHandler : IRequestHandler<CreateCustomerPolicyCommand, Response<CustomerPolicyDto>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerPolicyCommandHandler> _logger;
     
        public CreateCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<CreateCustomerPolicyCommandHandler> logger)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;
            
        }
        public async Task<Response<CustomerPolicyDto>> Handle(CreateCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            
            var customerPolicyResponse = new Response<CustomerPolicyDto>();
            var customerPolicy = _mapper.Map<CustomerPolicy>(request);
            customerPolicy = await _customerPolicyRepository.AddAsync(customerPolicy);
            customerPolicyResponse.Data = _mapper.Map<CustomerPolicyDto>(customerPolicy);
            customerPolicyResponse.Succeeded = true;
            customerPolicyResponse.Message = "Success";
            return customerPolicyResponse;
        }
    }
}
