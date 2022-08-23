using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.CancellationRequests.Queries.GetCancellationRequestByPolicyID
{
    public class CancellationRequestByPolicyIDVm
    {
        public Guid ID { get; set; }
        public string PolicyNumber { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string SequenceNo { get; set; }
        public Guid PolicyID { get; set; }      //FK
        public DateTime CancellationDate { get; set; }
        public string ReasonforCancellation { get; set; }
        public string BankName { get; set; }
        public string IBANNumber { get; set; }
        public string SwiftCode { get; set; }
    }
}
