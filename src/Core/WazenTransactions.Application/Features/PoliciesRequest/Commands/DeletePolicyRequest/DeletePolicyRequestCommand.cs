using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.PoliciesRequest.Commands.DeletePolicyRequest
{
   public class DeletePolicyRequestCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
