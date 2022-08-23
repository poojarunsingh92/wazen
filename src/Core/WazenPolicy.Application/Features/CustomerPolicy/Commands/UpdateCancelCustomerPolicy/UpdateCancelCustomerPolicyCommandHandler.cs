using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Exceptions;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateCancelCustomerPolicy
{
    public class UpdateCancelCustomerPolicyCommandHandler : IRequestHandler<UpdateCancelCustomerPolicyCommand, Response<Guid>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCancelCustomerPolicyCommandHandler> _logger;

        public UpdateCancelCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<UpdateCancelCustomerPolicyCommandHandler> logger)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;
        }

        public async Task<Response<Guid>> Handle(UpdateCancelCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var customerToUpdate = await _customerPolicyRepository.GetByIdAsync(request.ID);

            if (customerToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateCancelCustomerPolicyCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, customerToUpdate, typeof(UpdateCancelCustomerPolicyCommand), typeof(WazenPolicy.Domain.Entities.CustomerPolicy));

            await _customerPolicyRepository.UpdateAsync(customerToUpdate);

            _logger.LogInformation("Handle Completed");

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
