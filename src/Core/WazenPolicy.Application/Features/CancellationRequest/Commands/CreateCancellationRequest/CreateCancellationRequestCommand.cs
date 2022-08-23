using MediatR;
using System;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CancellationRequest.Commands.CreateCancellationRequest
{
    public class CreateCancellationRequestCommand : IRequest<Response<CancellationRequestDto>>
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
