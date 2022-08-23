using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceComapniesNameList
{
    public class GetInsuranceCompaniesNameListQuery : IRequest<Response<IEnumerable<InsuranceCompaniesNameListVm>>>
    {
    }
}
