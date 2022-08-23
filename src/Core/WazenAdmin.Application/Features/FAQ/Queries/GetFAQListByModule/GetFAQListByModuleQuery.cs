using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.FAQ.Queries.GetFAQListByModule
{
    public class GetFAQListByModuleQuery : IRequest<Response<IEnumerable<FAQListByModuleVm>>>
    {

    }
}
