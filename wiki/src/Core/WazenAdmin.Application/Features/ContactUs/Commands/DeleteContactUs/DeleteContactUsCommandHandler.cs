using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;

namespace WazenAdmin.Application.Features.ContactUs.Commands.DeleteContactUs
{
    public class DeleteContactUsCommandHandler : IRequestHandler<DeleteContactUsCommand>
    {
        private readonly IContactUsRepository _contactUsRepository;
      
        public DeleteContactUsCommandHandler( IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }
        public async Task<Unit> Handle(DeleteContactUsCommand request, CancellationToken cancellationToken)
        {
            var contactUsToDelete = await _contactUsRepository.GetByIdAsync(request.Id);

            if (contactUsToDelete == null)
            {
                throw new NotFoundException(nameof(WazenAdmin.Domain.Entities.ContactUs), request.Id);
            }

            await _contactUsRepository.DeleteAsync(contactUsToDelete);
            return Unit.Value;
        }
    }
}
