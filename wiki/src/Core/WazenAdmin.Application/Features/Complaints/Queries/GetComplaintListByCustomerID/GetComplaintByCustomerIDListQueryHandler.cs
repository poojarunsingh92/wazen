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

namespace WazenAdmin.Application.Features.Complaints.Queries.GetComplaintListByCustomerID
{
    public class GetComplaintByCustomerIDListQueryHandler : IRequestHandler<GetComplaintByCustomerIDListQuery, Response<IEnumerable<ComplaintByCustomerIDListVm>>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetComplaintByCustomerIDListQueryHandler(IMapper mapper, IComplaintRepository complaintRepository, ILogger<GetComplaintByCustomerIDListQueryHandler> logger)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ComplaintByCustomerIDListVm>>> Handle(GetComplaintByCustomerIDListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allComplaints = (await _complaintRepository.ListAllAsync()).OrderBy(x => x.ID);
            var complaint = _mapper.Map<IEnumerable<ComplaintByCustomerIDListVm>>(allComplaints);
            _logger.LogInformation("Handle Completed");
            if (complaint == null)
            {
                var resposeObject = new Response<IEnumerable<ComplaintByCustomerIDListVm>>("No record is not available");
                return resposeObject;
            }
            return new Response<IEnumerable<ComplaintByCustomerIDListVm>>(complaint, "success");
        }
    }
}
