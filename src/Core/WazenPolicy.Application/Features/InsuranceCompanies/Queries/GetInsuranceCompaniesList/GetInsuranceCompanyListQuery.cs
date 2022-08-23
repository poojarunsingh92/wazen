using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList
{
    public class GetInsuranceCompanyListQuery : IRequest<Response<List<InsuranceCompanyListVm>>>
    {
    }
}
