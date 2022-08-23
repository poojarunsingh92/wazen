using WazenAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannersList
{
    public class GetHomePageBannersListQuery : IRequest<Response<IEnumerable<WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannersList.HomePageBannerListVm>>>
    {
    }
}
