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

namespace WazenAdmin.Application.Features.Complaints.Commands.UpdateComplaint
{
    public class UpdateComplaintCommandHandler : IRequestHandler<UpdateComplaintCommand, Response<int>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;

        public UpdateComplaintCommandHandler(IMapper mapper, IComplaintRepository complaintRepository)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
        }

        public async Task<Response<int>> Handle(UpdateComplaintCommand request, CancellationToken cancellationToken)
        {

            var complaintToUpdate = await _complaintRepository.GetByIdAsync(request.ID);

            if (complaintToUpdate == null)
            {
                var resposeObject = new Response<int>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateComplaintCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, complaintToUpdate, typeof(UpdateComplaintCommand), typeof(WazenAdmin.Domain.Entities.Complaint));

            await _complaintRepository.UpdateAsync(complaintToUpdate);

            return new Response<int>(request.ID, "Updated successfully ");
        }
    }
}
