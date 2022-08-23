using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.CancellationRequest.Commands.CreateCancellationRequest
{
    public class CancellationRequestDto
    {
        public Guid ID { get; set; }
        public string PolicyNumber { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string SequenceNo { get; set; }
        public Guid PolicyID { get; set; }
        public DateTime CancellationDate { get; set; }
        public string CancellationReason { get; set; }
        public string BankName { get; set; }
        public string IBANNumber { get; set; }
        public string SwiftCode { get; set; }
    }
}
