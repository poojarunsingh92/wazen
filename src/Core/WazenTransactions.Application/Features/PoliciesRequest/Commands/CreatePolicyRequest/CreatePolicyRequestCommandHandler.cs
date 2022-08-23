using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Features.PoliciesRequest.Commands.CreatePolicyRequest
{
   public class CreatePolicyRequestCommandHandler : IRequestHandler<CreatePolicyRequestCommand, Response<CreatePolicyRequestDto>>
    {

        private readonly IPolicyRequestRepository _policyRequestRepository;
        private readonly IMapper _mapper;

        public CreatePolicyRequestCommandHandler(IMapper mapper, IPolicyRequestRepository policyRequestRepository)
        {
            _mapper = mapper;
            _policyRequestRepository = policyRequestRepository;
        }

        public async Task<Response<CreatePolicyRequestDto>> Handle(CreatePolicyRequestCommand request, CancellationToken cancellationToken)
        {
            var createPolicyRequestCommandResponse = new Response<CreatePolicyRequestDto>();

            var validator = new CreatePolicyRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createPolicyRequestCommandResponse.Succeeded = false;
                createPolicyRequestCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createPolicyRequestCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var policyRequest = new PolicyRequest()
                {
                    InsurancePolicy_ProductName = request.InsurancePolicy_ProductName,
                    NationalityID = request.NationalID,
                    PolicyEffectiveDate = request.PolicyEffectiveDate,
                    PolicyDuration = request.PolicyDuration,
                    PolicyAmount = request.PolicyAmount,
                    RequestType = request.RequestType,
                    Status = request.Status
                };

                policyRequest = await _policyRequestRepository.AddAsync(policyRequest);
                createPolicyRequestCommandResponse.Data = _mapper.Map<CreatePolicyRequestDto>(policyRequest);
                createPolicyRequestCommandResponse.Succeeded = true;
                createPolicyRequestCommandResponse.Message = "success";
            }

            return createPolicyRequestCommandResponse;

        }
    }
}
