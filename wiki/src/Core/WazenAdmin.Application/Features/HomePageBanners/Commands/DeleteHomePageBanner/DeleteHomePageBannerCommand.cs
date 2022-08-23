using MediatR;
using System;

namespace WazenAdmin.Application.Features.HomePageBanners.Commands.DeleteHomePageBanner
{
    public class DeleteHomePageBannerCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
