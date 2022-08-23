using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsByICID
{
    public class ICAPIDetailsByICIDDto
    {
        public Guid ID { get; set; }
        public Guid ICID { get; set; }
        public string EndPointURL { get; set; }
        public string RequestType { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string APIType { get; set; }
    }
}
