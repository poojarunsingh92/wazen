using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.GetAllCustomers
{
  public class GetAllCustomerListQuery : IRequest<Response<IEnumerable<CustomerListVm>>>
    {
    }
}
