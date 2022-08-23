using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenPolicy.Domain.Common;

namespace WazenPolicy.Domain.Entities
{
    public class CustomerVehicle : AuditableEntity
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }        //FK
        public Guid VehicleID { get; set; }         //FK
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("VehicleID")]
        public Vehicle Vehicle { get; set; }
    }
}