using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Exceptions;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.CustomerPolicies.Commands.DeleteCustomerPolicy
{
    public class DeleteCustomerPolicyCommandHandler : IRequestHandler<DeleteCustomerPolicyCommand>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerPolicyCommandHandler> _logger;

        public DeleteCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<DeleteCustomerPolicyCommandHandler> logger)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;

        }
        public async Task<Unit> Handle(DeleteCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerPolicyRepository.GetByIdAsync(request.ID);
            if (customerToDelete == null)
            {
                throw new NotFoundException(nameof(CustomerPolicy), request.ID);
            }
            await _customerPolicyRepository.DeleteAsync(customerToDelete);
            return Unit.Value;
        }
    }
}
