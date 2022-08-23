using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.DeleteICAPIDetails
{
    public class DeleteICAPIDetailsCommandHandler : IRequestHandler<DeleteICAPIDetailsCommand>
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        private readonly IDataProtector _protector;

        public DeleteICAPIDetailsCommandHandler(IICAPIDetailRepository iCAPIDetailsRepository, IDataProtectionProvider provider)
        {
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Unit> Handle(DeleteICAPIDetailsCommand request, CancellationToken cancellationToken)
        {
            var iCAPIDetailsToDelete = await _iCAPIDetailsRepository.GetByIdAsync(request.ID);
           
            if (iCAPIDetailsToDelete == null)
            {
                throw new NotFoundException(nameof(WazenAdmin.Domain.Entities.ICAPIDetail), request.ID);
            }

            await _iCAPIDetailsRepository.DeleteAsync(iCAPIDetailsToDelete);
            return Unit.Value;
        }
    }
}
