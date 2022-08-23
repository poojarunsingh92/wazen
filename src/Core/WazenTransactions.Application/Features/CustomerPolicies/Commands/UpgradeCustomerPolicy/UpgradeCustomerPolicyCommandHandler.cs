using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Features.CustomerPolicies.Commands.UpgradeCustomerPolicy
{
    public class UpgradeCustomerPolicyCommandHandler : IRequestHandler<UpgradeCustomerPolicyCommand, Response<bool>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;

        public UpgradeCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
        }
        public async Task<Response<bool>> Handle(UpgradeCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            for (int i = 0; i < request.UpgradePolicies.Count; i++)
            {
                var customerPolicyToUpdate = await _customerPolicyRepository.GetByIdAsync(request.UpgradePolicies[i].ID);

                if (customerPolicyToUpdate == null)
                {
                    var resposeObject = new Response<bool>(request.UpgradePolicies[i].ID + " is not available");
                    return resposeObject;
                }

                customerPolicyToUpdate.PolicyTypeId = 2;
                customerPolicyToUpdate.IsUpgraded = true;
                _mapper.Map(request.UpgradePolicies[i], customerPolicyToUpdate, typeof(UpgradePolicy), typeof(WazenTransactions.Domain.Entities.CustomerPolicy));
                await _customerPolicyRepository.UpdateAsync(customerPolicyToUpdate);
            }  
            return new Response<bool>(true, "Updated successfully ");
        }
    }
}
