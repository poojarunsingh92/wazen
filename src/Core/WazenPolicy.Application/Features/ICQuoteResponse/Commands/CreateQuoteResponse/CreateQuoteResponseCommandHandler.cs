using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;
using WazenPolicy.Domain.Entities;

namespace WazenPolicy.Application.Features.ICQuoteResponses.Commands.CreateQuoteResponse
{
    public class CreateQuoteResponseCommandHandler : IRequestHandler<CreateQuoteResponseCommand, Response<QuoteResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IQuoteResponseRepository _quoteResponseRepository;

        public CreateQuoteResponseCommandHandler(IMapper mapper, IQuoteResponseRepository quoteResponseRepository)
        {
            _mapper = mapper;
            _quoteResponseRepository = quoteResponseRepository;
        }

        public async Task<Response<QuoteResponseDto>> Handle(CreateQuoteResponseCommand request, CancellationToken cancellationToken)
        {
            var createStudentCommandResponse = new Response<QuoteResponseDto>();

            var validator = new CreateQuoteResponseCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createStudentCommandResponse.Succeeded = false;
                createStudentCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createStudentCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var quoteResponse = new InsuranceCompanyQuoteResponse()
                {
                     CreatedOn=request.CreatedOn,
                     QuoteRequestID=request.QuoteRequestID,
                     LiabilityOfDetermination=request.LiabilityOfDetermination,
                     QuotationPrice = request.QuotationPrice,
                     QuoteExpiryTimer = request.QuoteExpiryTimer,
                     Deduction = request.Deduction,
                     AddAddionalCoverage = request.AddAddionalCoverage,
                     QuoteResponses = request.QuoteResponses,
                     CustomerID = request.CustomerID,
                     InsuranceType = request.InsuranceType,
                     InsuranceCompanyName = request.InsuranceCompanyName
                };

                quoteResponse = await _quoteResponseRepository.AddAsync(quoteResponse);
                createStudentCommandResponse.Data = _mapper.Map<QuoteResponseDto>(quoteResponse);
                createStudentCommandResponse.Succeeded = true;
                createStudentCommandResponse.Message = "success";
            }

            return createStudentCommandResponse;
        }
    }
}
