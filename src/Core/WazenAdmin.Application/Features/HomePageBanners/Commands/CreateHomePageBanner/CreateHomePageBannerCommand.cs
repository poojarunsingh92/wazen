using WazenAdmin.Application.Features.HomePageBanners.Commands.CreateHomePageBanner;
using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Features.HomePageBanners.Commands.CreateHomePageBanner
{
    public class CreateHomePageBannerCommand : IRequest<Response<CreateHomePageBannerDto>>
    {
        public string ImageSource { get; set; }
        public int ProductID { get; set; }
        public Boolean IsActive { get; set; }
    }
}
