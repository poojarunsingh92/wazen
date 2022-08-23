using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Exceptions;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.DeleteCustomerPolicy
{
    public class DeleteCustomerPolicyCommandHandler : IRequestHandler<DeleteCustomerPolicyCommand>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly ILogger<DeleteCustomerPolicyCommandHandler> _logger;

        public DeleteCustomerPolicyCommandHandler(ICustomerPolicyRepository customerPolicyRepository, ILogger<DeleteCustomerPolicyCommandHandler> logger)
        {
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var customerToDelete = await _customerPolicyRepository.GetByIdAsync(request.ID);
            if (customerToDelete == null)
            {
                throw new NotFoundException(nameof(WazenPolicy.Domain.Entities.CustomerPolicy), request.ID);
            }
            await _customerPolicyRepository.DeleteAsync(customerToDelete);
            _logger.LogInformation("Handle Completed");
            return Unit.Value;
        }
    }
}
