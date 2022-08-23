using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.Occupations.Queries.GetOccupationById
{
   public class GetOccupationListVm
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
    }
}
