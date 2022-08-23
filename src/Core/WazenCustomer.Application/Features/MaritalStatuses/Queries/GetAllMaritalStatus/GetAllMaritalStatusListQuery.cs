using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.MaritalStatuses.Queries.GetAllMaritalStatus
{
   public class GetAllMaritalStatusListQuery : IRequest<Response<IEnumerable<MaritalStatusListVm>>>
    {
    }
}
