using AutoMapper;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Exceptions;
using WazenPolicy.Application.Responses;
using WazenPolicy.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WazenPolicy.Application.Features.CancellationRequest.Commands.DeleteCancellationRequest
{
    public class DeleteCancellationRequestCommandHandler : IRequestHandler<DeleteCancellationRequestCommand>
    {
        private readonly ICancellationRequestRepository _cancellationRequestRepository;
        private readonly ILogger _logger;
        
        public DeleteCancellationRequestCommandHandler(ICancellationRequestRepository cancellationRequestRepository,ILogger<DeleteCancellationRequestCommandHandler> logger)
        {
            _cancellationRequestRepository = cancellationRequestRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCancellationRequestCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var cancellationRequestToDelete = await _cancellationRequestRepository.GetByIdAsync(request.ID);
            if (cancellationRequestToDelete == null)
            {
                throw new NotFoundException(nameof(CancellationRequest), request.ID);
            }

            await _cancellationRequestRepository.DeleteAsync(cancellationRequestToDelete);
            _logger.LogInformation("Handle Completed");
            return Unit.Value;
        }
    }
}
