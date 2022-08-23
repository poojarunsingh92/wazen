using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Educations.Queries.GetAllEducations
{
    public class GetAllEducationListQueryHandler : IRequestHandler<GetAllEducationListQuery, Response<IEnumerable<EducationListVm>>>
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        public GetAllEducationListQueryHandler(IMapper mapper, IEducationRepository educationRepository)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
        }
        public async Task<Response<IEnumerable<EducationListVm>>> Handle(GetAllEducationListQuery request, CancellationToken cancellationToken)
        {
            var allEducations = await _educationRepository.ListAllAsync();
            var EducationList = _mapper.Map<List<EducationListVm>>(allEducations);
            var response = new Response<IEnumerable<EducationListVm>>(EducationList);
            return response;
        }
    }
}
