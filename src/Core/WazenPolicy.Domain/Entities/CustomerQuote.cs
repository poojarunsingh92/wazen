using System;
using System.ComponentModel.DataAnnotations.Schema;
using WazenPolicy.Domain.Common;
using WazenPolicy.Domain.Entities;

namespace Wazen.Domain.Entities
{
   public class CustomerQuote :AuditableEntity
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string VerifyCode { get; set; }


        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}