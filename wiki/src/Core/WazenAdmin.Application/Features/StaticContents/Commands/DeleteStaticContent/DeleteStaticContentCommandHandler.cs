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

namespace WazenAdmin.Application.Features.StaticContents.Commands.DeleteStaticContent
{
    public class DeleteStaticContentCommandHandler : IRequestHandler<DeleteStaticContentCommand>
    {
        private readonly IStaticContentRepository _staticContentRepository;
        private readonly IDataProtector _protector;

        public DeleteStaticContentCommandHandler(IStaticContentRepository staticContentRepository, IDataProtectionProvider provider)
        {
            _staticContentRepository = staticContentRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Unit> Handle(DeleteStaticContentCommand request, CancellationToken cancellationToken)
        {
            var staticContentToDelete = await _staticContentRepository.GetByIdAsync(request.ID);
            if (staticContentToDelete == null)
            {
                throw new NotFoundException(nameof(StaticContent), request.ID);
            }

            await _staticContentRepository.DeleteAsync(staticContentToDelete);
            return Unit.Value;
        }
    }
}
