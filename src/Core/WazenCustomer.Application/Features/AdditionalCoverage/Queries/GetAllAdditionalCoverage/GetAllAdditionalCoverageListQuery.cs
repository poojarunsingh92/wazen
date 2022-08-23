using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAllAdditionalCoverage
{
   public class GetAllAdditionalCoverageListQuery : IRequest<Response<IEnumerable<AdditionalCoverageListVm>>>
    {

    }
}
