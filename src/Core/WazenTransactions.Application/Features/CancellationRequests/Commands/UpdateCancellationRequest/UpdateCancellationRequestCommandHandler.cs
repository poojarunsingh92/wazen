using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CancellationRequests.Commands.UpdateCancellationRequest
{
    public class UpdateCancellationRequestCommandHandler : IRequestHandler<UpdateCancellationRequestCommand, Response<Guid>>
    {
        private readonly ICancellationRequestRepository _cancellationRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateCancellationRequestCommandHandler(IMapper mapper, ICancellationRequestRepository cancellationRequestRepository, ILogger<UpdateCancellationRequestCommandHandler> logger)
        {
            _mapper = mapper;
            _cancellationRequestRepository = cancellationRequestRepository;
            _logger = logger;
        }
        public async Task<Response<Guid>> Handle(UpdateCancellationRequestCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var cancellationRequestToUpdate = await _cancellationRequestRepository.GetByIdAsync(request.ID);

            if (cancellationRequestToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            _mapper.Map(request, cancellationRequestToUpdate, typeof(UpdateCancellationRequestCommand), typeof(Domain.Entities.CancellationRequest));

            await _cancellationRequestRepository.UpdateAsync(cancellationRequestToUpdate);
            _logger.LogInformation("Handle Completed");
            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
