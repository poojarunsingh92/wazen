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

namespace WazenAdmin.Application.Features.Complaints.Commands.DeleteComplaintByCustomerID
{
    public class DeleteComplaintByCustomerIDCommandHandler : IRequestHandler<DeleteComplaintByCustomerIDCommand>
    {
        private readonly IComplaintRepository _complaintRepository;

        public DeleteComplaintByCustomerIDCommandHandler(IComplaintRepository complaintRepository, IDataProtectionProvider provider)
        {
            _complaintRepository = complaintRepository;

        }

        public async Task<Unit> Handle(DeleteComplaintByCustomerIDCommand request, CancellationToken cancellationToken)
        {
            var complaintToDelete = await _complaintRepository.GetComplaintByCustomerIDAsync(request.CustomerID);

            if (complaintToDelete == null)
            {
                throw new NotFoundException(nameof(Complaint), request.CustomerID);
            }

            await _complaintRepository.DeleteAsync(complaintToDelete);
            return Unit.Value;
        }
    }
}
