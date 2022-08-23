using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Responses;
using AutoMapper;
using MediatR;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Contracts.Persistence;

namespace WazenAdmin.Application.Features.TermsAndConditions.Commands.UpdateTermsAndConditions
{
    public class UpdateTermsAndConditionsCommandHandler : IRequestHandler<UpdateTermsAndConditionsCommand, Response<Guid>>
    {
        private readonly ITermsAndConditionsRepository _termsAndConditionsRepository;
        private readonly IMapper _mapper;

        public UpdateTermsAndConditionsCommandHandler(IMapper mapper, ITermsAndConditionsRepository termsAndConditionsRepository)
        {
            _mapper = mapper;
            _termsAndConditionsRepository = termsAndConditionsRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateTermsAndConditionsCommand request, CancellationToken cancellationToken)
        {
            var TandCToUpdate = await _termsAndConditionsRepository.GetByIdAsync(request.ID);

            if (TandCToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateTermsAndConditionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, TandCToUpdate, typeof(UpdateTermsAndConditionsCommand), typeof(WazenAdmin.Domain.Entities.TermsAndConditions));

            await _termsAndConditionsRepository.UpdateAsync(TandCToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}

