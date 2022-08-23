using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateCancelCustomerPolicy
{
    public class UpdateCancelCustomerPolicyCommand : IRequest<Response<Guid>>
    {

        public Guid ID { get; set; }
        public string Cancellation { get; set; }
        public string ReasonforCancellation { get; set; }
        public string InsuranceCompanyName { get; set; }
        public DateTime EffectiveCancellationDate { get; set; }
    }
}
