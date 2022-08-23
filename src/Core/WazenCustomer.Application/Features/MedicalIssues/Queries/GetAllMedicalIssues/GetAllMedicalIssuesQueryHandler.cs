using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.MedicalIssues.Queries.GetAllMedicalIssues
{
    public class GetAllMedicalIssuesQueryHandler : IRequestHandler<GetAllMedicalIssuesQuery, Response<IEnumerable<MedicalIssuesListVm>>>
    {
        private readonly IMedicalIssueRepository _medicalIssueRepository;
        private readonly IMapper _mapper;
        public GetAllMedicalIssuesQueryHandler(IMapper mapper, IMedicalIssueRepository medicalIssueRepository)
        {
            _mapper = mapper;
            _medicalIssueRepository = medicalIssueRepository;
        }
        public async Task<Response<IEnumerable<MedicalIssuesListVm>>> Handle(GetAllMedicalIssuesQuery request, CancellationToken cancellationToken)
        {
            var allMedicalIssues = await _medicalIssueRepository.ListAllAsync();
            var MedicalIssueList = _mapper.Map<List<MedicalIssuesListVm>>(allMedicalIssues);
            var response = new Response<IEnumerable<MedicalIssuesListVm>>(MedicalIssueList);
            return response;
        }
    }
}
