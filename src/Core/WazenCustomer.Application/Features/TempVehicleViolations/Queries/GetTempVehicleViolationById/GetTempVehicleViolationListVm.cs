using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationById
{
   public class GetTempVehicleViolationListVm
    {
        public Guid ID { get; set; }
        public Guid? VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int? ViolationTypeId { get; set; }
    }
}
