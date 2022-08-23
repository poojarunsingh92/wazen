using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.QuoteResponses.Queries.GetQuoteResponseByCustomerIDVehicleID
{
    public class NCDEligibilityResponse
    {
        public int statusCode { get; set; }
        public string ncdReference { get; set; }
        public int ncdFreeYears { get; set; }
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }
}
