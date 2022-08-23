using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.ContactUs.Queries.GetContactUsList
{
  public class GetContactUsListQuery : IRequest<Response<IEnumerable<ContactUsListVm>>>
    {
    }
}
