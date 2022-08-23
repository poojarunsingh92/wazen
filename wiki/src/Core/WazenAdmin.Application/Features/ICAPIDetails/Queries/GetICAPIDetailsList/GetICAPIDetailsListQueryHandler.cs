using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsList
{
    public class GetICAPIDetailsListQueryHandler : IRequestHandler<GetICAPIDetailsListQuery, Response<IEnumerable<ICAPIDetailsListVm>>>
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetICAPIDetailsListQueryHandler(IMapper mapper, IICAPIDetailRepository iCAPIDetailsRepository, ILogger<GetICAPIDetailsListQueryHandler> logger)
        {
            _mapper = mapper;
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ICAPIDetailsListVm>>> Handle(GetICAPIDetailsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allICAPIDetails = (await _iCAPIDetailsRepository.ListAllAsync()).OrderBy(x => x.ID);
            var icapidetails = _mapper.Map<IEnumerable<ICAPIDetailsListVm>>(allICAPIDetails);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<ICAPIDetailsListVm>>(icapidetails, "success");
        }
    }
}
