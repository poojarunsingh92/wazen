using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.Complaints.Commands.CreateComplaint
{
    public class CreateComplaintCommandHandler : IRequestHandler<CreateComplaintCommand, Response<CreateComplaintDto>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;

        public CreateComplaintCommandHandler(IMapper mapper, IComplaintRepository complaintRepository)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
        }

        public async Task<Response<CreateComplaintDto>> Handle(CreateComplaintCommand request, CancellationToken cancellationToken)
        {
            var createComplaintCommandResponse = new Response<CreateComplaintDto>();

            var validator = new CreateComplaintCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createComplaintCommandResponse.Succeeded = false;
                createComplaintCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createComplaintCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var complaint = new Complaint()
                {
                    CustomerID = request.CustomerID,
                    CustomerName = request.CustomerName,
                    CustomerEmailID = request.CustomerEmailID,
                    ComplaintType = request.ComplaintType,
                    ComplaintPriority = request.ComplaintPriority,
                    Subject = request.Subject,
                    ComplaintMessage = request.ComplaintMessage
                };
                complaint = await _complaintRepository.AddAsync(complaint);
                createComplaintCommandResponse.Data = _mapper.Map<CreateComplaintDto>(complaint);
                createComplaintCommandResponse.Succeeded = true;
                createComplaintCommandResponse.Message = "success";
            }

            return createComplaintCommandResponse;
        }
    }
}
