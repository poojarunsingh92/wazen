using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenTransactions.Domain.Common;

namespace WazenTransactions.Domain.Entities
{
    public class Vehicle : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime VehicleRegistrationExpiryDate { get; set; }
        public Guid? CustomerID { get; set; }

        //Newly Added fields
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }


        public virtual CustomerPolicy CustomerPolicies { get; set; }
    }
}