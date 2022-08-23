using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class PolicyType : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
