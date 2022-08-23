using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.PolicyRequests.Queries.GetPolicyRequestList
{
    public class GetPolicyRequestListQueryHandler : IRequestHandler<GetPolicyRequestListQuery, Response<IEnumerable<PolicyRequestListVm>>>
    {
        private readonly IPolicyRequestRepository _policyRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetPolicyRequestListQueryHandler(IMapper mapper, IPolicyRequestRepository policyRequestRepository, ILogger<GetPolicyRequestListQueryHandler> logger)
        {
            _mapper = mapper;
            _policyRequestRepository = policyRequestRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<PolicyRequestListVm>>> Handle(GetPolicyRequestListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allPolicyRequests = (await _policyRequestRepository.ListAllAsync()).OrderBy(x => x.ID);
            var policyRequests = _mapper.Map<IEnumerable<PolicyRequestListVm>>(allPolicyRequests);
            _logger.LogInformation("Handle Completed");
            if (policyRequests == null)
            {
                var resposeObject = new Response<IEnumerable<PolicyRequestListVm>>("No record is not available");
                return resposeObject;
            }
            return new Response<IEnumerable<PolicyRequestListVm>>(policyRequests, "success");
        }
    }
}
