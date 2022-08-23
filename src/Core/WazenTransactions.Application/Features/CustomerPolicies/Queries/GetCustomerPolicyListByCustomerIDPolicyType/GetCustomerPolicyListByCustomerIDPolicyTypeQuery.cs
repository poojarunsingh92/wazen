using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerIDPolicyType
{
    public class GetCustomerPolicyListByCustomerIDPolicyTypeQuery : IRequest<Response<IEnumerable<CustomerPolicyListByCustomerIDPolicyTypeVm>>>
    {
        public Guid CustomerID { get; set; }
        public int PolicyType { get; set; }
    }
}
