using WazenPolicy.Application.Responses;
using MediatR;
using System;

namespace WazenPolicy.Application.Features.CancellationRequest.Commands.UpdateCancellationRequest
{
    public class UpdateCancellationRequestCommand : IRequest<Response<Guid>>
    {
        public Guid ID { get; set; }
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
