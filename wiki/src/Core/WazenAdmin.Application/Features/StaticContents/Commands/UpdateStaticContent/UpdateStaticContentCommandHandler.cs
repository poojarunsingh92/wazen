using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.StaticContents.Commands.UpdateStaticContent
{
    public class UpdateStaticContentCommandHandler : IRequestHandler<UpdateStaticContentCommand, Response<Guid>>
    {
        private readonly IStaticContentRepository _staticContentRepository;
        private readonly IMapper _mapper;

        public UpdateStaticContentCommandHandler(IMapper mapper, IStaticContentRepository staticContentRepository)
        {
            _mapper = mapper;
            _staticContentRepository = staticContentRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateStaticContentCommand request, CancellationToken cancellationToken)
        {
            var staticContentToUpdate = await _staticContentRepository.GetByIdAsync(request.ID);

            if (staticContentToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateStaticContentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, staticContentToUpdate, typeof(UpdateStaticContentCommand), typeof(StaticContent));

            await _staticContentRepository.UpdateAsync(staticContentToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
