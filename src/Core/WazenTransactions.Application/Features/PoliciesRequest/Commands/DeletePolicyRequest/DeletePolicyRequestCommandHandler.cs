using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Exceptions;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Features.PoliciesRequest.Commands.DeletePolicyRequest
{
   public class DeletePolicyRequestCommandHandler : IRequestHandler<DeletePolicyRequestCommand>
    {
        private readonly IPolicyRequestRepository _policyRequestRepository;

        public DeletePolicyRequestCommandHandler(IPolicyRequestRepository policyRequestRepository)
        {
            _policyRequestRepository = policyRequestRepository;
        }

        public async Task<Unit> Handle(DeletePolicyRequestCommand request, CancellationToken cancellationToken)
        {
            var policRequestToDelete = await _policyRequestRepository.GetByIdAsync(request.ID);

            if (policRequestToDelete == null)
            {
                throw new NotFoundException(nameof(PolicyRequest), request.ID);
            }

            await _policyRequestRepository.DeleteAsync(policRequestToDelete);
            return Unit.Value;
        }
    }
}
