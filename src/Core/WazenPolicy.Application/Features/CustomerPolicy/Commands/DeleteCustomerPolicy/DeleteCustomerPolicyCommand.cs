using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.DeleteCustomerPolicy
{
    public class DeleteCustomerPolicyCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
