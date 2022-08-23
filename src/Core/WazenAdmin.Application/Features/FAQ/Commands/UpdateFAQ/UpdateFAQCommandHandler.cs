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

namespace WazenAdmin.Application.Features.FAQ.Commands.UpdateFAQ
{
    public class UpdateFAQCommandHandler : IRequestHandler<UpdateFAQCommand, Response<Guid>>
    {
        private readonly IFAQRepository _faqRepository;
        private readonly IMapper _mapper;

        public UpdateFAQCommandHandler(IMapper mapper, IFAQRepository faqRepository)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateFAQCommand request, CancellationToken cancellationToken)
        {
            var faqToUpdate = await _faqRepository.GetByIdAsync(request.ID);

            if (faqToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateFAQCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult.ToString());

            _mapper.Map(request, faqToUpdate, typeof(UpdateFAQCommand), typeof(WazenAdmin.Domain.Entities.FAQ));

            await _faqRepository.UpdateAsync(faqToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
