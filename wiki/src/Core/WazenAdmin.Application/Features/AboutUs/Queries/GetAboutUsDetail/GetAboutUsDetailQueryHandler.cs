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

namespace WazenAdmin.Application.Features.AboutUs.Queries.GetAboutUsDetail
{
    public class GetAboutUsDetailQueryHandler : IRequestHandler<GetAboutUsDetailQuery, Response<AboutUsDetailVm>>
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        private readonly IMapper _mapper;

        public GetAboutUsDetailQueryHandler(IMapper mapper, IAboutUsRepository aboutUsRepository, ILogger<GetAboutUsDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _aboutUsRepository = aboutUsRepository;
        }
        public async Task<Response<AboutUsDetailVm>> Handle(GetAboutUsDetailQuery request, CancellationToken cancellationToken)
        {
            var aboutUs = await _aboutUsRepository.GetByIdAsync(request.ID);
            if (aboutUs == null)
            {
                var resposeObject = new Response<AboutUsDetailVm>(request.ID + " is not available");
                return resposeObject;
            }

            var aboutUsDto = _mapper.Map<AboutUsDetailVm>(aboutUs);

            var response = new Response<AboutUsDetailVm>(aboutUsDto, "success");
            return response;
        }
    }
}

