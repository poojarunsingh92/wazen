using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenTransactions.Domain.Common;

namespace WazenTransactions.Domain.Entities
{
   public class Customer : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishMiddleName { get; set; }
        public string EnglishLastName { get; set; }
        public string ArabicFirstName { get; set; }
        public string ArabicMiddleName { get; set; }
        public string ArabicLastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NIN { get; set; }
        public int? NationalIdTypeId { get; set; }
        //public Guid UserId { get; set; }

        [ForeignKey("NationalIdTypeId")] 
        public NationalIdType NationalIdType { get; set; } 
    }
}
