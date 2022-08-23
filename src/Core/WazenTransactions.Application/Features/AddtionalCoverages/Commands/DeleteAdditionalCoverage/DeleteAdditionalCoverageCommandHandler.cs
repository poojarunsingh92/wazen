using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.AddtionalCoverages.Commands.DeleteAdditionalCoverage
{
    public class DeleteAdditionalCoverageCommandHandler : IRequestHandler<DeleteAdditionalCoverageCommand, Response<bool>>
    {
        private readonly IAdditionalCoverageRepository _additionalCoverageRepsitory;

        public DeleteAdditionalCoverageCommandHandler(IAdditionalCoverageRepository additionalCoverageRepsitory)
        {
            _additionalCoverageRepsitory = additionalCoverageRepsitory;
        }

        public async Task<Response<bool>> Handle(DeleteAdditionalCoverageCommand request, CancellationToken cancellationToken)
        {
            var additionalCoverageToDelete = await _additionalCoverageRepsitory.GetByIdAsync(request.ID);

            if (additionalCoverageToDelete == null)
            {
                var resposeObject = new Response<bool>(request.ID + " is not available");
                return resposeObject;
            }
            await _additionalCoverageRepsitory.DeleteAsync(additionalCoverageToDelete);
            return new Response<bool>(true, "Record deleted");
        }
    }
}
