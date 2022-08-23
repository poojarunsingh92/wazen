using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Complaints.Commands.DeleteComplaint
{
    public class DeleteComplaintCommandHandler : IRequestHandler<DeleteComplaintCommand>
    {
        private readonly IComplaintRepository _complaintRepository;

        public DeleteComplaintCommandHandler(IComplaintRepository complaintRepository, IDataProtectionProvider provider)
        {
            _complaintRepository = complaintRepository;

        }

        public async Task<Unit> Handle(DeleteComplaintCommand request, CancellationToken cancellationToken)
        {

            var complaintToDelete = await _complaintRepository.GetByIdAsync(request.ID);

            if (complaintToDelete == null)
            {
                throw new NotFoundException(nameof(Complaint), request.ID);
            }

            await _complaintRepository.DeleteAsync(complaintToDelete);
            return Unit.Value;
        }
    }
}
