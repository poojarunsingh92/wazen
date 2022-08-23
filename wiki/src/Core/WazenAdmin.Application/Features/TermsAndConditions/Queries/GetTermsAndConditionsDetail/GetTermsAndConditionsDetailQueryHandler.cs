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

namespace WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsDetail
{
    public class GetTermsAndConditionsDetailQueryHandler : IRequestHandler<GetTermsAndConditionsDetailQuery, Response<TermsAndConditionsDetailVm>>
    {
        private readonly ITermsAndConditionsRepository _termsAndConditionsRepository;
        private readonly IMapper _mapper;

        public GetTermsAndConditionsDetailQueryHandler(IMapper mapper, ITermsAndConditionsRepository termsAndConditionsRepository, ILogger<GetTermsAndConditionsDetailQuery> logger)
        {
            _mapper = mapper;
            _termsAndConditionsRepository = termsAndConditionsRepository;
        }
        public async Task<Response<TermsAndConditionsDetailVm>> Handle(GetTermsAndConditionsDetailQuery request, CancellationToken cancellationToken)
        {
            var TandC = await _termsAndConditionsRepository.GetByIdAsync(request.ID);
            if (TandC == null)
            {
                var resposeObject = new Response<TermsAndConditionsDetailVm>(request.ID + " is not available");
                return resposeObject;
            }

            var TandCDto = _mapper.Map<TermsAndConditionsDetailVm>(TandC);

            var response = new Response<TermsAndConditionsDetailVm>(TandCDto, "success");
            return response;
        }
    }
}
