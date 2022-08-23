using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannersList
{
    public class GetHomePageBannersListQueryHandler : IRequestHandler<GetHomePageBannersListQuery, Response<IEnumerable<HomePageBannerListVm>>>
    {
        private readonly IHomePageBannerRepository _homePageBannerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetHomePageBannersListQueryHandler(IMapper mapper, IHomePageBannerRepository homePageBannerRepository, ILogger<GetHomePageBannersListQueryHandler> logger)
        {
            _mapper = mapper;
            _homePageBannerRepository = homePageBannerRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<HomePageBannerListVm>>> Handle(GetHomePageBannersListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allHomePageBanners = (await _homePageBannerRepository.ListAllAsync()).OrderBy(x => x.ID);
            var homePageBanner = _mapper.Map<IEnumerable<HomePageBannerListVm>>(allHomePageBanners);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<HomePageBannerListVm>>(homePageBanner, "success");
        }
    }
}
