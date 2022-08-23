using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.ViolationTypes.Queries.GetViolationTypeDetailByID
{
    public class ViolationTypeDetailVm
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
    }
}
