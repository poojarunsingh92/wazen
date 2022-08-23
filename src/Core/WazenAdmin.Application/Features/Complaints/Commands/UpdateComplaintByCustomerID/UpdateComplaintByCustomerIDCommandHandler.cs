using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Complaints.Commands.UpdateComplaintByCustomerID
{
    public class UpdateComplaintByCustomerIDCommandHandler : IRequestHandler<UpdateComplaintByCustomerIDCommand, Response<Guid>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;

        public UpdateComplaintByCustomerIDCommandHandler(IMapper mapper, IComplaintRepository complaintRepository)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateComplaintByCustomerIDCommand request, CancellationToken cancellationToken)
        {
            
            var complaintToUpdate = await _complaintRepository.GetComplaintByCustomerIDAsync(request.CustomerID);
            
            if (complaintToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.CustomerID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateComplaintByCustomerIDCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, complaintToUpdate, typeof(UpdateComplaintByCustomerIDCommand), typeof(Complaint));

            await _complaintRepository.UpdateAsync(complaintToUpdate);

            return new Response<Guid>(request.CustomerID, "Updated successfully ");
            return new Response<Guid>();
        }
    }
}
