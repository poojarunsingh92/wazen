using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenTransactions.Domain.Common;

namespace WazenTransactions.Domain.Entities
{
  public class PolicyType: AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}