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

namespace WazenAdmin.Application.Features.AboutUs.Queries.GetAboutUsList
{
    public class GetAboutUsListQueryHandler : IRequestHandler<GetAboutUsListQuery, Response<IEnumerable<AboutUsListVm>>>
    {
        private readonly IAboutUsRepository _aboutusRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAboutUsListQueryHandler(IMapper mapper, IAboutUsRepository aboutusRepository, ILogger<GetAboutUsListQueryHandler> logger)
        {
            _mapper = mapper;
            _aboutusRepository = aboutusRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<AboutUsListVm>>> Handle(GetAboutUsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allAboutUs = (await _aboutusRepository.ListAllAsync()).OrderBy(x => x.ID);
            var aboutUs = _mapper.Map<IEnumerable<AboutUsListVm>>(allAboutUs);
            _logger.LogInformation("Handle Completed");
            
            return new Response<IEnumerable<AboutUsListVm>>(aboutUs, "success");
        }
    }
}

