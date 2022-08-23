using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.PoliciesRequest.Commands.CreatePolicyRequest
{
   public class CreatePolicyRequestCommand : IRequest<Response<CreatePolicyRequestDto>>
    {
        public string InsurancePolicy_ProductName { get; set; }
        public int NationalID { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public string PolicyDuration { get; set; }
        public string PolicyAmount { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }
    }
}
