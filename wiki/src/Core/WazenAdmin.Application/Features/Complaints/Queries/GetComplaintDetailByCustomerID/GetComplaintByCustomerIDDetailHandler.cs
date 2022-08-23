using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Complaints.Queries.GetComplaintDetailByCustomerID
{
    public class GetComplaintByCustomerIDDetailHandler : IRequestHandler<GetComplaintByCustomerIDDetailQuery, Response<GetComplaintByCustomerIDDetailVm>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetComplaintByCustomerIDDetailHandler(IMapper mapper, IComplaintRepository complaintRepository, ILogger<GetComplaintByCustomerIDDetailHandler> logger)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _logger = logger;
        }
        public async Task<Response<GetComplaintByCustomerIDDetailVm>> Handle(GetComplaintByCustomerIDDetailQuery request, CancellationToken cancellationToken)
        {
            var complaint = await _complaintRepository.GetComplaintByCustomerIDAsync(request.CustomerID);
            if (complaint == null)
            {
                var resposeObject = new Response<GetComplaintByCustomerIDDetailVm>(request.CustomerID + " is not available");
                return resposeObject;
            }

            var complaintDetailDto = _mapper.Map<GetComplaintByCustomerIDDetailVm>(complaint);
            var response = new Response<GetComplaintByCustomerIDDetailVm>(complaintDetailDto, "success");
            return response;
        }
    }
}
