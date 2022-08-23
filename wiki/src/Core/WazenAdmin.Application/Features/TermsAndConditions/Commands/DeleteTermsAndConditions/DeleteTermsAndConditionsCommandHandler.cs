using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using AutoMapper;
using MediatR;
using WazenAdmin.Application.Exceptions;
using Microsoft.Extensions.Logging;

namespace WazenAdmin.Application.Features.TermsAndConditions.Commands.DeleteTermsAndConditions
{
    public class DeleteTermsAndConditionsCommandHandler : IRequestHandler<DeleteTermsAndConditionsCommand, Response<bool>>
    {
        private readonly ITermsAndConditionsRepository _termsAndConditionsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteTermsAndConditionsCommandHandler(ITermsAndConditionsRepository termsAndConditionsRepository)
        {
            _termsAndConditionsRepository = termsAndConditionsRepository;
        }

        public async Task<Response<bool>> Handle(DeleteTermsAndConditionsCommand request, CancellationToken cancellationToken)
        {
            var aboutUsToDelete = await _termsAndConditionsRepository.GetByIdAsync(request.ID);

            if (aboutUsToDelete == null)
            {
                throw new NotFoundException(nameof(TermsAndConditions), request.ID);
            }
            await _termsAndConditionsRepository.DeleteAsync(aboutUsToDelete);
            return new Response<bool>(true, "Record deleted");
        }
    }

}


