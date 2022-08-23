using AutoMapper;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;

namespace WazenAdmin.Application.Features.HomePageBanners.Commands.DeleteHomePageBanner
{
    public class DeleteHomePageBannerCommandHandler : IRequestHandler<DeleteHomePageBannerCommand>
    {
        private readonly IHomePageBannerRepository _homePageBannerRepository;
        
        public DeleteHomePageBannerCommandHandler(IHomePageBannerRepository homePageBannerRepository, IDataProtectionProvider provider)
        {
            _homePageBannerRepository = homePageBannerRepository;
        }

        public async Task<Unit> Handle(DeleteHomePageBannerCommand request, CancellationToken cancellationToken)
        {
            var homePageBannerToDelete = await _homePageBannerRepository.GetByIdAsync(request.ID);
            if (homePageBannerToDelete == null)
            {                
                throw new NotFoundException(nameof(HomePageBanner), request.ID);
            }

            await _homePageBannerRepository.DeleteAsync(homePageBannerToDelete);
            return Unit.Value;
        }
    }
}
