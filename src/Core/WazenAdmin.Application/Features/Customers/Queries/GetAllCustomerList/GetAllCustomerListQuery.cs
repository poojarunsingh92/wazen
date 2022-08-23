using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Customers.Queries.GetAllCustomerList
{
    public class GetAllCustomerListQuery : IRequest<Response<IEnumerable<AllCustomerListVm>>>
    {
    }
}
