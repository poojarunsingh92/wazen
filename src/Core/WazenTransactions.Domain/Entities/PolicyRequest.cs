using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenTransactions.Domain.Common;

namespace WazenTransactions.Domain.Entities
{
   public class PolicyRequest : AuditableEntity
    {
        public Guid ID { get; set; }
        public string InsurancePolicy_ProductName { get; set; }
        public int NationalityID { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public string PolicyDuration { get; set; }
        public string PolicyAmount { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }

        [ForeignKey("NationalityID")]
        public NationalIdType NationalIdType { get; set;  }
    }
}