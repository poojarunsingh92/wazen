using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.GetCustomerById
{
   public class GetCustomerByIdQuery : IRequest<Response<GetCustomerListVm>>
    {
        public Guid Id { get; set; }
    }
}
