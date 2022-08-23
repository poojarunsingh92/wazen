using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Drawing.Printing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Application.Features.Complaints.Queries.GetComplaintDetail;

namespace Wazen.Application.Features.Complaints.Queries.GetComplaintDetail
{
    public class GetComplaintDetailQueryHandler : IRequestHandler<GetComplaintDetailQuery, Response<ComplaintDetailVm>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetComplaintDetailQueryHandler(IMapper mapper, IComplaintRepository complaintRepository, ILogger<GetComplaintDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _logger = logger;
        }
        public async Task<Response<ComplaintDetailVm>> Handle(GetComplaintDetailQuery request, CancellationToken cancellationToken)
        {
            var complaint = await _complaintRepository.GetByIdAsync(request.ID);
            if (complaint == null)
            {
                var resposeObject = new Response<ComplaintDetailVm>(request.ID + " is not available");
                return resposeObject;
            }

            var complaintDetailDto = _mapper.Map<ComplaintDetailVm>(complaint);
            var response = new Response<ComplaintDetailVm>(complaintDetailDto, "success");
            return response;
        }
    }
}
