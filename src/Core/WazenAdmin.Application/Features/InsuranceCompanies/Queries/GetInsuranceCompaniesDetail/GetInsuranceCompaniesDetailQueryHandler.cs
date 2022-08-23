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
using Microsoft.AspNetCore.DataProtection;
using WazenAdmin.Application.Exceptions;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesDetail
{
    public class GetInsuranceCompaniesDetailQueryHandler : IRequestHandler<GetInsuranceCompaniesDetailQuery, Response<InsuranceCompaniesDetailVm>>
    {       
        private readonly IAsyncRepository<WazenAdmin.Domain.Entities.InsuranceCompany> _insuranceCompaniesRepository;
        private readonly IMapper _mapper;

        public GetInsuranceCompaniesDetailQueryHandler(IMapper mapper, IAsyncRepository<WazenAdmin.Domain.Entities.InsuranceCompany> insuranceCompaniesRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;         
            _insuranceCompaniesRepository = insuranceCompaniesRepository;
        }

        public async Task<Response<InsuranceCompaniesDetailVm>> Handle(GetInsuranceCompaniesDetailQuery request, CancellationToken cancellationToken)
        {
            var insuranceCompanies = await _insuranceCompaniesRepository.GetByIdAsync(request.ID);
            if (insuranceCompanies == null)
            {
                var resposeObject = new Response<InsuranceCompaniesDetailVm>(request.ID + " is not available");
                return resposeObject;
            }
            var insuranceCompaniesDetailDto = _mapper.Map<InsuranceCompaniesDetailVm>(insuranceCompanies);
            var response = new Response<InsuranceCompaniesDetailVm>(insuranceCompaniesDetailDto);
            return response;
        }
    }   
}
