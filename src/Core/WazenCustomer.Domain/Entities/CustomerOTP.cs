using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class CustomerOTP : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public int VerifyCode { get; set; }
        public string NIN { get; set; }
    }
}