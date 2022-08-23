using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerCancelPolicyQuote
{
    public class GetCustomerCancelPolicyQuoteQuery : IRequest<Response<CustomerCancelPolicyQuoteVm>>
    {
        public string CustomID { get; set; }
        public string PolicyName { get; set; }
        public string SequenceNumber { get; set; }
    }
}
