using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.ContactUs.Commands.CreateContactUs
{
    public class CreateContactUsCommandHandler : IRequestHandler<CreateContactUsCommand, Response<CreateContactUsDto>>
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;

        public CreateContactUsCommandHandler(IMapper mapper, IContactUsRepository contactUsRepository)
        {
            _mapper = mapper;
            _contactUsRepository = contactUsRepository;
        }
        public async Task<Response<CreateContactUsDto>> Handle(CreateContactUsCommand request, CancellationToken cancellationToken)
        {
            var createContactUsResponse = new Response<CreateContactUsDto>();
            var validator = new CreateContactUsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createContactUsResponse.Succeeded = false;
                createContactUsResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createContactUsResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var contactUs = new WazenAdmin.Domain.Entities.ContactUs()
                {
                    NameOfTheCompany = request.NameOfTheCompany,
                    Address = request.Address,
                    ContactNo= request.ContactNo,
                    EmailAddress= request.EmailAddress,
                    Facebook=request.Facebook,
                    Twitter=request.Twitter,
                    LinkedIn=request.LinkedIn,
                    WebsiteLink=request.WebsiteLink,
                    GoogleLocation=request.GoogleLocation

                };
                contactUs = await _contactUsRepository.AddAsync(contactUs);
                createContactUsResponse.Data = _mapper.Map<CreateContactUsDto>(contactUs);
                createContactUsResponse.Succeeded = true;
                createContactUsResponse.Message = "success";
            }

            return createContactUsResponse;
        }
    }
}
