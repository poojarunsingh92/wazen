using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.FAQ.Queries.GetFAQDetail
{
    public class GetFAQDetailQuery : IRequest<Response<FAQDetailVm>>
    {        
        public Guid ID { get; set; }
    }
}
