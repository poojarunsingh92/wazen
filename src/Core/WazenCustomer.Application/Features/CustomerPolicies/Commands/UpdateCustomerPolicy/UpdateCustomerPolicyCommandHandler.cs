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

namespace WazenCustomer.Application.Features.CustomerPolicies.Commands.UpdateCustomerPolicy
{
    public class UpdateCustomerPolicyCommandHandler : IRequestHandler<UpdateCustomerPolicyCommand, Response<Guid>>
    {

        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerPolicyCommandHandler> _logger;

        public UpdateCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<UpdateCustomerPolicyCommandHandler> logger)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;

        }
        public async Task<Response<Guid>> Handle(UpdateCustomerPolicyCommand request, CancellationToken cancellationToken)
        {

            var customerPolicyToUpdate = await _customerPolicyRepository.GetByIdAsync(request.ID);

            if (customerPolicyToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            _mapper.Map(request, customerPolicyToUpdate, typeof(UpdateCustomerPolicyCommand), typeof(CustomerPolicy));
            await _customerPolicyRepository.UpdateAsync(customerPolicyToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
