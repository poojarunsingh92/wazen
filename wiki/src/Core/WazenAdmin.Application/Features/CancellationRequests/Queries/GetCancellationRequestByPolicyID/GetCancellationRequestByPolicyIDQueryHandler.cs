using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.CancellationRequests.Queries.GetCancellationRequestByPolicyID
{
    public class GetCancellationRequestByPolicyIDQueryHandler : IRequestHandler<GetCancellationRequestByPolicyIDQuery, Response<CancellationRequestByPolicyIDVm>>
    {
        private readonly ICancellationRequestRepository _cancellationRequestRepository;
        private readonly IMapper _mapper;

        public GetCancellationRequestByPolicyIDQueryHandler(IMapper mapper, ICancellationRequestRepository cancellationRequestRepository)
        {
            _mapper = mapper;
            _cancellationRequestRepository = cancellationRequestRepository;
        }

        public async Task<Response<CancellationRequestByPolicyIDVm>> Handle(GetCancellationRequestByPolicyIDQuery request, CancellationToken cancellationToken)
        {
            var cancellationPolicy = await _cancellationRequestRepository.GetCancellationRequestByPolicyID(request.PolicyID);
            if (cancellationPolicy == null)
            {
                var resposeObject = new Response<CancellationRequestByPolicyIDVm>(request.PolicyID + " is not available");
                return resposeObject;
            }
            var staticContentDetailDto = _mapper.Map<CancellationRequestByPolicyIDVm>(cancellationPolicy);
            var response = new Response<CancellationRequestByPolicyIDVm>(staticContentDetailDto, "success");
            return response;
        }
    }
}
