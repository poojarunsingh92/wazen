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

namespace WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentsList
{
    public class GetStaticContentsListQueryHandler : IRequestHandler<GetStaticContentsListQuery, Response<IEnumerable<StaticContentListVm>>>
    {
        private readonly IStaticContentRepository _staticContentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetStaticContentsListQueryHandler(IMapper mapper, IStaticContentRepository staticContentRepository, ILogger<GetStaticContentsListQueryHandler> logger)
        {
            _mapper = mapper;
            _staticContentRepository = staticContentRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<StaticContentListVm>>> Handle(GetStaticContentsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allStaticContents = (await _staticContentRepository.ListAllAsync()).OrderBy(x => x.ID);
            var staticContent = _mapper.Map<IEnumerable<StaticContentListVm>>(allStaticContents);
            _logger.LogInformation("Handle Completed");
            if (staticContent == null)
            {
                var resposeObject = new Response<IEnumerable<StaticContentListVm>>("No record is not available");
                return resposeObject;
            }
            return new Response<IEnumerable<StaticContentListVm>>(staticContent, "success");
        }
    }
}
