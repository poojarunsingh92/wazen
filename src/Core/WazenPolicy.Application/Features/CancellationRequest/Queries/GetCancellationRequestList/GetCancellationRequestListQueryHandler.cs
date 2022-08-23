using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WazenPolicy.Application.Features.CancellationRequest.Queries.GetCancellationRequestList
{
    public class GetCancellationRequestListQueryHandler : IRequestHandler<GetCancellationRequestListQuery, Response<IEnumerable<CancellationRequestListVm>>>
    {
        private readonly ICancellationRequestRepository _cancellationRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetCancellationRequestListQueryHandler(IMapper mapper, ICancellationRequestRepository cancellationRequestRepository, ILogger<GetCancellationRequestListQueryHandler> logger)
        {
            _mapper = mapper;
            _cancellationRequestRepository = cancellationRequestRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CancellationRequestListVm>>> Handle(GetCancellationRequestListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allcancellationRequestRepository = (await _cancellationRequestRepository.ListAllAsync()).OrderBy(x => x.ID);
            var edu = _mapper.Map<IEnumerable<CancellationRequestListVm>>(allcancellationRequestRepository);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<CancellationRequestListVm>>(edu, "success");
        }
    }
}
