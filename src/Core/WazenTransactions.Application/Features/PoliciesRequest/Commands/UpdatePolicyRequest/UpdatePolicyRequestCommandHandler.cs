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

namespace WazenTransactions.Application.Features.PoliciesRequest.Commands.UpdatePolicyRequest
{
   public class UpdatePolicyRequestCommandHandler : IRequestHandler<UpdatePolicyRequestCommand, Response<Guid>>
    {
        private readonly IPolicyRequestRepository _policyRequestRepository;
        private readonly IMapper _mapper;

        public UpdatePolicyRequestCommandHandler(IMapper mapper, IPolicyRequestRepository policyRequestRepository)
        {
            _mapper = mapper;
            _policyRequestRepository = policyRequestRepository;
        }

        public async Task<Response<Guid>> Handle(UpdatePolicyRequestCommand request, CancellationToken cancellationToken)
        {
            var policyRequestToUpdate = await _policyRequestRepository.GetByIdAsync(request.ID);

            if (policyRequestToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdatePolicyRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

           // if (validationResult.Errors.Count > 0)
               // throw new ValidationException(validationResult);

            //_mapper.Map(request, policyRequestToUpdate, typeof(UpdatePolicyRequestCommand), typeof(Wazen.Domain.Entities.MedicalIssue));

            await _policyRequestRepository.UpdateAsync(policyRequestToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");

        }
    }
}
