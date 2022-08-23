using WazenAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;
using WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList
{
    public class GetInsuranceCompaniesListQuery : IRequest<Response<IEnumerable<InsuranceCompaniesListVm>>>
    {
    }
}
