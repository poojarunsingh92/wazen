using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentDetail
{
    public class GetStaticContentDetailQueryHandler : IRequestHandler<GetStaticContentDetailQuery, Response<StaticContentDetailVm>>
    {      
        private readonly IAsyncRepository<StaticContent> _staticContentRepository;
        private readonly IMapper _mapper;

        public GetStaticContentDetailQueryHandler(IMapper mapper,  IAsyncRepository<StaticContent> staticContentRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _staticContentRepository = staticContentRepository;
        }

        public async Task<Response<StaticContentDetailVm>> Handle(GetStaticContentDetailQuery request, CancellationToken cancellationToken)
        {
            var staticContent = await _staticContentRepository.GetByIdAsync(request.ID);
            if (staticContent == null)
            {
                var resposeObject = new Response<StaticContentDetailVm>(request.ID + " is not available");
                return resposeObject;
            }
            var staticContentDetailDto = _mapper.Map<StaticContentDetailVm>(staticContent);
            var response = new Response<StaticContentDetailVm>(staticContentDetailDto,"success");
            return response;
        }
    }
}
