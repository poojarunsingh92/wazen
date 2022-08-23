using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.FAQ.Queries.GetFAQListByModule
{
    public class FAQListByModuleVm
    {
        //public Guid ID { get; set; }
        public string Module { get; set; }
        public List<FAQs> Faqs { get; set; }

    }
    
}
