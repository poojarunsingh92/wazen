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

namespace WazenAdmin.Application.Features.AboutUs.Commands.UpdateAboutUs
{
    public class UpdateAboutUsCommandHandler : IRequestHandler<UpdateAboutUsCommand, Response<Guid>>
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        private readonly IMapper _mapper;

        public UpdateAboutUsCommandHandler(IMapper mapper, IAboutUsRepository aboutUsRepository)
        {
            _mapper = mapper;
            _aboutUsRepository = aboutUsRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var aboutUsToUpdate = await _aboutUsRepository.GetByIdAsync(request.ID);

            if (aboutUsToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateAboutUsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult.ToString());

            _mapper.Map(request, aboutUsToUpdate, typeof(UpdateAboutUsCommand), typeof(WazenAdmin.Domain.Entities.AboutUs));

            await _aboutUsRepository.UpdateAsync(aboutUsToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
