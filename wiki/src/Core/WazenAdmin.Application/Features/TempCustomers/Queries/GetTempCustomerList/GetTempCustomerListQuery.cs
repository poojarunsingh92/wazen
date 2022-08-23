using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.TempCustomers.Queries.GetTempCustomerList
{
    public class GetTempCustomerListQuery : IRequest<Response<IEnumerable<TempCustomerListVm>>>
    {         
    }
}
