using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
  public class PolicyType: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
