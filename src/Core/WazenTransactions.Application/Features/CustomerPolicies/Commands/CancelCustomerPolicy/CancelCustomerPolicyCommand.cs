using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Commands.CancelCustomerPolicy
{
    public class CancelCustomerPolicyCommand : IRequest<Response<bool>>
    {
        public List<CancelPolicy> CancelPolicies { get; set; }
    }
    public class CancelPolicy
    {
        public Guid ID { get; set; }
    }
}
