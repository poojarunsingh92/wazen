using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using WazenAdmin.Features.HomePageBanners.Commands.CreateHomePageBanner;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.HomePageBanners.Commands.CreateHomePageBanner
{
    public class CreateHomePageBannerCommandHandler : IRequestHandler<CreateHomePageBannerCommand, Response<CreateHomePageBannerDto>>
    {
        private readonly IHomePageBannerRepository _homePageBannerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateHomePageBannerCommandHandler> _logger;
        public CreateHomePageBannerCommandHandler(IMapper mapper, IHomePageBannerRepository homePageBannerRepository,ILogger<CreateHomePageBannerCommandHandler> logger)
        {
            _mapper = mapper;
            _homePageBannerRepository = homePageBannerRepository;
            _logger =logger;
        }

        public async Task<Response<CreateHomePageBannerDto>> Handle(CreateHomePageBannerCommand request, CancellationToken cancellationToken)
        {
            var createHomePageBannerCommandResponse = new Response<CreateHomePageBannerDto>();

            var validator = new CreateHomePageBannerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createHomePageBannerCommandResponse.Succeeded = false;
                createHomePageBannerCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createHomePageBannerCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var homePageBanner = new HomePageBanner() { 
                    ImageSource = request.ImageSource, 
                    ProductID = request.ProductID,
                    IsActive = request.IsActive
                };
                homePageBanner = await _homePageBannerRepository.AddAsync(homePageBanner);
                createHomePageBannerCommandResponse.Data = _mapper.Map<CreateHomePageBannerDto>(homePageBanner);
                createHomePageBannerCommandResponse.Succeeded = true;
                createHomePageBannerCommandResponse.Message = "success";
            }

            return createHomePageBannerCommandResponse;
        }
    }
}
