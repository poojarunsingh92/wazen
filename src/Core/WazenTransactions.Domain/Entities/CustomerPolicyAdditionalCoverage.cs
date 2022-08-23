using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenTransactions.Domain.Common;

namespace WazenTransactions.Domain.Entities
{
  public class CustomerPolicyAdditionalCoverage: AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? CustomerPolicyId { get; set; }
        public string AdditionalCoverage { get; set; }

        [ForeignKey("CustomerPolicyId")]
        public CustomerPolicy CustomerPolicy { get; set; }
    }
}