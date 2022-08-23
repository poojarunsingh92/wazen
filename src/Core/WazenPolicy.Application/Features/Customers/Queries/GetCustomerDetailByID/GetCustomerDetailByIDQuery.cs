using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Customers.Queries.GetCustomerDetailByID
{
    public class GetCustomerDetailByIDQuery : IRequest<Response<CustomerDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
