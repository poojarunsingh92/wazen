using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.AboutUs.Queries.GetAboutUsList
{
    public class GetAboutUsListQuery : IRequest<Response<IEnumerable<AboutUsListVm>>>
    {
    }
}
