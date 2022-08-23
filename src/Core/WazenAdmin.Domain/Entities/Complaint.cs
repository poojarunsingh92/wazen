using System;
using System.ComponentModel.DataAnnotations.Schema;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
    public class Complaint : AuditableEntity
    {
        public int ID { get; set; }
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmailID { get; set; }
        public string ComplaintType { get; set; }
        public string ComplaintPriority { get; set; }
        public string Subject { get; set; }
        public string ComplaintMessage { get; set; }

        //ForeignKey
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}
