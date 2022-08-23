using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsDetail
{
    public class GetContactUsDetailQuery : IRequest<Response<ContactUsDetailVm>>
    {
        public Guid Id { get; set; }

    }
}
