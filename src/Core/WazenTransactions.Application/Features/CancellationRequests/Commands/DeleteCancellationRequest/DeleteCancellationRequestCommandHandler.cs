using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Exceptions;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Features.CancellationRequests.Commands.DeleteCancellationRequest
{
    public class DeleteCancellationRequestCommandHandler : IRequestHandler<DeleteCancellationRequestCommand>
    {
        private readonly ICancellationRequestRepository _cancellationRequestRepository;
        private readonly ILogger _logger;

        public DeleteCancellationRequestCommandHandler(ICancellationRequestRepository cancellationRequestRepository, ILogger<DeleteCancellationRequestCommandHandler> logger)
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
