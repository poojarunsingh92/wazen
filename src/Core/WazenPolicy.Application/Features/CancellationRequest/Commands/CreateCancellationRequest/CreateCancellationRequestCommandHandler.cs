using AutoMapper;
using Wazen.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Responses;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateCancelCustomerPolicy;

namespace WazenPolicy.Application.Features.CancellationRequest.Commands.CreateCancellationRequest
{
    public class CreateCancellationRequestCommandHandler : IRequestHandler<CreateCancellationRequestCommand, Response<CancellationRequestDto>>
    {
        private readonly ICancellationRequestRepository _cancellationRequestRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateCancellationRequestCommandHandler> _logger;
        public CreateCancellationRequestCommandHandler(IMapper mapper, ICancellationRequestRepository cancellationRequestRepository, ILogger<CreateCancellationRequestCommandHandler> logger, IMediator mediator)
        {
            _mapper = mapper;
            _cancellationRequestRepository = cancellationRequestRepository;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<Response<CancellationRequestDto>> Handle(CreateCancellationRequestCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var createCancellationRequestCommandResponse = new Response<CancellationRequestDto>();

            var validator = new CreateCancellationRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCancellationRequestCommandResponse.Succeeded = false;
                createCancellationRequestCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCancellationRequestCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var cancellationRequest = new Domain.Entities.CancellationRequest()
                {
                    PolicyNumber = request.PolicyNumber,
                    InsuranceCompanyName = request.InsuranceCompanyName,
                    SequenceNo = request.SequenceNo,
                    PolicyID = request.PolicyID,
                    CancellationDate = request.CancellationDate,
                    ReasonforCancellation = request.ReasonforCancellation,
                    BankName = request.BankName,
                    IBANNumber = request.IBANNumber,
                    SwiftCode = request.SwiftCode
                };
                cancellationRequest = await _cancellationRequestRepository.AddAsync(cancellationRequest);

                createCancellationRequestCommandResponse.Data = _mapper.Map<CancellationRequestDto>(cancellationRequest);
                createCancellationRequestCommandResponse.Succeeded = true;
                createCancellationRequestCommandResponse.Message = "success";
                var updateCancelCustomerPolicyCommand = new UpdateCancelCustomerPolicyCommand()
                {
                    ID = request.PolicyID,
                    Cancellation = "Yes",
                    ReasonforCancellation = request.ReasonforCancellation,
                    InsuranceCompanyName = request.InsuranceCompanyName,
                    EffectiveCancellationDate = request.CancellationDate
                };
                var response = await _mediator.Send(updateCancelCustomerPolicyCommand);
            }
            _logger.LogInformation("Handle Completed");
            return createCancellationRequestCommandResponse;
        }
    }
}
