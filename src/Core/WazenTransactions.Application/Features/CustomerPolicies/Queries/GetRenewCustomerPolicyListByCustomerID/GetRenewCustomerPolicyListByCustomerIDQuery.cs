using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetRenewCustomerPolicyListByCustomerID
{
    public class GetRenewCustomerPolicyListByCustomerIDQuery : IRequest<Response<IEnumerable<RenewCustomerPolicyListByCustomerIDVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
