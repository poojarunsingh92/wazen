using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList
{
    public class GetInsuranceCompaniesListQueryHandler : IRequestHandler<GetInsuranceCompaniesListQuery, Response<IEnumerable<InsuranceCompaniesListVm>>>
    {
        private readonly IInsuranceCompaniesRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetInsuranceCompaniesListQueryHandler(IMapper mapper, IInsuranceCompaniesRepository userRepository, ILogger<GetInsuranceCompaniesListQueryHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<InsuranceCompaniesListVm>>> Handle(GetInsuranceCompaniesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allUsers = (await _userRepository.ListAllAsync()).OrderBy(x => x.NameofICAdmin);
            var user = _mapper.Map<IEnumerable<InsuranceCompaniesListVm>>(allUsers);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<InsuranceCompaniesListVm>>(user, "success");
        }
    }
}
