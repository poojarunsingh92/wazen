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

namespace WazenAdmin.Application.Features.FAQ.Queries.GetFAQListByModule
{
    public class GetFAQListByModuleQueryHandler : IRequestHandler<GetFAQListByModuleQuery, Response<IEnumerable<FAQListByModuleVm>>>
    {
        private readonly IFAQRepository _faqRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFAQListByModuleQueryHandler(IMapper mapper, IFAQRepository faqRepository, ILogger<GetFAQListByModuleQueryHandler> logger)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<FAQListByModuleVm>>> Handle(GetFAQListByModuleQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allFaqs = (await _faqRepository.ListAllAsync());

            //FAQListByModuleVm fAQListByModuleVm = new FAQListByModuleVm();
            List<FAQListByModuleVm> fAQList = new List<FAQListByModuleVm>();
            List<string> modules = new List<string>();

            foreach (var f in allFaqs)
            {
                if (modules.Contains(f.Module))
                {
                    continue;

                }
                else
                {
                    FAQListByModuleVm fAQListByModuleVm = new FAQListByModuleVm();
                    fAQListByModuleVm.Module = f.Module;
                    var res = await _faqRepository.GetFaqByModule(f.Module);



                    var fAQL = _mapper.Map<List<FAQs>>(res);
                    fAQListByModuleVm.Faqs = fAQL;
                    modules.Add(f.Module);
                    fAQList.Add(fAQListByModuleVm);


                }

            }

            //var faqs = _mapper.Map<IEnumerable<FAQListByModuleVm>>(fAQList);
            _logger.LogInformation("Hanlde Completed");
            if (fAQList == null)
            {
                var resposeObject = new Response<IEnumerable<FAQListByModuleVm>>(" Id is not found");
                return resposeObject;
            }
            return new Response<IEnumerable<FAQListByModuleVm>>(fAQList, "success");
        }
    }
}

