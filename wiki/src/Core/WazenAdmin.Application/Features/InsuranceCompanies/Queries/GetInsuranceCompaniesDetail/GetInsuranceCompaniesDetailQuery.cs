using WazenAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesDetail
{
    public class GetInsuranceCompaniesDetailQuery : IRequest<Response<InsuranceCompaniesDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
