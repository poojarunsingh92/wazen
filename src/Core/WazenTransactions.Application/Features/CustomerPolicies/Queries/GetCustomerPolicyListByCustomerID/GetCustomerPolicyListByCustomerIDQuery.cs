
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID
{
    public class GetCustomerPolicyListByCustomerIDQuery : IRequest<Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
