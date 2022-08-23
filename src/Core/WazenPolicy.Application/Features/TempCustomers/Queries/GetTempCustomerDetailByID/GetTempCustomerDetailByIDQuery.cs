using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Features.Customers.Queries.GetCustomerDetailByID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempCustomers.Queries.GetTempCustomerDetailByID
{
    public class GetTempCustomerDetailByIDQuery : IRequest<Response<CustomerDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
