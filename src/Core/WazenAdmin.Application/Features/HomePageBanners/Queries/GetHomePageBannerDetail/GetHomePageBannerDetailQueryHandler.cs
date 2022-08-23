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

namespace WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannerDetail
{
    public class GetHomePageBannerDetailQueryHandler : IRequestHandler<GetHomePageBannerDetailQuery, Response<HomePageBannerDetailVm>>
    {       
        private readonly IAsyncRepository<HomePageBanner> _homePageBannerRepository;
        private readonly IMapper _mapper;

        public GetHomePageBannerDetailQueryHandler(IMapper mapper, IAsyncRepository<HomePageBanner> homePageBannerRepository)
        {
            _mapper = mapper;
            _homePageBannerRepository = homePageBannerRepository;
        }

        public async Task<Response<HomePageBannerDetailVm>> Handle(GetHomePageBannerDetailQuery request, CancellationToken cancellationToken)
        {

            var homePageBanner = await _homePageBannerRepository.GetByIdAsync(request.ID);
            if (homePageBanner == null)
            {
                var resposeObject = new Response<HomePageBannerDetailVm>(request.ID + " is not available");
                return resposeObject;
            }
            var homePageBannerDetailDto = _mapper.Map<HomePageBannerDetailVm>(homePageBanner);
            var response = new Response<HomePageBannerDetailVm>(homePageBannerDetailDto);
            return response;
        }
    }
}
