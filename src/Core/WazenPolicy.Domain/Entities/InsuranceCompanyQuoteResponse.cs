using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenPolicy.Domain.Common;

namespace WazenPolicy.Domain.Entities
{
    public class InsuranceCompanyQuoteResponse : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string QuoteRequestID { get; set; }
        public string LiabilityOfDetermination { get; set; }
        public string QuotationPrice { get; set; }
        public DateTime QuoteExpiryTimer { get; set; }
        public string Deduction { get; set; }
        public string AddAddionalCoverage { get; set; }
        public string QuoteResponses { get; set; }
        public Guid CustomerID { get; set; }
        public string InsuranceType { get; set; }
        public string InsuranceCompanyName { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}