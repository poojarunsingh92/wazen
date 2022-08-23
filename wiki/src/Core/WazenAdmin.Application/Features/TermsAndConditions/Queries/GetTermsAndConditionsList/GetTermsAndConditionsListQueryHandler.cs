using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsList
{
    public class GetTermsAndConditionsListQueryHandler : IRequestHandler<GetTermsAndConditionsListQuery, Response<IEnumerable<TermsAndConditionsListVm>>>
    {
        private readonly ITermsAndConditionsRepository _termsAndConditionsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTermsAndConditionsListQueryHandler(IMapper mapper, ITermsAndConditionsRepository termsAndConditionsRepository, ILogger<GetTermsAndConditionsListQueryHandler> logger)
        {
            _mapper = mapper;
            _termsAndConditionsRepository = termsAndConditionsRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<TermsAndConditionsListVm>>> Handle(GetTermsAndConditionsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allAboutUs = (await _termsAndConditionsRepository.ListAllAsync()).OrderBy(x => x.ID);
            var aboutUs = _mapper.Map<IEnumerable<TermsAndConditionsListVm>>(allAboutUs);
            _logger.LogInformation("Handle Completed");

            return new Response<IEnumerable<TermsAndConditionsListVm>>(aboutUs, "success");
        }
    }
}


