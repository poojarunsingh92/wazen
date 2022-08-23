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

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateExistingCustomerPolicyCommand
{
    public class UpdateExistingCustomerPolicyCommandHandler : IRequestHandler<UpdateExistingCustomerPolicyCommand, Response<Guid>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateExistingCustomerPolicyCommandHandler> _logger;

        public UpdateExistingCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<UpdateExistingCustomerPolicyCommandHandler> logger)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;
        }

        public async Task<Response<Guid>> Handle(UpdateExistingCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var customerToUpdate = await _customerPolicyRepository.GetExistingCustomerPolicyAsync(request.CustomerVehicleID);

            if (customerToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.CustomerVehicleID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateExistingCustomerPolicyCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, customerToUpdate, typeof(UpdateExistingCustomerPolicyCommand), typeof(WazenPolicy.Domain.Entities.CustomerPolicy));

            await _customerPolicyRepository.UpdateAsync(customerToUpdate);

            _logger.LogInformation("Handle Completed");

            return new Response<Guid>(request.CustomerVehicleID, "Updated successfully ");
        }
    }
}
