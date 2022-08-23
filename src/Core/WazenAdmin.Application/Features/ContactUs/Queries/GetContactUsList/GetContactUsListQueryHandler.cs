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
using WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsDetail;
using WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsList;
using WazenAdmin.Application.Responses;

namespace Wazen.Application.Features.ContactUs.Queries.GetContactUsList
{
    public class GetContactUsListQueryHandler : IRequestHandler<GetContactUsListQuery, Response<IEnumerable<ContactUsListVm>>>
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetContactUsListQueryHandler(IMapper mapper, IContactUsRepository contactUsRepository, ILogger<GetContactUsListQueryHandler> logger)
        {
            _mapper = mapper;
            _contactUsRepository = contactUsRepository;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<ContactUsListVm>>> Handle(GetContactUsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allContactUs = (await _contactUsRepository.ListAllAsync()).OrderBy(x => x.Id);
            var contactUs = _mapper.Map<IEnumerable<ContactUsListVm>>(allContactUs);
            _logger.LogInformation("Handle Completed");
            if (contactUs == null)
            {
                var resposeObject = new Response<IEnumerable<ContactUsListVm>>("No record is not available");
                return resposeObject;
            }
            return new Response<IEnumerable<ContactUsListVm>>(contactUs, "success");
        }
    }
}
