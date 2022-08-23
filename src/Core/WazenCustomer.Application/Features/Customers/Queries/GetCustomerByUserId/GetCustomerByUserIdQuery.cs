using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.GetCustomerByUserId
{
   public class GetCustomerByUserIdQuery : IRequest<GetCustomerByUserIdListVm>
    {
        public Guid UserId { get; set; }
    }
}
