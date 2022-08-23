using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.AboutUs.Queries.GetAboutUsDetail
{
    public class GetAboutUsDetailQuery : IRequest<Response<AboutUsDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
