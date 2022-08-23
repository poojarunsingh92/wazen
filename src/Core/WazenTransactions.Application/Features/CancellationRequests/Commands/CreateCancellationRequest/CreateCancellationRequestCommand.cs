using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CancellationRequests.Commands.CreateCancellationRequest
{
   public class CreateCancellationRequestCommand : IRequest<Response<List<CreateCancellationRequestDto>>>
    {
        public List<CancellationRequests> CancellationRequests { get; set; }
        
    }
    public class CancellationRequests
    {
        public string PolicyNumber { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string SequenceNo { get; set; }
        public Guid PolicyID { get; set; }
        public DateTime CancellationDate { get; set; }
        public string ReasonforCancellation { get; set; }
        public string BankName { get; set; }
        public string IBANNumber { get; set; }
        public string SwiftCode { get; set; }
    }
}
