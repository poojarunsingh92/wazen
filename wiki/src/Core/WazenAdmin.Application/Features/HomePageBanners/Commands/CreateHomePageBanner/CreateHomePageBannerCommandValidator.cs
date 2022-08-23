using FluentValidation;
using WazenAdmin.Features.HomePageBanners.Commands.CreateHomePageBanner;

namespace WazenAdmin.Application.Features.HomePageBanners.Commands.CreateHomePageBanner
{
    public class CreateHomePageBannerCommandValidator : AbstractValidator<CreateHomePageBannerCommand>
    {
        public CreateHomePageBannerCommandValidator()
        {
            
        }
    }
}
