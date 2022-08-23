using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class CustomerVehicle : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }            //FK
        public Guid VehicleID { get; set; }             //FK
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        [ForeignKey("VehicleID")]
        public Vehicle Vehicle { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}