using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.StaticContents.Commands.CreateStaticContent
{
    public class CreateStaticContentCommandHandler : IRequestHandler<CreateStaticContentCommand, Response<CreateStaticContentDto>>
    {
        private readonly IStaticContentRepository _staticContentRepository;
        private readonly IMapper _mapper;

        public CreateStaticContentCommandHandler(IMapper mapper, IStaticContentRepository statciContentRepository)
        {
            _mapper = mapper;
            _staticContentRepository = statciContentRepository;
        }

        public async Task<Response<CreateStaticContentDto>> Handle(CreateStaticContentCommand request, CancellationToken cancellationToken)
        {
            var createStaticContentCommandResponse = new Response<CreateStaticContentDto>();

            var validator = new CreateStaticContentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createStaticContentCommandResponse.Succeeded = false;
                createStaticContentCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createStaticContentCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var staticContent = new StaticContent() { 
                    AboutUs = request.AboutUs,
                    TermsAndCondition  = request.TermsAndCondition,
                    PartnerName  = request.PartnerName,
                    PartnerLogo  = request.PartnerLogo,
                    RedirectedURL = request.RedirectedURL,
                    Status  = request.Status,
                    NameOfTheCompany  = request.NameOfTheCompany,
                    Address = request.Address,
                    ContactNo = request.ContactNo,
                    EmailAddress = request.EmailAddress,
                    SocialMediaIcon = request.SocialMediaIcon,
                    SocialMediaLink = request.SocialMediaLink,
                    WebsiteLink = request.WebsiteLink,
                    GoogleLocation = request.GoogleLocation
                };
                staticContent = await _staticContentRepository.AddAsync(staticContent);
                createStaticContentCommandResponse.Data = _mapper.Map<CreateStaticContentDto>(staticContent);
                createStaticContentCommandResponse.Succeeded = true;
                createStaticContentCommandResponse.Message = "success";
            }

            return createStaticContentCommandResponse;
        }
    }
}
