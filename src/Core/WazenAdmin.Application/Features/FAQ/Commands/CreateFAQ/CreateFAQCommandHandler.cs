using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Features.FAQ.Commands.CreateFAQ;
using WazenAdmin.Application.Responses;

namespace Wazen.Application.Features.FAQ.Commands.CreateFAQ
{
    public class CreateFAQCommandHandler : IRequestHandler<CreateFAQCommand, Response<CreateFAQDto>>
    {
        private readonly IFAQRepository _faqRepository;
        private readonly IMapper _mapper;

        public CreateFAQCommandHandler(IMapper mapper, IFAQRepository faqRepository)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
        }        

        public async Task<Response<CreateFAQDto>> Handle(CreateFAQCommand request, CancellationToken cancellationToken)
        {
            var createFAQCommandResponse = new Response<CreateFAQDto>();

            var validator = new CreateFAQCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createFAQCommandResponse.Succeeded = false;
                createFAQCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createFAQCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var faq = new WazenAdmin.Domain.Entities.FAQ()
                {
                    Question= request.Question,
                    Answer=request.Answer,
                    Module=request.Module,
                    DisplayOnHome=request.DisplayOnHome,
                    Status=request.Status
                };
                faq = await _faqRepository.AddAsync(faq);
                createFAQCommandResponse.Data = _mapper.Map<CreateFAQDto>(faq);
                createFAQCommandResponse.Succeeded = true;
                createFAQCommandResponse.Message = "success";
            }

            return createFAQCommandResponse;
        }
    }
}
