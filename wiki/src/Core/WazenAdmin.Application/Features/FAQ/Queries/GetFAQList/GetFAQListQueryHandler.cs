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

namespace WazenAdmin.Application.Features.FAQ.Queries.GetFAQList
{
    public class GetFAQListQueryHandler : IRequestHandler<GetFAQListQuery, Response<IEnumerable<FAQListVm>>>
    {
        private readonly IFAQRepository _faqRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFAQListQueryHandler(IMapper mapper, IFAQRepository faqRepository, ILogger<GetFAQListQueryHandler> logger)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _logger = logger;
        }        

        public async Task<Response<IEnumerable<FAQListVm>>> Handle(GetFAQListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allFaqs = (await _faqRepository.ListAllAsync()).OrderBy(x => x.ID);

            var faqs = _mapper.Map<IEnumerable<FAQListVm>>(allFaqs);
            _logger.LogInformation("Hanlde Completed");
            if (faqs == null)
            {
                var resposeObject = new Response<IEnumerable<FAQListVm>>(" Id is not found");
                return resposeObject;
            }
            return new Response<IEnumerable<FAQListVm>>(faqs, "success");
        }
    }
}
