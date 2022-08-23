using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class CustomerPolicy : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string PolicyRequestRefNo { get; set; }
        public Guid VehicleId { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
        public int? PolicyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyResponse { get; set; }
        public string ServiceChargeAmount { get; set; } //Here onwards below newly added fields
        public string AdditionalCoverageAmount { get; set; }
        public string VAT { get; set; }
        public string PremiumAmount { get; set; } //PremiumDetail Renamed to PremiumAmount
        public string GroundTotal { get; set; }
        public Boolean IsUpgraded { get; set; }
        public Boolean IsCancelled { get; set; }

        [ForeignKey("PolicyTypeId")]
        public PolicyType PolicyType { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public virtual ICollection<CustomerPolicyAdditionalCoverage> CustomerPolicyAdditionalCoverage { get; set; }
    }
}