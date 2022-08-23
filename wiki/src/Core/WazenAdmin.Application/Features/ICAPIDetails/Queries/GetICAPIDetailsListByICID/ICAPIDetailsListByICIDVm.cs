using System;

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsListByICID
{
    public class ICAPIDetailsListByICIDVm
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
