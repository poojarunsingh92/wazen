using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.UpdateICAPIDetailsByICID
{
    public class UpdateICAPIDetailsByICIDCommandHandler : IRequestHandler<UpdateICAPIDetailsByICIDCommand, Response<Guid>>
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        private readonly IMapper _mapper;

        public UpdateICAPIDetailsByICIDCommandHandler(IMapper mapper, IICAPIDetailRepository iCAPIDetailsRepository)
        {
            _mapper = mapper;
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateICAPIDetailsByICIDCommand request, CancellationToken cancellationToken)
        {
            var iCAPIDetailsRepositoryToUpdate = await _iCAPIDetailsRepository.GetICAPIDetailsByICIDAsync(request.ICID);

            if (iCAPIDetailsRepositoryToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ICID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateICAPIDetailsByICIDCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, iCAPIDetailsRepositoryToUpdate, typeof(UpdateICAPIDetailsByICIDCommand), typeof(WazenAdmin.Domain.Entities.ICAPIDetail));

            await _iCAPIDetailsRepository.UpdateAsync(iCAPIDetailsRepositoryToUpdate);

            return new Response<Guid>(request.ICID, "Updated successfully ");
        }
    }
}
