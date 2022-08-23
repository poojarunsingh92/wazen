using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.HomePageBanners.Commands.UpdateHomePageBanner
{
    public class UpdateHomePageBannerCommandHandler : IRequestHandler<UpdateHomePageBannerCommand, Response<Guid>>
    {
        private readonly IHomePageBannerRepository _homePageBannerRepository;
        private readonly IMapper _mapper;

        public UpdateHomePageBannerCommandHandler(IMapper mapper, IHomePageBannerRepository homePageBannerRepository)
        {
            _mapper = mapper;
            _homePageBannerRepository = homePageBannerRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateHomePageBannerCommand request, CancellationToken cancellationToken)
        {
            var homePageBannerToUpdate = await _homePageBannerRepository.GetByIdAsync(request.ID);

            if (homePageBannerToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateHomePageBannerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, homePageBannerToUpdate, typeof(UpdateHomePageBannerCommand), typeof(HomePageBanner));

            await _homePageBannerRepository.UpdateAsync(homePageBannerToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
