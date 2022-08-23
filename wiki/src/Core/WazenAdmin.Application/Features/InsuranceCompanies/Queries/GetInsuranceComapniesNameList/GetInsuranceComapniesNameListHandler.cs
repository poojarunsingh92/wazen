using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceComapniesNameList
{
    public class GetInsuranceComapniesNameListHandler : IRequestHandler<GetInsuranceCompaniesNameListQuery, Response<IEnumerable<InsuranceCompaniesNameListVm>>>
    {
        private readonly IInsuranceCompaniesRepository _insuranceCompaniesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetInsuranceComapniesNameListHandler(IMapper mapper, IInsuranceCompaniesRepository insuranceCompaniesRepository, ILogger<GetInsuranceComapniesNameListHandler> logger)
        {
            _mapper = mapper;
            _insuranceCompaniesRepository = insuranceCompaniesRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<InsuranceCompaniesNameListVm>>> Handle(GetInsuranceCompaniesNameListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allInsuranceCompanies = (await _insuranceCompaniesRepository.ListAllAsync());
            var user = _mapper.Map<IEnumerable<InsuranceCompaniesNameListVm>>(allInsuranceCompanies);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<InsuranceCompaniesNameListVm>>(user, "success");
        }
    }
}