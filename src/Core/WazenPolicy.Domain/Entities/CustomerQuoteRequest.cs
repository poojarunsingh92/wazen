using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WazenPolicy.Domain.Common;

namespace Wazen.Domain.Entities
{
   public class CustomerQuoteRequest : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public string RequestID { get; set; }   //It should be like Number in order REQ1/2022 etc
        public string SequenceNumber { get; set; }
        public string CustomerNumber { get; set; }
        public bool IsMainDriver { get; set; }
        public Guid? DriverID { get; set; }
        public string EstimateValue { get; set; }
        public string QuotationPrice { get; set; }
        public string Deduction { get; set; }
        public string AreYouMainDriver { get; set; }

        //[ForeignKey("DriverID")]
        //public Driver Driver { get; set; }
    }
}