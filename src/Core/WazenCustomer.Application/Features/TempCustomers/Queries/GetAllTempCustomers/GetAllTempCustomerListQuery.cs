using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetAllTempCustomers
{
    public class GetAllTempCustomerListQuery : IRequest<Response<IEnumerable<TempCustomerListVm>>>
    {
    }
}
