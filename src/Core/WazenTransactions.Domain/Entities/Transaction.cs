using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using WazenTransactions.Domain.Common;

namespace WazenTransactions.Domain.Entities
{
   public class Transaction: AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string StatusDsc { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string PaymentGatewayResponse { get; set; }
        public decimal IcAmount { get; set; }
        public decimal WpAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string CardNumber { get; set; }
        public string PaymentMethod { get; set; }
        public Guid? CustomerId { get; set; }
        public string ICId { get; set; }       


        [ForeignKey("CustomerId")]
        public  Customer Customer { get; set; }
    }
}