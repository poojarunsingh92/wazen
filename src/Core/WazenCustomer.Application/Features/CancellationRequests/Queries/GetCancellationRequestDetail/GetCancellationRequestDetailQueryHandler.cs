using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.CancellationRequests.Queries.GetCancellationRequestDetail
{
    public class GetCancellationRequestDetailQueryHandler : IRequestHandler<GetCancellationRequestDetailQuery, Response<CancellationRequestDetailVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICancellationRequestRepository _cancellationRequestRepository;

        public GetCancellationRequestDetailQueryHandler(IMapper mapper, ICancellationRequestRepository cancellationRequestRepository, ILogger<GetCancellationRequestDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _cancellationRequestRepository = cancellationRequestRepository;
            _logger = logger;

        }
        public async Task<Response<CancellationRequestDetailVm>> Handle(GetCancellationRequestDetailQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var cancellationRequest = await _cancellationRequestRepository.GetByIdAsync(request.ID);
            if (cancellationRequest == null)
            {
                var resposeObject = new Response<CancellationRequestDetailVm>(request.ID + " is not available");
                return resposeObject;
            }

            var cancellationRequestDetailDto = _mapper.Map<CancellationRequestDetailVm>(cancellationRequest);
            var response = new Response<CancellationRequestDetailVm>(cancellationRequestDetailDto);
            _logger.LogInformation("Handle Completed");
            return response;
        }
    }
}
