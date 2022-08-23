using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.FAQ.Queries.GetFAQDetail
{
    public class GetFAQDetailQueryHandler : IRequestHandler<GetFAQDetailQuery, Response<FAQDetailVm>>
    {
        private readonly IFAQRepository _faqRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFAQDetailQueryHandler(IMapper mapper, IFAQRepository faqRepository, ILogger<GetFAQDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _logger = logger;
        }

        public async Task<Response<FAQDetailVm>> Handle(GetFAQDetailQuery request, CancellationToken cancellationToken)
        {
            var faq = await _faqRepository.GetByIdAsync(request.ID);
            if (faq == null)
            {
                var resposeObject = new Response<FAQDetailVm>(" Id is not found");
                return resposeObject;
            }
            var faqDto = _mapper.Map<FAQDetailVm>(faq);
            var response = new Response<FAQDetailVm>(faqDto);
            return response;
        }
    }
}
