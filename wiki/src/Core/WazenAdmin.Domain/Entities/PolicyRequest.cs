using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
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
        public Boolean Status { get; set; }
    }
}
