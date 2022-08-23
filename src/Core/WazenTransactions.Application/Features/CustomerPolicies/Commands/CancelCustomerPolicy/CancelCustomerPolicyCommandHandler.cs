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

namespace WazenTransactions.Application.Features.CustomerPolicies.Commands.CancelCustomerPolicy
{
    public class CancelCustomerPolicyCommandHandler : IRequestHandler<CancelCustomerPolicyCommand, Response<bool>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;

        public CancelCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository)
        {
            _mapper = mapper;
            _customerPolicyRepository= customerPolicyRepository;
        }
        public async Task<Response<bool>> Handle(CancelCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            for(int i=0;i<request.CancelPolicies.Count; i++)
            {
                var customerPolicyToUpdate = await _customerPolicyRepository.GetByIdAsync(request.CancelPolicies[i].ID);

                if (customerPolicyToUpdate == null)
                {
                    var resposeObject = new Response<bool>(request.CancelPolicies[i].ID + " is not available");
                    return resposeObject;
                }
                customerPolicyToUpdate.IsCancelled = true;
                _mapper.Map(request.CancelPolicies[i], customerPolicyToUpdate, typeof(CancelPolicy), typeof(WazenTransactions.Domain.Entities.CustomerPolicy));
                await _customerPolicyRepository.UpdateAsync(customerPolicyToUpdate);
            } 

            return new Response<bool>(true,"Updated successfully ");

        }
    }
}
