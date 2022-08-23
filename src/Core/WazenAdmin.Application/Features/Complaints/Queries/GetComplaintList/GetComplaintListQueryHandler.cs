using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.Complaints.Queries.GetComplaintList
{
    public class GetComplaintListQueryHandler : IRequestHandler<GetComplaintListQuery, Response<IEnumerable<ComplaintListVm>>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetComplaintListQueryHandler(IMapper mapper, IComplaintRepository complaintRepository, ILogger<GetComplaintListQueryHandler> logger)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ComplaintListVm>>> Handle(GetComplaintListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allComplaints = (await _complaintRepository.ListAllAsync()).OrderBy(x => x.ID);
            var complaint = _mapper.Map<IEnumerable<ComplaintListVm>>(allComplaints);
            _logger.LogInformation("Handle Completed");
            if (complaint == null)
            {
                var resposeObject = new Response<IEnumerable<ComplaintListVm>>("No record is not available");
                return resposeObject;
            }
            return new Response<IEnumerable<ComplaintListVm>>(complaint, "success");
        }
    }
}
