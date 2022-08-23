using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsList
{
    public class GetTermsAndConditionsListQuery : IRequest<Response<IEnumerable<TermsAndConditionsListVm>>>
    {
    }
}
