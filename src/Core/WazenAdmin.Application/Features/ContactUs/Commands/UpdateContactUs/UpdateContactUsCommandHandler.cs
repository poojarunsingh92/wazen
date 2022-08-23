using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.ContactUs.Commands.UpdateContactUs
{
    class UpdateContactUsCommandHandler : IRequestHandler<UpdateContactUsCommand, Response<Guid>>
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;

        public UpdateContactUsCommandHandler(IMapper mapper, IContactUsRepository contactUsRepository)
        {
            _mapper = mapper;
            _contactUsRepository = contactUsRepository;
        }
        public async Task<Response<Guid>> Handle(UpdateContactUsCommand request, CancellationToken cancellationToken)
        {
            var ContactUsToUpdate = await _contactUsRepository.GetByIdAsync(request.Id);

            if (ContactUsToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.Id + " is not available");
                return resposeObject;
            }

            var validator = new UpdateContactUsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult.ToString());

            _mapper.Map(request, ContactUsToUpdate, typeof(UpdateContactUsCommand), typeof(WazenAdmin.Domain.Entities.ContactUs));

            await _contactUsRepository.UpdateAsync(ContactUsToUpdate);

            return new Response<Guid>(request.Id, "Updated successfully ");

        }
    }
}
    