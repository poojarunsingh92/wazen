using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannerDetail
{
    public class GetHomePageBannerDetailQuery : IRequest<Response<HomePageBannerDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
