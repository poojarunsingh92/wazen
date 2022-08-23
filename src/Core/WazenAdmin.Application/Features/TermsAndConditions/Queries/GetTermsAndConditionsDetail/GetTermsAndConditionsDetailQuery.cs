using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsDetail
{
    public class GetTermsAndConditionsDetailQuery : IRequest<Response<TermsAndConditionsDetailVm>>
    {
        public Guid ID { get; set; }
    }
}