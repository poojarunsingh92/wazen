using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.UpdateICAPIDeatils
{
    public class UpdateICAPIDetailsCommandHandler : IRequestHandler<UpdateICAPIDetailsCommand, Response<Guid>>
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        private readonly IMapper _mapper;

        public UpdateICAPIDetailsCommandHandler(IMapper mapper, IICAPIDetailRepository iCAPIDetailsRepository)
        {
            _mapper = mapper;
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateICAPIDetailsCommand request, CancellationToken cancellationToken)
        {
            var iCAPIDetailsRepositoryToUpdate = await _iCAPIDetailsRepository.GetByIdAsync(request.ID);

            if (iCAPIDetailsRepositoryToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateICAPIDetailsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, iCAPIDetailsRepositoryToUpdate, typeof(UpdateICAPIDetailsCommand), typeof(WazenAdmin.Domain.Entities.ICAPIDetail));

            await _iCAPIDetailsRepository.UpdateAsync(iCAPIDetailsRepositoryToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
