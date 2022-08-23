using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.FAQ.Queries.GetFAQList
{
    public class GetFAQListQuery : IRequest<Response<IEnumerable<FAQListVm>>>
    {
        
    }

}
