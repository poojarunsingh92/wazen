using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.CancellationRequests.Commands.CreateCancellationRequest
{
    public class CreateCancellationRequestCommandHandler : IRequestHandler<CreateCancellationRequestCommand, Response<CreateCancellationRequestDto>>
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

        public async Task<Response<CreateCancellationRequestDto>> Handle(CreateCancellationRequestCommand request, CancellationToken cancellationToken)
        {
                
            var cancellationRequestResponse = new Response<CreateCancellationRequestDto>();
                
            var cancellationRequest = _mapper.Map<CancellationRequest>(request);

            cancellationRequest = await _cancellationRequestRepository.AddAsync(cancellationRequest);


            cancellationRequestResponse.Data = _mapper.Map<CreateCancellationRequestDto>(cancellationRequest);

            cancellationRequestResponse.Succeeded = true;

            cancellationRequestResponse.Message = "Success";
             
            return cancellationRequestResponse;
        }
    }
}
