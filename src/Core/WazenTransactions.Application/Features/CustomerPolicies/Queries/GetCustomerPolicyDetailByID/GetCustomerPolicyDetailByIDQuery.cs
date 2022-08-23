using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyDetailByID
{
    public class GetCustomerPolicyDetailByIDQuery : IRequest<Response<CustomerPolicyDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
