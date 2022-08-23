using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.TermsAndConditions.Commands.CreateTermsAndConditions
{
    public class CreateTermsAndConditionsCommandHandler : IRequestHandler<CreateTermsAndConditionsCommand, Response<CreateTermsAndConditionsDto>>
    {
        private readonly ITermsAndConditionsRepository _termsAndConditionsRepository;
        private readonly IMapper _mapper;

        public CreateTermsAndConditionsCommandHandler(IMapper mapper, ITermsAndConditionsRepository termsAndConditionsRepository)
        {
            _mapper = mapper;
            _termsAndConditionsRepository = termsAndConditionsRepository;
        }

        public async Task<Response<CreateTermsAndConditionsDto>> Handle(CreateTermsAndConditionsCommand request, CancellationToken cancellationToken)
        {
            var createTandCCommandResponse = new Response<CreateTermsAndConditionsDto>();

            var validator = new CreateTermsAndConditionsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createTandCCommandResponse.Succeeded = false;
                createTandCCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createTandCCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var TandC = new WazenAdmin.Domain.Entities.TermsAndConditions()
                {
                    Content = request.Content,
                    Description = request.Description,
                    SerialNo= request.SerialNo,
                    Heading=request.Heading
                };
                TandC = await _termsAndConditionsRepository.AddAsync(TandC);
                createTandCCommandResponse.Data = _mapper.Map<CreateTermsAndConditionsDto>(TandC);
                createTandCCommandResponse.Succeeded = true;
                createTandCCommandResponse.Message = "success";
            }

            return createTandCCommandResponse;
        }
    }
}
