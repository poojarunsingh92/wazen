using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class CustomerPolicyAdditionalCoverage : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerPolicyId { get; set; }         //FK
        public string AdditionalCoverage { get; set; }

        [ForeignKey("CustomerPolicyId")]
        public CustomerPolicy CustomerPolicy { get; set; }

    }
}