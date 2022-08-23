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

namespace WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsDetail
{
    class GetContactUsDetailQueryHandler : IRequestHandler<GetContactUsDetailQuery, Response<ContactUsDetailVm>>
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetContactUsDetailQueryHandler(IMapper mapper, IContactUsRepository contactUsRepository, ILogger<GetContactUsDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _contactUsRepository = contactUsRepository;
            _logger = logger;
        }
        public async Task<Response<ContactUsDetailVm>> Handle(GetContactUsDetailQuery request, CancellationToken cancellationToken)
        {
            var contactUs = await _contactUsRepository.GetByIdAsync(request.Id);
            if (contactUs == null)
            {
                var resposeObject = new Response<ContactUsDetailVm>(request.Id + " is not available");
                return resposeObject;
            }

            var contactUsDetailDto = _mapper.Map<ContactUsDetailVm>(contactUs);
            var response = new Response<ContactUsDetailVm>(contactUsDetailDto, "success");
            return response;
        }
    }
}
