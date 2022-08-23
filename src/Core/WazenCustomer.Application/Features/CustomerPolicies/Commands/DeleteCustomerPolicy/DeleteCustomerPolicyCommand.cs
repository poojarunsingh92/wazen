using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.CustomerPolicies.Commands.DeleteCustomerPolicy
{
    public class DeleteCustomerPolicyCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
