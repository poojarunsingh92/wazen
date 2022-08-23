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

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.DeleteICAPIDetailsByICID
{
    public class DeleteICAPIDetailsByICIDCommandHandler : IRequestHandler<DeleteICAPIDetailsByICIDCommand>
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        
        public DeleteICAPIDetailsByICIDCommandHandler(IICAPIDetailRepository iCAPIDetailsRepository)
        {
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
        }

        public async Task<Unit> Handle(DeleteICAPIDetailsByICIDCommand request, CancellationToken cancellationToken)
        {

            var iCAPIDetailsToDelete = await _iCAPIDetailsRepository.GetICAPIDetailsByICIDAsync(request.ICID);

            if (iCAPIDetailsToDelete == null)
            {
                throw new NotFoundException(nameof(ICAPIDetail), request.ICID);
            }

            await _iCAPIDetailsRepository.DeleteAsync(iCAPIDetailsToDelete);
            return Unit.Value;
        }
    }
}
