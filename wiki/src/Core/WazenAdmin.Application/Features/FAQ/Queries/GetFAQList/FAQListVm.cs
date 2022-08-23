using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.FAQ.Queries.GetFAQList
{
    public class FAQListVm
    {
        public Guid ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Module { get; set; }
        public Boolean DisplayOnHome { get; set; }
        public Boolean Status { get; set; }
    }
}
