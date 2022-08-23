using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList
{
    public class GetInsuranceCompanyListQueryHandler : IRequestHandler<GetInsuranceCompanyListQuery, Response<List<InsuranceCompanyListVm>>>
    {
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetInsuranceCompanyListQueryHandler> _logger;

        public GetInsuranceCompanyListQueryHandler(IMapper mapper, IInsuranceCompanyRepository insuranceCompanyRepository, ILogger<GetInsuranceCompanyListQueryHandler> logger)
        {
            _mapper = mapper;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _logger = logger;
        }

        public async Task<Response<List<InsuranceCompanyListVm>>> Handle(GetInsuranceCompanyListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var insuranceCompanies = (await _insuranceCompanyRepository.ListAllAsync()).OrderBy(x => x.Id);

            var insuranceCompanyList = _mapper.Map<List<InsuranceCompanyListVm>>(insuranceCompanies);
            _logger.LogInformation("Handle Completed");
            return new Response<List<InsuranceCompanyListVm>>(insuranceCompanyList, "success");
        }
    }
}
