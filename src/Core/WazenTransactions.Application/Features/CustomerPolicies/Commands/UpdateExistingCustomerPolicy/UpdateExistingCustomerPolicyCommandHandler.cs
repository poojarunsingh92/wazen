using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;
using WazenTransactions.Application.Exceptions;
using WazenTransactions.Domain.Entities;
using WazenTransactions.Application.Features.CustomerPolicies.Commands.UpdateExistingCustomerPolicy;

namespace WazenTransactions.Application.Features.CustomerPolicies.Commands.UpdateExistingCustomerPolicy
{
    public class UpdateExistingCustomerPolicyCommandHandler : IRequestHandler<UpdateExistingCustomerPolicyCommand, Response<Guid>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;

        public UpdateExistingCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateExistingCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            /*
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

            _mapper.Map(request, customerToUpdate, typeof(UpdateExistingCustomerPolicyCommand), typeof(WazenTransactions.Domain.Entities.CustomerPolicy));

            await _customerPolicyRepository.UpdateAsync(customerToUpdate);

            return new Response<Guid>(request.CustomerVehicleID, "Updated successfully ");
            */
            return new Response<Guid>(Guid.NewGuid());
        }
    }
}


