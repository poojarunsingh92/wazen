using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.Occupations.Queries.GetAllOccupations
{
   public class OccupationListVm
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
    }
}
